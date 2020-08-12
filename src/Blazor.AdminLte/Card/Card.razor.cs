using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.AdminLte
{
    public partial class Card : ICard
    {
        [Parameter]
        public LoadingState LoadingState { get; set; }
        [Parameter]
        public CardToolOptions ToolOptions { get; set; }
        [Parameter]
        public CardType Type { get; set; }
        [Parameter]
        public Color HeaderBackgroundColor { get; set; }
        [Parameter]
        public CardStyle[] Styles { get; set; } = new CardStyle[] { };

        [Parameter]
        public RenderFragment Body { get; set; }
        [Parameter]
        public RenderFragment Header { get; set; }
        [Parameter]
        public RenderFragment Title { get; set; }

        private ElementReference CardReference { get; set; }

        private IDictionary<string, object> Attributes => GetAttributes();
        private string DisplayHeaderBackgroundColor => HeaderBackgroundColor.GetDescription<StyleAttribute>();
        private string DisplayCardType => Type.GetDescription<StyleAttribute>();
        private IDictionary<string, object> HeaderAttributes => GetHeaderAttributes();
        private bool IsTabs => Type == CardType.Tabs;

        private IDictionary<string, object> GetAttributes()
        {
            var attributes = new Dictionary<string, object>();
            attributes["class"] = "card";
            if (HeaderBackgroundColor != Color.Default)
            {
                attributes["class"] = $"{attributes["class"]} card-{DisplayHeaderBackgroundColor}";
            }
            if (ToolOptions?.Expandable ?? false)
            {
                attributes["class"] = $"{attributes["class"]} collapsed-card";
            }
            foreach (var cardStyle in Styles)
            {
                switch (cardStyle)
                {
                    case CardStyle.Outline:
                        attributes["class"] = $"{attributes["class"]} card-outline";
                        break;
                    case CardStyle.OutlineTabs:
                        attributes["class"] = $"{attributes["class"]} card-outline-tabs";
                        break;
                    case CardStyle.Solid:
                        attributes["class"] = $"{attributes["class"]} bg-{DisplayHeaderBackgroundColor}";
                        break;
                    case CardStyle.Primary:
                        attributes["class"] = $"{attributes["class"]} card-primary";
                        break;
                    case CardStyle.None:
                    default:
                        break;
                }
            }
            if (IsTabs)
            {
                attributes["class"] = $"{attributes["class"]} {DisplayCardType}";
            }

            return attributes;
        }

        private IDictionary<string, object> GetHeaderAttributes()
        {
            var attributes = new Dictionary<string, object>();
            attributes["class"] = "card-header";
            if (IsTabs)
            {
                attributes["class"] = $"{attributes["class"]} p-0";
                if (!Styles.ToList().Contains(CardStyle.OutlineTabs))
                {
                    attributes["class"] = $"{attributes["class"]} pt-1";
                }
                if (Styles.ToList().Contains(CardStyle.Outline))
                {
                    attributes["class"] = $"{attributes["class"]} border-bottom-0";
                }
            }

            return attributes;
        }
    }

    public class CardToolOptions
    {
        public bool Collapsable { get; set; }
        public bool Expandable { get; set; }
        public bool Maximizable { get; set; }
        public bool Removable { get; set; }
    }
}
