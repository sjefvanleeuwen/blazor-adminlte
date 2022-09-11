using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;

namespace Blazor.AdminLte.UserApi.Helpers
{
    public class CaptchaImageOptions
    {
        /// <summary>
        /// Default fonts are  "Arial", "Verdana", "Times New Roman" in Windows
        /// Linux guys have to set thier own fonts :)
        /// </summary>
        public string[] FontFamilies { get; set; } = new string[] { "Arial", "Verdana", "Times New Roman" };
        public Color[] TextColor { get; set; } = new Color[] { Color.Blue, Color.Black, Color.Black, Color.Brown, Color.Gray, Color.Green };
        public Color[] DrawLinesColor { get; set; } = new Color[] { Color.Blue, Color.Black, Color.Black, Color.Brown, Color.Gray, Color.Green };
        public float MinLineThickness { get; set; } = 0.7f;
        public float MaxLineThickness { get; set; } = 2.0f;
        public ushort Width { get; set; } = 180;
        public ushort Height { get; set; } = 50;
        public ushort NoiseRate { get; set; } = 800;
        public Color[] NoiseRateColor { get; set; } = new Color[] { Color.Gray };
        public byte FontSize { get; set; } = 29;
        public FontStyle FontStyle { get; set; } = FontStyle.Regular;
        public CaptchaImageEncoderTypes EncoderType { get; set; } = CaptchaImageEncoderTypes.Png;
        public IImageEncoder Encoder => CaptchaImageExtensions.GetEncoder(EncoderType);
        public byte DrawLines { get; set; } = 5;
        public byte MaxRotationDegrees { get; set; } = 5;
        public Color[] BackgroundColor { get; set; } = new Color[] { Color.White };
    }

}
