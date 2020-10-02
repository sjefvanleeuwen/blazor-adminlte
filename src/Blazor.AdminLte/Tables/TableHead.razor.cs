using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public partial class TableHead
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
