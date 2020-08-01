using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Blazor.AdminLte
{
    public partial class Card : ICard
    {
        [Parameter]
        public bool Expandable { get; set; }
        [Parameter]
        public bool Collapsable { get; set; }
        [Parameter]
        public bool Removable { get; set; }
        [Parameter]
        public bool Maximizable { get; set; }
        [Parameter]
        public LoadingState LoadingState { get; set; }

        private ElementReference card { get; set; }
        [Parameter]
        public RenderFragment Title { get; set; }
        [Parameter]
        public RenderFragment Contents { get; set; }

        [Parameter]
        public Color HeaderBackgroundColor { get; set; }

        [Parameter]
        public CardStyle CardStyle { get; set; }

        private string headerBackgroundColor => HeaderBackgroundColor.GetDescription<StyleAttribute>();

        private void onRefresh(MouseEventArgs args)
        {
            OnRefresh.InvokeAsync(new Tuple<ICard, MouseEventArgs>(this, args));
        }

        [Parameter]
        public EventCallback<Tuple<ICard, MouseEventArgs>> OnRefresh { get; set; }

    }
}
