using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public partial class Table
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public ElementReference TableReference { get; set; }
    }
}
