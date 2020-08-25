using Microsoft.AspNetCore.Components;
using System.Text;

namespace Blazor.AdminLte
{


    public partial class Column
    {
        public static IFluentColumn Class { get { return new IFluentColumn(); } }

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

    public class IFluentClass
    {
        public override string ToString()
        {
            return _class.ToString();
        }

        internal StringBuilder _class { get; set; }
    }

    public class IFluentColumn : IFluentClass
    {
        public IFluentColumn()
        {
            this._class = new StringBuilder();
            _class.Append("col");
        }
        public IFluentColumn(IFluentClass root)
        {
            this._class = root._class;
           
        }
        public IFluentColumnSize Size { get { return new IFluentColumnSize(this); } }
        public IFluentColumnWidth Width { get { return new IFluentColumnWidth(this); } }
    }

    public class IFluentColumnWidth : IFluentClass
    {
        public IFluentColumnWidth(IFluentClass root)
        {
            this._class = root._class;
        }

        public IFluentColumn None      { get { _class.Append("");     return new IFluentColumn(this); } }
        public IFluentColumn One       { get { _class.Append("-1");    return new IFluentColumn(this); } }
        public IFluentColumn Two       { get { _class.Append("-2");    return new IFluentColumn(this); } }
        public IFluentColumn Three     { get { _class.Append("-3");    return new IFluentColumn(this); } }
        public IFluentColumn Four      { get { _class.Append("-4");    return new IFluentColumn(this); } }
        public IFluentColumn Five      { get { _class.Append("-5");    return new IFluentColumn(this); } }
        public IFluentColumn Six       { get { _class.Append("-6");    return new IFluentColumn(this); } }
        public IFluentColumn Seven     { get { _class.Append("-7");    return new IFluentColumn(this); } }
        public IFluentColumn Eight     { get { _class.Append("-8");    return new IFluentColumn(this); } }
        public IFluentColumn Nine      { get { _class.Append("-9");    return new IFluentColumn(this); } }
        public IFluentColumn Ten       { get { _class.Append("-10");   return new IFluentColumn(this); } }
        public IFluentColumn Eleven    { get { _class.Append("-11");   return new IFluentColumn(this); } }
        public IFluentColumn Twelve    { get { _class.Append("-12");   return new IFluentColumn(this); } }
        public IFluentColumn Auto      { get { _class.Append("-auto"); return new IFluentColumn(this); } }
        }

    public class IFluentColumnSize : IFluentClass
    {
        public IFluentColumnSize(IFluentClass root)
        {
            this._class = root._class;
        }

        public IFluentColumn ExtraSmall { get { _class.Append("");    return new IFluentColumn(this); } }
        public IFluentColumn Small      { get { _class.Append("-sm"); return new IFluentColumn(this); } }
        public IFluentColumn Medium     { get { _class.Append("-md"); return new IFluentColumn(this); } }
        public IFluentColumn Large      { get { _class.Append("-lg"); return new IFluentColumn(this); } }
        public IFluentColumn ExtraLarge { get { _class.Append("-xl"); return new IFluentColumn(this); } }
    }
}
