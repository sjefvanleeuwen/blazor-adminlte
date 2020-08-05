using Microsoft.Extensions.DependencyInjection;

namespace Blazor.AdminLte
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminLte(this IServiceCollection services)
        {
            return services.AddScoped<NavBarLeftInjectableMenu>();
        }
    }
}
