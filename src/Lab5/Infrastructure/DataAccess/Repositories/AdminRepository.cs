using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using System.Security.Authentication;
using System.Security.Cryptography;
using Utils.Models.Contracts;
using Utils.Models.Enums;
using Utils.Models.Handlers;

namespace Infrastructure.DataAccess.Repositories;

public class AdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<IUserAccount> VerifyAdmin(string password)
    {
        const string sql = """
                           select account_id
                           from admin_access
                           and passwd = :passwd;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("passwd", password);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        return !await reader.ReadAsync().ConfigureAwait(false)
            ? throw new AuthenticationException()
            : new UserAccount(reader.GetInt64(0), UserRole.Admin);
    }

    public async Task SaveAdmin(string firstName, string lastName, string password)
    {
        long accountId = GenerateAccountId();

        const string sql = """
                           insert into accounts
                           overriding system value
                           values (:accountId, :firstName, :lastName, :user_role, :0);

                           insert into admin_access
                           overriding system value
                           values (:accountId, :passwd);
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("accountId", accountId);
        command.AddParameter("firstName", firstName);
        command.AddParameter("lastName", lastName);
        command.AddParameter("password", password);
        command.AddParameter("userRole", UserRole.Admin);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    private long GenerateAccountId()
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] randomBytes = new byte[8];
        rng.GetBytes(randomBytes);
        return BitConverter.ToInt64(randomBytes, 0) & 0x7FFFFFFFFFFFFFFF;
    }
}