using Application.Actions.Authentication.Commands.UserLogin;
using Application.Common.Models;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<string?> GetUserFullNameAsync(string userId);

    Task<LoginVm> RegisterStudentAsync(ApplicationUser user, string password, CancellationToken cancellationToken);

    Task<ApplicationUser> RegisterInstructorAsync(ApplicationUser user, string password, CancellationToken cancellationToken);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);

    Task<List<string>> GetUserRolesAsync(string userId);

    Task<bool> UpdateRefreshTokenAsync(ApplicationUser user, string refreshToken, CancellationToken cancellationToken);

    Task<bool> UpdateRefreshTokenExpiryTime(ApplicationUser user, int expiryMinutes, CancellationToken cancellationToken);

    Task<ApplicationUser> FindByRefreshToken(string refreshToken, CancellationToken cancellationToken);
}
