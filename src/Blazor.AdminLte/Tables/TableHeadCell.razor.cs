using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public partial class TableHeadCell
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
