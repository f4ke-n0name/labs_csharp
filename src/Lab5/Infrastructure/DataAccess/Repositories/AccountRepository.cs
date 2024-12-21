using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class AccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<long> GetUserIdByBankAccount(long bankAccount)
    {
        const string sql = """
                           select account_id
                           from user_access
                           where bank_account = :bankAccount;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("bankAccount", bankAccount);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        return !await reader.ReadAsync().ConfigureAwait(false) ? throw new ApplicationException() : reader.GetInt64(0);
    }
}