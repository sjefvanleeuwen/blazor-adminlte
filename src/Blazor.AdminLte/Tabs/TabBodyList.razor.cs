using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    partial class TabBodyList
    {
        [Parameter]
        public string Identifier { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
