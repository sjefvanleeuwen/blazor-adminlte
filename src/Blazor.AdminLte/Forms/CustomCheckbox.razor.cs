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
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { get; set; }

        private async void DoChange(ChangeEventArgs e)
        {
            if (OnChange.HasDelegate)
                await OnChange.InvokeAsync(e);
        }
    }
}
