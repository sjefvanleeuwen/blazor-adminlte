using System.Collections.Generic;

namespace Blazor.AdminLte
{
    public class CarouselItem
    {
        public string Image { get; set; }
        public string Alt { get; set; }

        public string Link { get; set; } = "javascript:void(0)";
    }

    public class CarouselItemCollection : List<CarouselItem>
    {

    }

    public partial class Carousel
    {
    }
}
