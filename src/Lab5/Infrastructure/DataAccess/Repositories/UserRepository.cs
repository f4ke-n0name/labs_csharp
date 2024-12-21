using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using System.Security.Authentication;
using System.Security.Cryptography;
using Utils.Models.Contracts;
using Utils.Models.Enums;
using Utils.Models.Handlers;

namespace Infrastructure.DataAccess.Repositories;

public class UserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<IUserAccount> VerifyUser(long bankAccount, short pinCode)
    {
        const string sql = """
                           select account_id
                           from user_access
                           where bank_account = :bank_account
                           and pin_code = :pinCode
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("bankAccount", bankAccount);
        command.AddParameter("pinCode", pinCode);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        return !await reader.ReadAsync().ConfigureAwait(false)
            ? throw new AuthenticationException()
            : new UserAccount(reader.GetInt64(0), UserRole.User);
    }

    public async Task<IUserResult> SaveUser(string firstName, string lastName)
    {
        (long accountId, long bankAccount, short pinCode) = GenerateUserCredentials();

        const string sql = """
                           insert into accounts 
                           overriding system value 
                           values (:accountId, :firstName, :lastName, :user_role, :0);

                           insert into user_access 
                           overriding system value 
                           values (:accountId, :bankAccount, :pinCode);
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("accountId", accountId);
        command.AddParameter("firstName", firstName);
        command.AddParameter("lastName", lastName);
        command.AddParameter("bankAccount", bankAccount);
        command.AddParameter("pinCode", pinCode);
        command.AddParameter("userRole", UserRole.User);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        return new UserResult(bankAccount, pinCode);
    }

    private (long AccountId, long BankAccount, short PinCode) GenerateUserCredentials()
    {
        long accountId = GenerateUniqueId();
        long bankAccount = GenerateUniqueId();
        short pinCode = GenerateSecurePin();

        return (accountId, bankAccount, pinCode);
    }

    private long GenerateUniqueId()
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] randomBytes = new byte[8];
        rng.GetBytes(randomBytes);
        return BitConverter.ToInt64(randomBytes, 0) & 0x7FFFFFFFFFFFFFFF;
    }

    private short GenerateSecurePin()
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] randomBytes = new byte[2];
        rng.GetBytes(randomBytes);
        short pin = BitConverter.ToInt16(randomBytes, 0);
        return (short)(Math.Abs(pin) % 10000);
    }
}