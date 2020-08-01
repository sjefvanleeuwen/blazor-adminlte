using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Blazor.AdminLte
{
    public interface ICard
    {
        bool Collapsable { get; set; }
        RenderFragment Contents { get; set; }
        bool Expandable { get; set; }
        Color HeaderBackgroundColor { get; set; }
        bool Maximizable { get; set; }
        EventCallback<Tuple<ICard, MouseEventArgs>> OnRefresh { get; set; }
        bool Removable { get; set; }
        RenderFragment Title { get; set; }
        LoadingState LoadingState { get; set; }
        CardStyle CardStyle { get; set; }
    }
}