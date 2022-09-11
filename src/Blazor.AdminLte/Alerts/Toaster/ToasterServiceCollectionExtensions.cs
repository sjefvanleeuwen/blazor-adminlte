using Blazor.AdminLte.Alerts.Toaster.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.AdminLte
{
    public static class ToasterServiceCollectionExtensions
    {
        public static IServiceCollection AddToast(this IServiceCollection services)
        {
            return services.AddScoped<IToastService, ToastService>();
        }
    }
}
