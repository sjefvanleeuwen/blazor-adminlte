namespace Blazor.AdminLte.Security.Abstractions.Authorization;

using Blazor.AdminLte.Security.Abstractions.Entities;

public interface IJwtUtils
{
    public string GenerateJwtToken(Account account);
    public int? ValidateJwtToken(string token);
    public RefreshToken GenerateRefreshToken(string ipAddress);
}
