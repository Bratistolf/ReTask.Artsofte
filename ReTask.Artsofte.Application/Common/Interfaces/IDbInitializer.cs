using Microsoft.Extensions.Configuration;

namespace ReTask.Artsofte.Application.Common.Interfaces
{
    public interface IDbInitializer
    {
        void Initialize(IConfiguration configuration);
        void SeedData();
    }
}
