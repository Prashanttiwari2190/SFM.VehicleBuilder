using System;
using System.Data;
using System.Data.SqlClient;
using ChromeData;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SFM.VehicleBuilder.Data
{
    /// <summary>
    ///   Extension methods for <see cref="IServiceCollection"/> used to register dependencies with the IoC container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Registers all the application layer dependencies with the IoC container.
        /// </summary>
        /// <param name="services">The container service collection.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The populated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services

                // Fluent Migrator
                .AddFluentMigratorCore()
                    .ConfigureRunner(runner => runner
                        .AddSqlServer()
                        .WithGlobalConnectionString(configuration.GetConnectionString("SFM.VehicleBuilder"))
                        .ScanIn(typeof(AssemblyMarker).Assembly).For.EmbeddedResources()
                        .ScanIn(typeof(AssemblyMarker).Assembly).For.Migrations())
                .AddTransient<Migrator>()

                // DB Connections
                .AddTransient<IDbConnection>(OpenConnection)

                // Other
                .AddAutoMapper(typeof(AssemblyMarker))

            // Repositories

                .AddScoped(provider =>
                {
                    var accountInfo = new AccountInfo
                    {
                        accountNumber = configuration["ChromeData:accountNumber"],
                        accountSecret = configuration["ChromeData:accountSecret"],
                        locale = new Locale
                        {
                            country = "US",
                            language = "en",
                        },
                    };

                    return accountInfo;
                })

            // Http Clients

            // Web Services
            /*
            .AddScoped(() =>
            {
                var accountInfo = new AccountInfo
                {
                    accountNumber = "309700",
                    accountSecret = "sew700",
                };
                var client = new AutomotiveConfigCompareService4hPortTypeClient();
                return client;
            })
            */
            ;

            return services;
        }

        private static SqlConnection OpenConnection(IServiceProvider provider)
        {
            var connectionString = provider
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(ConnectionStrings.QuickbooksImport);

            var cnn = new SqlConnection(connectionString);
            cnn.Open();

            return cnn;
        }
    }
}