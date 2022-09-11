namespace Blazor.AdminLte.Security.Abstractions.Models.Accounts
{
    public class CaptchaGenerateResponse
    {
        public string Image { get; set; }
        public string TransactionKey { get; set; }
    }
}
