using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.AdminLte
{
    public enum LoadingState
    {
        [Style("")]
        None,
        [Style("overlay")]
        Normal,
        [Style("overlay dark")]
        Dark
    }
}
