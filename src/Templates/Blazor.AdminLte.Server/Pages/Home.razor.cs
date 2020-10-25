using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte.Server.Pages
{
    public partial class Home
    {
        [Inject]
        NavBarLeftInjectableMenu menu { get; set; }
    }
}
