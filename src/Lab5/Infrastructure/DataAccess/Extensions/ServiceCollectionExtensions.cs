using Infrastructure.DataAccess.Plugins;
using Infrastructure.DataAccess.Repositories;
using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Services.BankAdapter;
using Services.BankServices;
using Utils.Models.Contracts;

namespace Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatform();
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IDbRepository, DbRepository>();
        collection.AddScoped<IBankServiceRepository, BankServiceRepository>();

        return collection;
    }

    public static IServiceCollection AddApiService(
        this IServiceCollection collection)
    {
        collection.AddScoped<IBankService, BankService>();
        collection.AddScoped<IBankServiceState, UnauthorizedState>();

        return collection;
    }
}