using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public partial class TableCell
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
