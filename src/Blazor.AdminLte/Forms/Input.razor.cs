using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public partial class Input
    {
        [Parameter]
        public InputState Value { get; set; }

        [Parameter]
        public EventCallback<InputState> ValueChanged { get; set; }

        [Parameter]
        public EventCallback<InputState> OnChange { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }
        
        [Parameter]
        public bool IsReadOnly { get; set; }
        
        private void DoChange(ChangeEventArgs e)
        {
            Value.Value = (string)e.Value;
            ValueChanged.InvokeAsync(Value);
            if (OnChange.HasDelegate)
                OnChange.InvokeAsync(Value);
        }

        private IDictionary<string, object> GetAttributes()
        {
            var attributes = InputAttributes ?? new Dictionary<string, object>();
            if (IsReadOnly)
            {
                attributes["readonly"] = "readonly";
            }

            return attributes;
        }
    }
}
