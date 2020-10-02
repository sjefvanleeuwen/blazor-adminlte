using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public partial class TableBody
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
