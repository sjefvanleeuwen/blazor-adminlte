using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Numerics;

namespace Blazor.AdminLte.UserApi.Helpers
{
    public class CaptchaImageGenerator
    {
        private readonly CaptchaImageOptions _options;
        public CaptchaImageGenerator(CaptchaImageOptions options)
        {
            _options = options;
        }

        public byte[] Generate(string stringText)
        {
            byte[] result;

            using (var imgText = new Image<Rgba32>(_options.Width, _options.Height))
            {
                float position = 0;
                Random random = new Random();
                byte startWith = (byte)random.Next(5, 10);
                imgText.Mutate(ctx => ctx.BackgroundColor(Color.Transparent));

                string fontName = _options.FontFamilies[random.Next(0, _options.FontFamilies.Length)];
                Font font = SystemFonts.CreateFont(fontName, _options.FontSize, _options.FontStyle);

                foreach (char c in stringText)
                {
                    var location = new PointF(startWith + position, random.Next(6, 13));
                    imgText.Mutate(ctx => ctx.DrawText(c.ToString(), font, _options.TextColor[random.Next(0, _options.TextColor.Length)], location));
                    position += TextMeasurer.Measure(c.ToString(), new TextOptions(font)).Width;
                }

                //add rotation
                AffineTransformBuilder rotation = getRotation();
                imgText.Mutate(ctx => ctx.Transform(rotation));

                // add the dynamic image to original image
                ushort size = (ushort)TextMeasurer.Measure(stringText, new TextOptions(font)).Width;
                var img = new Image<Rgba32>(size + 10 + 5, _options.Height);
                img.Mutate(ctx => ctx.BackgroundColor(_options.BackgroundColor[random.Next(0, _options.BackgroundColor.Length)]));


                Parallel.For(0, _options.DrawLines, i =>
                {
                    int x0 = random.Next(0, random.Next(0, 30));
                    int y0 = random.Next(10, img.Height);
                    int x1 = random.Next(70, img.Width);
                    int y1 = random.Next(0, img.Height);
                    img.Mutate(ctx =>
                            ctx.DrawLines(_options.DrawLinesColor[random.Next(0, _options.DrawLinesColor.Length)],
                                          CaptchaImageExtensions.GenerateNextFloat(_options.MinLineThickness, _options.MaxLineThickness),
                                          new PointF[] { new PointF(x0, y0), new PointF(x1, y1) })
                            );
                });

                img.Mutate(ctx => ctx.DrawImage(imgText, 0.80f));

                Parallel.For(0, _options.NoiseRate, i =>
                {
                    int x0 = random.Next(0, img.Width);
                    int y0 = random.Next(0, img.Height);
                    img.Mutate(
                                ctx => ctx
                                    .DrawLines(_options.NoiseRateColor[random.Next(0, _options.NoiseRateColor.Length)],
                                    CaptchaImageExtensions.GenerateNextFloat(0.5, 1.5), new PointF[] { new Vector2(x0, y0), new Vector2(x0, y0) })
                            );
                });

                img.Mutate(x =>
                {
                    x.Resize(_options.Width, _options.Height);
                });

                using (var ms = new MemoryStream())
                {
                    img.Save(ms, _options.Encoder);
                    result = ms.ToArray();
                }
            }

            return result;

        }

        private AffineTransformBuilder getRotation()
        {
            Random random = new Random();
            var builder = new AffineTransformBuilder();
            var width = random.Next(10, _options.Width);
            var height = random.Next(10, _options.Height);
            var pointF = new PointF(width, height);
            var rotationDegrees = random.Next(0, _options.MaxRotationDegrees);
            var result = builder.PrependRotationDegrees(rotationDegrees, pointF);
            return result;
        }

    }
}