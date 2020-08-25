using Microsoft.AspNetCore.Components;
using System.Text;

namespace Blazor.AdminLte
{


    public partial class Column
    {
        public static FluentColumn Class { get { return new FluentColumn(); } }

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
        public FluentColumn()
        {
            this._class = new StringBuilder();
            _class.Append("col");
        }
        public FluentColumn(FluentClass root)
        {
            this._class = root._class;
           
        }
        public IFluentColumnSize Size { get { return new IFluentColumnSize(this); } }
        public IFluentColumnWidth Width { get { return new IFluentColumnWidth(this); } }
    }

    public class IFluentColumnWidth : FluentClass
    {
        public IFluentColumnWidth(FluentClass root)
        {
            this._class = root._class;
        }

        public FluentColumn None      { get { _class.Append("");      return new FluentColumn(this); } }
        public FluentColumn One       { get { _class.Append("-1");    return new FluentColumn(this); } }
        public FluentColumn Two       { get { _class.Append("-2");    return new FluentColumn(this); } }
        public FluentColumn Three     { get { _class.Append("-3");    return new FluentColumn(this); } }
        public FluentColumn Four      { get { _class.Append("-4");    return new FluentColumn(this); } }
        public FluentColumn Five      { get { _class.Append("-5");    return new FluentColumn(this); } }
        public FluentColumn Six       { get { _class.Append("-6");    return new FluentColumn(this); } }
        public FluentColumn Seven     { get { _class.Append("-7");    return new FluentColumn(this); } }
        public FluentColumn Eight     { get { _class.Append("-8");    return new FluentColumn(this); } }
        public FluentColumn Nine      { get { _class.Append("-9");    return new FluentColumn(this); } }
        public FluentColumn Ten       { get { _class.Append("-10");   return new FluentColumn(this); } }
        public FluentColumn Eleven    { get { _class.Append("-11");   return new FluentColumn(this); } }
        public FluentColumn Twelve    { get { _class.Append("-12");   return new FluentColumn(this); } }
        public FluentColumn Auto      { get { _class.Append("-auto"); return new FluentColumn(this); } }
        }

    public class IFluentColumnSize : FluentClass
    {
        public IFluentColumnSize(FluentClass root)
        {
            this._class = root._class;
        }

        public FluentColumn ExtraSmall { get { _class.Append("");    return new FluentColumn(this); } }
        public FluentColumn Small      { get { _class.Append("-sm"); return new FluentColumn(this); } }
        public FluentColumn Medium     { get { _class.Append("-md"); return new FluentColumn(this); } }
        public FluentColumn Large      { get { _class.Append("-lg"); return new FluentColumn(this); } }
        public FluentColumn ExtraLarge { get { _class.Append("-xl"); return new FluentColumn(this); } }
    }
}
