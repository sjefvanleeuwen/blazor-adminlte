using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public class CustomCheckboxState
    {
        public bool? IsChecked { get; set; }
        public bool IsDisabled { get; set; }
        public string Value { get; set; }
        public string Identifier { get; set; }
        public string Label { get; set; }
    }
}
