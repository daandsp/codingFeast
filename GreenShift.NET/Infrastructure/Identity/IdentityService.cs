using Application.Common.Models;
using Application.Common.Interfaces;
using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Application.Actions.Authentication.Commands.UserLogin;

namespace Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly IAuthenticationService _authenticationService;
    private readonly IApplicationDbContext _context;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService,
        IAuthenticationService authenticationService,
        IApplicationDbContext context)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _authenticationService = authenticationService;
        _context = context;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<string?> GetUserFullNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.GetFullName();
    }

    public async Task<LoginVm> RegisterStudentAsync(ApplicationUser user, string password, CancellationToken cancellationToken)
    {
        await _userManager.CreateAsync(user, password);
        await _userManager.AddToRoleAsync(user, Roles.Student);

        return await _authenticationService.UserLoginAsync(new UserLoginCommand(){ Password = password, UserName = user.UserName }, cancellationToken);
    }

    public async Task<ApplicationUser> RegisterInstructorAsync(ApplicationUser user, string password,
        CancellationToken cancellationToken)
    {
        await _userManager.CreateAsync(user, password);
        await _userManager.AddToRoleAsync(user, Roles.Instructor);

        return user;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<List<string>> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var roles = await _userManager.GetRolesAsync(user);

        return roles.ToList();
    }

    public async Task<bool> UpdateRefreshTokenAsync(ApplicationUser user, string refreshToken, CancellationToken cancellationToken)
    {
        user.RefreshToken = refreshToken;
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }

    public async Task<bool> UpdateRefreshTokenExpiryTime(ApplicationUser user, int expiryMinutes, CancellationToken cancellationToken)
    {
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(expiryMinutes);
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }

    public async Task<ApplicationUser> FindByRefreshToken(string refreshToken, CancellationToken cancellationToken)
    {
        var user = await _context.ApplicationUsers.FirstOrDefaultAsync(user => user.RefreshToken == refreshToken, cancellationToken);

        if (user == null)
        {
            return null;
        }

        return user;
    }
}
