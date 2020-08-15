using System;
using System.Globalization;
using Xunit;
using Bunit;
namespace Blazor.AdminLte.Tests
{
    public class DateRangePickerTests
    {
        [Theory]
        [InlineData("en-US", 2020, 12, 29, 2020, 12, 30, "12/29/2020 - 12/30/2020")]
        [InlineData("nl-NL", 2020, 12, 29, 2020, 12, 30, "29-12-2020 - 30-12-2020")]
        public void ShouldRenderComponentWithCorrectDateTimeLocaleForValueParameter
        (
            string culture,
            int fromYear,
            int fromMonth,
            int fromDay,
            int toYear,
            int toMonth,
            int toDay,
            string expected
        )
        {
            // Arrange
            using var ctx = new TestContext();
            var range = new Range<DateTime>(
                new DateTime(fromYear,fromMonth,fromDay), new DateTime(toYear, toMonth, toDay));
            
            // Act
            var cut = ctx.RenderComponent<DateRangePicker>(
                (nameof(DateRangePicker.Range), range),
                (nameof(DateRangePicker.CultureInfo), new CultureInfo(culture)
            ));
            
            // Assert
            Assert.Equal(expected, cut.Find("input").GetAttribute("value"));
        }

        [Theory]
        [InlineData("en-US", 2020,12,30,"12/30/2020", "M[/]D[/]YYYY", "M'/'d'/'yyyy")]
        [InlineData("nl-NL", 2020, 12, 30, "30-12-2020", "D[-]M[-]YYYY", "d'-'M'-'yyyy")]
        public void ShouldConvertDateTimeBiDirectional(
            string culture,
            int year,
            int month,
            int day,
            string momentJsDateTime,
            string expectedMomentJsPattern,
            string expectedDateTimePattern
        )
        {
            //Arrange
            var s = MomentJSHelpers.GenerateMomentJSFormatString(new CultureInfo(culture).DateTimeFormat.ShortDatePattern);
            var a = MomentJsConverter.GenerateCSharpFormatString(s);

            // Act, note this is a unit test so MomentJS Javacript lib itself is not tested but converion in its lib is assumed to be correct.
            var date = DateTime.ParseExact(momentJsDateTime, a, new CultureInfo(culture));

            //Assert
            Assert.Equal(expectedMomentJsPattern, s);
            Assert.Equal(expectedDateTimePattern, a);
            Assert.Equal(year, date.Year);
            Assert.Equal(month, date.Month);
            Assert.Equal(day, date.Day);
        }
    }
}
