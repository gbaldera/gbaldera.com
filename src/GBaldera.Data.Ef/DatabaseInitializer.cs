using System.Collections.Generic;
using System.Threading.Tasks;
using GBaldera.Data.Abstractions;
using GBaldera.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GBaldera.Data.Ef
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly StorageContext _context;
        private readonly IConfiguration _configuration;
        private DataSeed _data;

        public DatabaseInitializer(StorageContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            _data = new DataSeed();
            configuration.GetSection("Data").Bind(_data);
        }

        public async Task SeedDataAsync()
        {
            if (_context.AllMigrationsApplied())
            {
                if (!await _context.Projects.AnyAsync())
                {
                    foreach (var project in _data.Projects)
                    {
                        _context.Projects.Add(project);
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

    internal class DataSeed
    {
        public List<Project> Projects { get; set; }
    }
}
