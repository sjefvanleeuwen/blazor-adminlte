using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    partial class TabBodyItem
    {
        [Parameter]
        public string Identifier { get; set; }
        [Parameter]
        public bool IsActive { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
