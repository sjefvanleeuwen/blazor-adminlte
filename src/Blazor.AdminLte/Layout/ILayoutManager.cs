namespace Blazor.AdminLte
{
    public interface ILayoutManager
    {
        bool IsFooterFixed { get; set; }
        bool IsNavBarFixed { get; set; }
        bool IsSideBarFixed { get; set; }

        void OverlayMode(bool isOverlayMode);
    }
}