using System;

namespace Blazor.AdminLte
{
    public class StyleAttribute : Attribute, IDescription
    {
        public string Description { get; set; }

        public StyleAttribute(string description)
        {
            Description = description;
        }
    }
}
