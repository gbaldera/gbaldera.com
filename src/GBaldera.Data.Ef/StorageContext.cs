using Microsoft.EntityFrameworkCore;

namespace GBaldera.Data.Ef
{
    public class StorageContext : DbContext
    {
        public StorageContext() { }
        public StorageContext(DbContextOptions options) : base(options)
        {
        }
    }
}
