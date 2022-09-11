namespace Blazor.AdminLte.Security.Abstractions.Models.Accounts;

using System.ComponentModel.DataAnnotations;

public class ForgotPasswordRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}