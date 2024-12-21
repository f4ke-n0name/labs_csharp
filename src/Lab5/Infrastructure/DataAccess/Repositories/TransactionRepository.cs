using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using System.Security.Authentication;
using Utils.Models.Contracts;
using Utils.Models.Enums;
using Utils.Models.Handlers;

namespace Infrastructure.DataAccess.Repositories;

public class TransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task Withdrawal(long accountId, decimal amount)
    {
        decimal current = await GetCashAmount(accountId).ConfigureAwait(false);

        if (current < amount) throw new ArithmeticException();

        current -= amount;

        const string sql = """
                           update user_amount
                           set amount = :new_amount
                           where account_id = :account;

                           insert into transactions
                           values (:account, :operation_type, :amount, :operation_time)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("account", accountId);
        command.AddParameter("new_amount", current);
        command.AddParameter("operation_type", OperationType.Withdrawal);
        command.AddParameter("amount", amount);
        command.AddParameter("operation_time", DateTime.Now);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task Replenishment(long accountId, decimal amount)
    {
        decimal current = await GetCashAmount(accountId).ConfigureAwait(false);
        decimal newAmount = current + amount;

        const string sql = """
                           update user_amount
                           set amount = :new_amount
                           where account_id = :account;

                           insert into atm_history
                           values (:account, :operation_type, :amount, :operation_time);
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("operation_type", OperationType.Replenishment);
        command.AddParameter("account", accountId);
        command.AddParameter("new_amount", newAmount);
        command.AddParameter("amount", amount);
        command.AddParameter("operation_time", DateTime.Now);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<decimal> GetCashAmount(long accountId)
    {
        const string sql = """
                           select amount
                           from user_amount
                           where account_id = :account_id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("account_id", accountId);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (!await reader.ReadAsync().ConfigureAwait(false))
            throw new AuthenticationException();

        return reader.GetDecimal(0);
    }

    public async Task<IEnumerable<ITransaction>> GetTransactionHistory(long accountId)
    {
        const string sql = """
                           select * 
                           from atm_history
                           where account_id = :accountId
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync()
            .ConfigureAwait(false);

        var transactions = new List<ITransaction>();

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            transactions.Add(
                new Transaction(
                    await reader
                        .GetFieldValueAsync<OperationType>(1)
                        .ConfigureAwait(false),
                    reader.GetDecimal(2),
                    reader.GetDateTime(3)));
        }

        return transactions;
    }
}