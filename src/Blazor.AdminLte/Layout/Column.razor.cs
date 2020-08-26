using Microsoft.AspNetCore.Components;
using System.Text;

namespace Blazor.AdminLte
{
    public static class col
    {
        public static FluentColumn _ { get { return new FluentColumn(""); } }
        public static FluentColumn xs { get { return new FluentColumn("-xs"); } }
        public static FluentColumn sm { get { return new FluentColumn("-sm"); } }
        public static FluentColumn md { get { return new FluentColumn("-md"); } }
        public static FluentColumn lg { get { return new FluentColumn("-lg"); } }
        public static FluentColumn xl { get { return new FluentColumn("-xl"); } }

        public static FluentColumn _1  { get { return new FluentColumn("-1"); } }
        public static FluentColumn _2  { get { return new FluentColumn("-2"); } }
        public static FluentColumn _3  { get { return new FluentColumn("-3"); } }
        public static FluentColumn _4  { get { return new FluentColumn("-4"); } }
        public static FluentColumn _5  { get { return new FluentColumn("-5"); } }
        public static FluentColumn _6  { get { return new FluentColumn("-6"); } }
        public static FluentColumn _7  { get { return new FluentColumn("-7"); } }
        public static FluentColumn _8  { get { return new FluentColumn("-8"); } }
        public static FluentColumn _9  { get { return new FluentColumn("-9"); } }
        public static FluentColumn _10 { get { return new FluentColumn("-10"); } }
        public static FluentColumn _11 { get { return new FluentColumn("-11"); } }
        public static FluentColumn _12 { get { return new FluentColumn("-12"); } }
        public static FluentColumn auto{ get { return new FluentColumn("-auto"); } }
        public static FluentColumn w25 { get { return new FluentColumn("w-100", ""); } }
        public static FluentColumn w50 { get { return new FluentColumn("w-100", ""); } }
        public static FluentColumn w75 { get { return new FluentColumn("w-100", ""); } }
        public static FluentColumn w100 { get { return new FluentColumn("w-100", ""); } }
    }

    public partial class Column
    {
        [Parameter]
        public object Classes { 
            get
            { 
                return classes; 
            } set 
            { 
                classes = value.ToString(); 
            }  
        }

        public string classes { get; set; } = "";

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }

    public class FluentClass
    {
        public override string ToString()
        {
            return _class.ToString();
        }

        internal StringBuilder _class { get; set; }
    }

    public class FluentColumn : FluentClass
    {
        public FluentColumn(string s, string col="col")
        {
            this._class = new StringBuilder();
            _class.Append(col + s);
        }

        public FluentColumn()
        {
            this._class = new StringBuilder();
            _class.Append("col");
        }
        public FluentColumn(FluentClass root)
        {
            this._class = root._class;
           
        }

        public FluentColumn xs { get { _class.Append("-xs"); return new FluentColumn(this); } }
        public FluentColumn sm { get { _class.Append("-sm"); return new FluentColumn(this); } }
        public FluentColumn md { get { _class.Append("-md"); return new FluentColumn(this); } }
        public FluentColumn lg { get { _class.Append("-lg"); return new FluentColumn(this); } }
        public FluentColumn xl { get { _class.Append("-xl"); return new FluentColumn(this); } }

        public FluentColumn none { get { _class.Append(""); return new FluentColumn(this); } }
        public FluentColumn _1 { get { _class.Append("-1"); return new FluentColumn(this); } }
        public FluentColumn _2 { get { _class.Append("-2"); return new FluentColumn(this); } }
        public FluentColumn _3 { get { _class.Append("-3"); return new FluentColumn(this); } }
        public FluentColumn _4 { get { _class.Append("-4"); return new FluentColumn(this); } }
        public FluentColumn _5 { get { _class.Append("-5"); return new FluentColumn(this); } }
        public FluentColumn _6 { get { _class.Append("-6"); return new FluentColumn(this); } }
        public FluentColumn _7 { get { _class.Append("-7"); return new FluentColumn(this); } }
        public FluentColumn _8 { get { _class.Append("-8"); return new FluentColumn(this); } }
        public FluentColumn _9 { get { _class.Append("-9"); return new FluentColumn(this); } }
        public FluentColumn _10 { get { _class.Append("-10"); return new FluentColumn(this); } }
        public FluentColumn _11 { get { _class.Append("-11"); return new FluentColumn(this); } }
        public FluentColumn _12 { get { _class.Append("-12"); return new FluentColumn(this); } }
        public FluentColumn auto { get { _class.Append("-auto"); return new FluentColumn(this); } }
        public FluentColumn col { get { _class.Append(" col"); return new FluentColumn(this); } }
    }
}
