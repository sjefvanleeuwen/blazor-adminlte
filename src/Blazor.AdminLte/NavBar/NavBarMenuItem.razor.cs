using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;
using System;
using System.Dynamic;

namespace Blazor.AdminLte
{
    public partial class NavBarMenuItem : INavBarMenuItem
    {
        [Inject]
        public Microsoft.JSInterop.IJSRuntime JS { get; set; }
        [Parameter]
        public string Link { get; set; } = "";
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public EventCallback<Tuple<INavBarMenuItem, MouseEventArgs>> OnClick { get; set; }
        private void DoClick(MouseEventArgs args)
        {
            OnClick.InvokeAsync(new Tuple<INavBarMenuItem, MouseEventArgs>(this, args));
        }
    }

    public interface INavBarMenuItem
    {
        string Link { get; set; }
    }
}
