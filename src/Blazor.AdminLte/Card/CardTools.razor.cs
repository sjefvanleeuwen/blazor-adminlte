using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Blazor.AdminLte
{
    partial class CardTools : ICardTools
    {
        [CascadingParameter(Name = "ToolOptions")]
        public CardToolOptions ToolOptions { get; set; }

        [CascadingParameter(Name = "Parent")]
        public Card Parent { get; set; }

        [Parameter]
        public EventCallback<Tuple<ICardTools, MouseEventArgs>> OnRefresh { get; set; }
        [Parameter]
        public EventCallback<Tuple<ICardTools, MouseEventArgs>> OnMaximize { get; set; }
        [Parameter]
        public EventCallback<Tuple<ICardTools, MouseEventArgs>> OnRestore { get; set; }
        [Parameter]
        public EventCallback<Tuple<ICardTools, MouseEventArgs>> OnCollapse { get; set; }
        [Parameter]
        public EventCallback<Tuple<ICardTools, MouseEventArgs>> OnExpand { get; set; }
        [Parameter]
        public EventCallback<Tuple<ICardTools, MouseEventArgs>> OnRemove { get; set; }

        public bool IsMaximized { get; private set; } = false;

        public bool IsCollapsed { get; private set; } = false;

        public bool IsRemoved { get; private set; } = false;

        private bool ShowOnRefresh => OnRefresh.HasDelegate;

        private void DoOnRefresh(MouseEventArgs args)
        {
            OnRefresh.InvokeAsync(new Tuple<ICardTools, MouseEventArgs>(this, args));
        }

        private void DoOnMaximize(MouseEventArgs args)
        {
            IsMaximized = true;
            OnMaximize.InvokeAsync(new Tuple<ICardTools, MouseEventArgs>(this, args));
        }

        private void DoOnRestore(MouseEventArgs args)
        {
            IsMaximized = false;
            OnRestore.InvokeAsync(new Tuple<ICardTools, MouseEventArgs>(this, args));
        }

        private void DoOnCollapse(MouseEventArgs args)
        {
            IsCollapsed = true;
            OnCollapse.InvokeAsync(new Tuple<ICardTools, MouseEventArgs>(this, args));
        }

        private void DoOnExpand(MouseEventArgs args)
        {
            IsCollapsed = false;
            OnExpand.InvokeAsync(new Tuple<ICardTools, MouseEventArgs>(this, args));
        }

        private void DoOnRemove(MouseEventArgs args)
        {
            IsRemoved = true;
            OnRemove.InvokeAsync(new Tuple<ICardTools, MouseEventArgs>(this, args));
        }

        private CardToolOptions Options => ToolOptions ?? new CardToolOptions();

        [Parameter]
        public RenderFragment CustomTools { get; set; }

        protected override void OnInitialized()
        {
            //if (Parent == null)
            //    throw new ArgumentNullException(nameof(Parent), "CardTools must exist within a Card!");

            Parent.CardTools = this;
        }
    }
}
