using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Blazor.AdminLte
{
    partial class CardTools : ICardTools
    {
        [CascadingParameter(Name = "ToolOptions")]
        public CardToolOptions ToolOptions { get; set; }
        
        [Parameter]
        public EventCallback<Tuple<ICardTools, MouseEventArgs>> OnRefresh { get; set; }

        private bool ShowOnRefresh => OnRefresh.HasDelegate;

        private void DoOnRefresh(MouseEventArgs args)
        {
            OnRefresh.InvokeAsync(new Tuple<ICardTools, MouseEventArgs>(this, args));
        }

        private CardToolOptions Options => ToolOptions ?? new CardToolOptions();

        [Parameter]
        public RenderFragment CustomTools { get; set; }
    }
}
