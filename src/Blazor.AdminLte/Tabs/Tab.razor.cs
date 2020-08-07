using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    partial class Tab
    {
        [Parameter]
        public string ContentsIdentifier { get; set; }
        [Parameter]
        public bool IsActive { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
