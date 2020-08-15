using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Blazor.AdminLte
{
    public partial class DateRangePicker
    {
        [Inject] IJSRuntime JS { get; set; }

        ElementReference DateRangePickerRef { get; set; }

        [Parameter]
        public string CancelLabel { get; set; } = "Cancel";
        [Parameter]
        public string ApplyLabel { get; set; } = "Apply";


        private Range<DateTime> _range;

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        [Parameter]
        public Range<DateTime> Range
        {
            get
            {
                return _range;
            }
            set
            {

                _range = value;
            }
        }

        [Parameter]
        public EventCallback<Range<DateTime>> RangeChanged { get; set; }
        [Parameter]
        public EventCallback<Range<DateTime>> OnRangeChanged { get; set; }

        private string value
        {
            get
            {
                return Range.From.ToString(CultureInfo.DateTimeFormat.ShortDatePattern) + " - " + Range.To.ToString(CultureInfo.DateTimeFormat.ShortDatePattern);
            }
            set
            {
                _range = new Range<DateTime>(new DateTime(), new DateTime());
            }
        }

        [Parameter]
        public string Icon { get; set; } = "far fa-calendar-alt";

        [JSInvokable("hasChanged")]
        public async void hasChanged(long start, long end, string label)
        {
            //var startDate = UnixTimeStampToDateTime(start);
            Range = new Range<DateTime>(
                new DateTime(1970, 1, 1).AddTicks(start * 10000).ToLocalTime(),
                new DateTime(1970, 1, 1).AddTicks(end * 10000).ToLocalTime());
            await RangeChanged.InvokeAsync(Range);
            await OnRangeChanged.InvokeAsync(Range);

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var dotNetReference = DotNetObjectReference.Create(this);
                await JS.InvokeVoidAsync("dateRangePicker",
                    dotNetReference,
                    DateRangePickerRef,
                    Range,
                    new DateRangePickerLocale()
                    {
                        Language = CultureInfo.Name.Split('-')[0],
                        Format = MomentJSHelpers.GenerateMomentJSFormatString(CultureInfo.DateTimeFormat.ShortDatePattern),
                        ApplyLabel = ApplyLabel,
                        CancelLabel = CancelLabel
                    },
                    new DateRangePickerSettings()
                    {
                        // no extra settings yet in MVP
                    }
                    );
            }
        }
    }
}
