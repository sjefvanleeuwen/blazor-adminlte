using Microsoft.AspNetCore.Components;
using System.Text;

namespace Blazor.AdminLte
{
    public partial class Badge
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }

    public static class badge
    {
        public static FluentBadge right { get { return new FluentBadge("badge","right"); } }

        public static FluentBadge _ { get { return new FluentBadge(""); } }
        public static FluentBadge @default { get { return new FluentBadge(" badge-default"); } }
        public static FluentBadge danger { get { return new FluentBadge(" badge-danger"); } }
        public static FluentBadge warning { get { return new FluentBadge(" badge-warning"); } }
        public static FluentBadge primary { get { return new FluentBadge(" badge-primary"); } }
        public static FluentBadge secondary { get { return new FluentBadge(" badge-secondary"); } }
        public static FluentBadge info { get { return new FluentBadge(" badge-info"); } }
        public static FluentBadge success { get { return new FluentBadge(" badge-success"); } }
        public static FluentBadge black { get { return new FluentBadge(" badge-black"); } }
        public static FluentBadge gray_dark { get { return new FluentBadge(" badge-gray-dark"); } }
        public static FluentBadge gray { get { return new FluentBadge(" badge-gray"); } }
        public static FluentBadge light { get { return new FluentBadge(" badge-light"); } }
        public static FluentBadge indigo { get { return new FluentBadge(" badge-indigo"); } }
        public static FluentBadge navy { get { return new FluentBadge(" badge-navy"); } }
        public static FluentBadge purple { get { return new FluentBadge(" badge-purple"); } }
        public static FluentBadge fuchsia { get { return new FluentBadge(" badge-fuchsia"); } }
        public static FluentBadge pink { get { return new FluentBadge(" badge-pink"); } }
        public static FluentBadge maroon { get { return new FluentBadge(" badge-maroon"); } }
        public static FluentBadge orange { get { return new FluentBadge(" badge-orange"); } }
        public static FluentBadge lime { get { return new FluentBadge(" badge-lime"); } }
        public static FluentBadge teal { get { return new FluentBadge(" badge-teal"); } }
        public static FluentBadge olive { get { return new FluentBadge(" badge-olive"); } }
        public static FluentBadge white { get { return new FluentBadge(" badge-white"); } }
    }

    public class FluentBadge : FluentClass
    {
        public FluentBadge(string s, string col = "badge")
        {
            this._class = new StringBuilder();
            _class.Append(col + s);
        }

        public FluentBadge()
        {
            this._class = new StringBuilder();
            _class.Append("col");
        }
        public FluentBadge(FluentClass root)
        {
            this._class = root._class;

        }

        public FluentBadge _ { get { return new FluentBadge(""); } }
        public FluentBadge @default { get { return new FluentBadge(" badge-default"); } }
        public FluentBadge danger { get { return new FluentBadge(" badge-danger"); } }
        public FluentBadge warning { get { return new FluentBadge(" badge-warning"); } }
        public FluentBadge primary { get { return new FluentBadge(" badge-primary"); } }
        public FluentBadge secondary { get { return new FluentBadge(" badge-secondary"); } }
        public FluentBadge info { get { return new FluentBadge(" badge-info"); } }
        public FluentBadge success { get { return new FluentBadge(" badge-success"); } }
        public FluentBadge black { get { return new FluentBadge(" badge-black"); } }
        public FluentBadge gray_dark { get { return new FluentBadge(" badge-gray-dark"); } }
        public FluentBadge gray { get { return new FluentBadge(" badge-gray"); } }
        public FluentBadge light { get { return new FluentBadge(" badge-light"); } }
        public FluentBadge indigo { get { return new FluentBadge(" badge-indigo"); } }
        public FluentBadge navy { get { return new FluentBadge(" badge-navy"); } }
        public FluentBadge purple { get { return new FluentBadge(" badge-purple"); } }
        public FluentBadge fuchsia { get { return new FluentBadge(" badge-fuchsia"); } }
        public FluentBadge pink { get { return new FluentBadge(" badge-pink"); } }
        public FluentBadge maroon { get { return new FluentBadge(" badge-maroon"); } }
        public FluentBadge orange { get { return new FluentBadge(" badge-orange"); } }
        public FluentBadge lime { get { return new FluentBadge(" badge-lime"); } }
        public FluentBadge teal { get { return new FluentBadge(" badge-teal"); } }
        public FluentBadge olive { get { return new FluentBadge(" badge-olive"); } }
        public FluentBadge white { get { return new FluentBadge(" badge-white"); } }

    }
}
