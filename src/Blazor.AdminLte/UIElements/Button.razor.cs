using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.AdminLte
{
    public partial class Button
    {
        [Parameter]
        public ButtonSize Size { get; set; }
        [Parameter]
        public ButtonType Type { get; set; }
        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        private async void DoOnClick(MouseEventArgs e)
        {
            if (OnClick.HasDelegate)
                await OnClick.InvokeAsync(e);
        }

        private string DisplaySize =>
            Size == ButtonSize.Normal ?
            string.Empty :
            $"{Size.GetDescription<StyleAttribute>()}";
        private string DisplayColor =>
            Color == Color.Default ?
            "default" :
            $"{Color.GetDescription<StyleAttribute>()}";
        public string DisplayButtonType {
            get {
                switch (Type) {
                    case ButtonType.Outline:
                        return $"btn-{Type.GetDescription<StyleAttribute>()}-{DisplayColor}";
                    case ButtonType.Gradient:
                        return $"bg-{Type.GetDescription<StyleAttribute>()}-{DisplayColor}";
                    default:
                        break;
                }
                return $"btn-{DisplayColor}";
            } 
        }
    }
}
