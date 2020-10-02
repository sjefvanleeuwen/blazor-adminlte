using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public partial class TableRow
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
