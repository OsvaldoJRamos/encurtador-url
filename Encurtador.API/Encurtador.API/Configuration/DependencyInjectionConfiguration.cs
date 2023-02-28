using Encurtador.Data.Repositories;
using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Service;

namespace Encurtador.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEncurtarService, EncurtarService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEncurtarRepository, EncurtarRepository>();
        }
    }
}
