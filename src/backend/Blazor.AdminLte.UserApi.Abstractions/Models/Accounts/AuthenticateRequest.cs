namespace Blazor.AdminLte.Security.Abstractions.Models.Accounts;

using System.ComponentModel.DataAnnotations;

public class AuthenticateRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}