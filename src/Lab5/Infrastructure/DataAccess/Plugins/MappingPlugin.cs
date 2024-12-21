using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;
using System.Diagnostics.CodeAnalysis;
using Utils.Models.Enums;

namespace Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure([NotNull] NpgsqlDataSourceBuilder builder)
    {
        builder
            .MapEnum<UserRole>()
            .MapEnum<OperationType>();
    }
}