using Microsoft.AspNetCore.Components;

namespace Blazor.AdminLte
{
    partial class InfoBox
    {
        [Parameter]
        public string Icon { get; set; }
        [Parameter]
        public double Number { get; set; }
        [Parameter]
        public double? Percentage { get; set; }
        [Parameter]
        public Color IconBackgroundColor { get; set; }
        [Parameter]
        public Color BackgroundColor { get; set; }
        [Parameter]
        public Gradient Gradient { get; set; }

        [Parameter]
        public RenderFragment ProgressDescription { get; set; }
        [Parameter]
        public RenderFragment Title { get; set; }

        private string DisplayBackgroundColor =>
            BackgroundColor == Color.Default ?
            string.Empty :
            $"{GradientPrefix}{BackgroundColor.GetDescription<StyleAttribute>()}";

        private string DisplayIconBackgroundColor => 
            IconBackgroundColor == Color.Default ?
            string.Empty :
            $"{GradientPrefix}{IconBackgroundColor.GetDescription<StyleAttribute>()}";

        private string GradientPrefix =>
                Gradient == Gradient.None ?
                string.Empty :
                $"{Gradient.GetDescription<StyleAttribute>()}-";
    }
}
