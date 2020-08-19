using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    public partial class CustomCheckbox
    {
        [Parameter]
        public CustomCheckboxState State { get; set; }

        [Parameter]
        public EventCallback<CustomCheckboxState> StateChanged { get; set; }

        [Parameter]
        public EventCallback<CustomCheckboxState> OnChange { get; set; }

        private void DoChange(ChangeEventArgs e)
        {
            State.IsChecked = (bool?)e.Value;
            StateChanged.InvokeAsync(State);
            if (OnChange.HasDelegate)
              OnChange.InvokeAsync(State);
        }
    }
}
