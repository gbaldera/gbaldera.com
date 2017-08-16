using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GBaldera.Data.Ef
{
    public static class DbContextOptionsBuilderExtension
    {
        public static DbContextOptionsBuilder UseProviderFromConfig(this DbContextOptionsBuilder builder, 
            IConfiguration configuration)
        {
            var defaultProvider = configuration.GetValue("DefaultDataProvider", "");
            var connectionString = configuration.GetConnectionString(defaultProvider);
            var migrationsAssembly = $"GBaldera.Data.Ef.Migrations.{defaultProvider}";
            
            switch (defaultProvider)
            {
                case "MySql":
                    /*builder.UseMySql(connectionString, 
                        options => options.MigrationsAssembly(migrationAssenbly));*/
                    break;
                default:
                    builder.UseSqlite(connectionString, 
                    options => options.MigrationsAssembly(migrationsAssembly));
                    break;
            }
            return builder;
        }
    }
}