using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.AdminLte
{
    public interface ICardTools
    {
        EventCallback<System.Tuple<ICardTools, MouseEventArgs>> OnRefresh { get; set; }
        CardToolOptions ToolOptions { get; set; }
        RenderFragment CustomTools { get; }
    }
}