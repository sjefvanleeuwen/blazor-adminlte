using BlazorState;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blazor.AdminLte
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminLte(this IServiceCollection services)
        {
            return services
                .AddScoped<NavBarLeftInjectableMenu>()
                .AddScoped<IPlayerService, PlayerService>()
                .AddBlazorState((aOptions) =>
                 aOptions.Assemblies = new Assembly[]
                 {
                    typeof(BaseClasses).GetTypeInfo().Assembly,
                    Assembly.GetExecutingAssembly()
                 }

            ).AddScoped<ILayoutManager, LayoutManager>().AddToast();
        }
    }
}
