using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PP.Common.Shared.Exceptions;
using PP.Template.Infrastructure;

namespace PP.Tools.Database
{
    public static class MigrationHandler
    {
        const string ConnectionStringName = "PP.Template.Api:ConnectionString";

        public static ServiceProvider AddMigrationService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string? connectionString = configuration[ConnectionStringName];
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new MissingSqlConnectionStringException(ConnectionStringName);
            }
           
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(IInfrastructureMarker).Assembly).For.Migrations())

                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        public static void Up(this IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        public static void Down(this IServiceProvider serviceProvider, long version)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(version);
        }
    }
}
