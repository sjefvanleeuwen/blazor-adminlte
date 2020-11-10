using BlazorState;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blazor.AdminLte
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminLte(this IServiceCollection services)
        {
            return services.AddScoped<NavBarLeftInjectableMenu>().AddBlazorState((aOptions) =>
                 aOptions.Assemblies = new Assembly[]
                 {
                    typeof(BaseClasses).GetTypeInfo().Assembly,
                    Assembly.GetExecutingAssembly()
                 }
            );
        }
    }
}
