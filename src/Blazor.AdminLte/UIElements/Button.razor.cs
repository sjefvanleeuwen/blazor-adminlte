using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;

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

        [Parameter]
        public bool Disabled { get; set; }

        private IDictionary<string, object> Attributes => GetAttributes();

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

        private IDictionary<string, object> GetAttributes()
        {
            var attributes = new Dictionary<string, object>();
            attributes["type"] = "button";
            attributes["class"] = "btn";
            attributes["class"] = $"{attributes["class"]} btn-block";
            attributes["class"] = $"{attributes["class"]} {DisplayButtonType}";
            if (Color != Color.Default)
            {
                attributes["class"] = $"{attributes["class"]} btn-{DisplaySize}";
            }
            if (Disabled)
            {
                attributes["class"] = $"{attributes["class"]} disabled";
            }

            return attributes;
        }
    }
}
