using Microsoft.AspNetCore.Components;
using System.Text;

namespace Blazor.AdminLte
{
    public partial class Progress
    {
        [Parameter]
        public double Percentage { get; set; }
    }

    public static class progress
    {
        public static FluentProgress _ { get { return new FluentProgress(""); } }
        public static FluentProgress @default { get { return new FluentProgress(" bg-default"); } }
        public static FluentProgress danger { get { return new FluentProgress(" bg-danger"); } }
        public static FluentProgress warning { get { return new FluentProgress(" bg-warning"); } }
        public static FluentProgress primary { get { return new FluentProgress(" bg-primary"); } }
        public static FluentProgress secondary { get { return new FluentProgress(" bg-secondary"); } }
        public static FluentProgress info { get { return new FluentProgress(" bg-info"); } }
        public static FluentProgress success { get { return new FluentProgress(" bg-success"); } }
        public static FluentProgress black { get { return new FluentProgress(" bg-black"); } }
        public static FluentProgress gray_dark { get { return new FluentProgress(" bg-gray-dark"); } }
        public static FluentProgress gray { get { return new FluentProgress(" bg-gray"); } }
        public static FluentProgress light { get { return new FluentProgress(" bg-light"); } }
        public static FluentProgress indigo { get { return new FluentProgress(" bg-indigo"); } }
        public static FluentProgress navy { get { return new FluentProgress(" bg-navy"); } }
        public static FluentProgress purple { get { return new FluentProgress(" bg-purple"); } }
        public static FluentProgress fuchsia { get { return new FluentProgress(" bg-fuchsia"); } }
        public static FluentProgress pink { get { return new FluentProgress(" bg-pink"); } }
        public static FluentProgress maroon { get { return new FluentProgress(" bg-maroon"); } }
        public static FluentProgress orange { get { return new FluentProgress(" bg-orange"); } }
        public static FluentProgress lime { get { return new FluentProgress(" bg-lime"); } }
        public static FluentProgress teal { get { return new FluentProgress(" bg-teal"); } }
        public static FluentProgress olive { get { return new FluentProgress(" bg-olive"); } }
        public static FluentProgress white { get { return new FluentProgress(" bg-white"); } }
    }

    public class FluentProgress : FluentClass
    {
        public FluentProgress(string s, string col = "progress-bar")
        {
            this._class = new StringBuilder();
            _class.Append(col + s);
        }

        public FluentProgress()
        {
            this._class = new StringBuilder();
            _class.Append("col");
        }
        public FluentProgress(FluentClass root)
        {
            this._class = root._class;

        }

        public FluentProgress _ { get { return new FluentProgress(""); } }
        public FluentProgress @default { get { return new FluentProgress(" bg-default"); } }
        public FluentProgress danger { get { return new FluentProgress(" bg-danger"); } }
        public FluentProgress warning { get { return new FluentProgress(" bg-warning"); } }
        public FluentProgress primary { get { return new FluentProgress(" bg-primary"); } }
        public FluentProgress secondary { get { return new FluentProgress(" bg-secondary"); } }
        public FluentProgress info { get { return new FluentProgress(" bg-info"); } }
        public FluentProgress success { get { return new FluentProgress(" bg-success"); } }
        public FluentProgress black { get { return new FluentProgress(" bg-black"); } }
        public FluentProgress gray_dark { get { return new FluentProgress(" bg-gray-dark"); } }
        public FluentProgress gray { get { return new FluentProgress(" bg-gray"); } }
        public FluentProgress light { get { return new FluentProgress(" bg-light"); } }
        public FluentProgress indigo { get { return new FluentProgress(" bg-indigo"); } }
        public FluentProgress navy { get { return new FluentProgress(" bg-navy"); } }
        public FluentProgress purple { get { return new FluentProgress(" bg-purple"); } }
        public FluentProgress fuchsia { get { return new FluentProgress(" bg-fuchsia"); } }
        public FluentProgress pink { get { return new FluentProgress(" bg-pink"); } }
        public FluentProgress maroon { get { return new FluentProgress(" bg-maroon"); } }
        public FluentProgress orange { get { return new FluentProgress(" bg-orange"); } }
        public FluentProgress lime { get { return new FluentProgress(" bg-lime"); } }
        public FluentProgress teal { get { return new FluentProgress(" bg-teal"); } }
        public FluentProgress olive { get { return new FluentProgress(" bg-olive"); } }
        public FluentProgress white { get { return new FluentProgress(" bg-white"); } }

    }
}