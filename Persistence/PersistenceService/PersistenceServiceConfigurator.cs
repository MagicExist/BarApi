using BarApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.PersistenceService
{
    public static class PersistenceServiceConfigurator
    {
        public static IServiceCollection PersistenceService(this IServiceCollection serivce, IConfiguration configuration)
        {
            serivce.AddDbContext<DbContextBeer>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
            return serivce;
        }
    }
}
