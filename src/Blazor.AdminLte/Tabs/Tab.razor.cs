using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    partial class Tab
    {
        [CascadingParameter(Name = "ParentIdentifier")]
        public string ParentIdentifier { get; set; }

        [Parameter]
        public string ContentsIdentifier { get; set; }

        [Parameter]
        public bool IsActive { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private string CompositeIdentifier => $"{ParentIdentifier}_{ContentsIdentifier}";
    }
}
