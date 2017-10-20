using Microsoft.AspNetCore.Builder;
using GBaldera.Data.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GBaldera.Web.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder builder)
        {
            MigrateAndSeedDatabase(builder.ApplicationServices).GetAwaiter().GetResult();
            return builder;
        }

        private static async Task MigrateAndSeedDatabase(IServiceProvider provider) 
        {
            using (var scope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var migrator = scope.ServiceProvider.GetRequiredService<IDatabaseMigrator>();
                var initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("ApplicationBuilderExtension");

                try
                {
                    await migrator.MigrateAsync();
                    await initializer.SeedDataAsync();
                }
                catch (Exception exception)
                {
                    logger.LogError(new EventId(10000), exception, exception.Message);
                }
            }
        }
    }
}