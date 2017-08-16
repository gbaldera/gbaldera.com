using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GBaldera.Data.Abstractions;

namespace GBaldera.Data.Ef 
{
    public class DatabaseMigrator : IDatabaseMigrator 
    {
        private readonly StorageContext _context;

        public DatabaseMigrator(StorageContext context)
        {
            _context = context;
        }

        public async Task MigrateAsync()
        {
            await _context.Database.MigrateAsync();
        }
    }
}