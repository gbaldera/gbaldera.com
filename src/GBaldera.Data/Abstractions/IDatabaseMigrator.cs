using System.Threading.Tasks;

namespace GBaldera.Data.Abstractions
{
    public interface IDatabaseMigrator 
    {
        Task MigrateAsync();
    }
}