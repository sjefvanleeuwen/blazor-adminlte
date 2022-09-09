using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.AdminLte
{
    public partial class Alert
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public bool IsLight { get; set; }
        [Parameter]
        public bool IsDismissible { get; set; }
        [Parameter]
        public RenderFragment @ChildContent { get; set; }
        [Parameter]
        public AlertType Type { get; set; }
        [Parameter]
        public EventCallback OnDismissed { get; set; }

        private IDictionary<string, object> Attributes => GetAttributes();
        private string DisplayBackgroundColor => Type.GetDescription<StyleAttribute>();
        private IDictionary<string, object> IconAttributes => GetIconAttributes();
     
        private IDictionary<string, object> GetAttributes()
        {
            var attributes = new Dictionary<string, object>();
            attributes["class"] = "alert";

            if (IsLight)
            {
                attributes["class"] = $"{attributes["class"]} alert-default-{DisplayBackgroundColor}";
            }
            else
            {
                attributes["class"] = $"{attributes["class"]} alert-{DisplayBackgroundColor}";
            }
            
            if (IsDismissible)
            {
                attributes["class"] = $"{attributes["class"]} alert-dismissible";
            }
           
            return attributes;
        }

        private IDictionary<string, object> GetIconAttributes()
        {
            var attributes = new Dictionary<string, object>();
            switch (Type)
            {
                case AlertType.Danger:
                    attributes["class"] = "icon fas fa-ban";
                    break;
                case AlertType.Info:
                    attributes["class"] = "icon fas fa-info";
                    break;
                case AlertType.Warning:
                    attributes["class"] = "icon fas fa-exclamation-triangle";
                    break;
                case AlertType.Success:
                    attributes["class"] = "icon fas fa-check";
                    break;
            }

            if (IsLight)
            {
                attributes["class"] = $"{attributes["class"]} text-{DisplayBackgroundColor}";
            }

            return attributes;
        }

        private async Task HandleOnClick()
        {
            await OnDismissed.InvokeAsync();
        }
    }
}
