using System;
using System.Globalization;
using System.Linq;

namespace Blazor.AdminLte
{
    public static class EnumExtensions
    {
        public static string GetDescription<U>(this IConvertible e)
            where U : class, IDescription
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(U), false)
                            .FirstOrDefault() as U;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null; // could also return string.Empty
        }
    }
}
