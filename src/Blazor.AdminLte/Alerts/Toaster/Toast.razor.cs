using Blazor.AdminLte.Alerts.Toaster;
using Blazor.AdminLte.Alerts.Toaster.Configuration;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazor.AdminLte
{
    public partial class Toast : IDisposable
    {
        [CascadingParameter] private Toasts ToastsContainer { get; set; }

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public ToastSettings ToastSettings { get; set; }
        [Parameter] public ToastInstanceSettings ToastComponentSettings { get; set; }
        [Parameter] public int Timeout { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        private RenderFragment CloseButtonContent => ToastsContainer.CloseButtonContent;
        private bool ShowCloseButton => ToastsContainer.ShowCloseButton;

        private CountdownTimer _countdownTimer;
        private int _progress = 100;

        protected override void OnInitialized()
        {
            _countdownTimer = new CountdownTimer(Timeout);
            _countdownTimer.OnTick += CalculateProgress;
            _countdownTimer.OnElapsed += Close;
            _countdownTimer.Start();
        }

        private async void CalculateProgress(int percentComplete)
        {
            try
            {
                _progress = 100 - percentComplete;
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                // Swallowing exceptions due to async void
            }
        }

        /// <summary>
        /// Closes the toast
        /// </summary>
        public void Close() 
            => ToastsContainer.RemoveToast(ToastId);

        private void ToastClick() 
            => ToastSettings.OnClick?.Invoke();

        public void Dispose()
        {
            _countdownTimer.Dispose();
            _countdownTimer = null;
        }
    }
}
