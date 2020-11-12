using Microsoft.JSInterop;

namespace Blazor.AdminLte
{
    public class LayoutManager : ILayoutManager
    {
        private bool _IsSideBarFixed;
        private bool _IsNavBarFixed;
        private bool _IsFooterFixed;

        public bool IsSideBarFixed { get { return _IsSideBarFixed; } set { _IsSideBarFixed = value; js.InvokeVoidAsync("sideBarFixed", value); } }
        public bool IsNavBarFixed { get { return _IsNavBarFixed; } set { _IsNavBarFixed = value; js.InvokeVoidAsync("navBarFixed", value); } }
        public bool IsFooterFixed { get { return _IsFooterFixed; } set { _IsFooterFixed = value; js.InvokeVoidAsync("footerFixed", value); } }

        private readonly IJSRuntime js;

        public LayoutManager(IJSRuntime js)
        {
            this.js = js;
        }

        public void OverlayMode(bool isOverlayMode)
        {
            if (isOverlayMode)
            {
                js.InvokeVoidAsync("navBarFixed", false);
                js.InvokeVoidAsync("footerFixed", false);
            }
            else
            {
                js.InvokeVoidAsync("navBarFixed", _IsNavBarFixed);
                js.InvokeVoidAsync("footerFixed", _IsFooterFixed);
            }
        }
    }
}
