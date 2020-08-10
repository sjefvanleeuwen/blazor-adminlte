using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Blazor.AdminLte
{
    partial class Tab
    {
        [CascadingParameter(Name = "ParentIdentifier")]
        public string ParentIdentifier { get; set; }
        [CascadingParameter(Name = "ControlleredByBlazor")]
        public bool ControlleredByBlazor { get; set; }

        [Parameter]
        public string ContentsIdentifier { get; set; }
        [Parameter]
        public bool IsActive { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback OnClick { get; set; }

        private string CompositeIdentifier => $"{ParentIdentifier}_{ContentsIdentifier}{(ControlleredByBlazor ? "_" : string.Empty)}";
    }
}
