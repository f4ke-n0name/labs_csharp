using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    CREATE TYPE user_role AS ENUM (
        'admin',
        'user'
    );
    
    CREATE TYPE operation_type AS ENUM (
        'withdrawal',
        'replenishment'
    );
    
    CREATE TABLE accounts (
        account_id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
        account_name TEXT NOT NULL,
        account_last_name TEXT NOT NULL,
        account_role user_role NOT NULL,
        amount MONEY NOT NULL
    );
    
    CREATE TABLE user_access (
        account_id BIGINT NOT NULL REFERENCES accounts(account_id),
        bank_account BIGINT NOT NULL,
        pin_code SMALLINT NOT NULL,
    
        PRIMARY KEY (account_id, bank_account)
    );
    
    CREATE TABLE admin_access (
        account_id BIGINT NOT NULL REFERENCES accounts(account_id),
        admin_password TEXT NOT NULL,
    
        PRIMARY KEY (account_id)
    );
    
    CREATE TABLE transactions (
        account_id BIGINT NOT NULL REFERENCES accounts(account_id),
        operation operation_type NOT NULL,
        amount MONEY NOT NULL,
        operation_time TIMESTAMP,
    
        PRIMARY KEY (account_id, operation_time)
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
        drop table accounts;
        drop table user_access;
        drop table admin_access;
        drop table transactions;
    
        drop type user_role;
        drop type operation_type;
    """;
}