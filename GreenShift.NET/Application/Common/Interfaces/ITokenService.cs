using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ITokenService
{
    Task<string> GetTokenAsync(ApplicationUser user, CancellationToken cancellationToken);

    string GetToken(List<string> roles, string userId, out string refreshToken);

    string GenerateRefreshToken();
}
