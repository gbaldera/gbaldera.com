using System.Threading.Tasks;

namespace GBaldera.Data.Abstractions
{
    public interface IDatabaseInitializer
    {
        Task SeedDataAsync();
    }
}
