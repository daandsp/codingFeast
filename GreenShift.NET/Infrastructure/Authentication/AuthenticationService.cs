using Application.Actions.Authentication.Commands.LoginWith2fa;
using Application.Actions.Authentication.Commands.UserLogin;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    //private readonly IIdentityService _identityService;
    private readonly IApplicationDbContext _context;

    public AuthenticationService(
        UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService,
        //IIdentityService identityService,
        IApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        //_identityService = identityService;
        _context = context;
    }

    public async Task<LoginVm> UserLoginAsync(UserLoginCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(command.UserName);

        var result = await _signInManager.PasswordSignInAsync(user, command.Password, command.RememberMe, lockoutOnFailure: false);

        LoginVm loginVm = new() { SignInResult = result };

        if (result.Succeeded)
        {
            loginVm.Token = await _tokenService.GetTokenAsync(user, cancellationToken);
        }
        else if (result.RequiresTwoFactor)
        {
            loginVm.Token = _tokenService.GenerateRefreshToken();
            //await _identityService.UpdateRefreshTokenAsync(user, loginVm.Token, cancellationToken);
            //await _identityService.UpdateRefreshTokenExpiryTime(user, 2, cancellationToken);

            user.RefreshToken = loginVm.Token;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(2);
            await _userManager.UpdateAsync(user);
        }

        return loginVm;
    }

    public async Task<LoginVm> TwoFactorSignInAsync(LoginWith2FaCommand command, CancellationToken cancellationToken)
    {
        var user = await _context.ApplicationUsers.FirstOrDefaultAsync(user => user.RefreshToken == command.TwoFactorToken,
            cancellationToken);

        if (user == null)
        {
            throw new InvalidOperationException($"Unable to load two-factor authentication user.");
        }

        if (user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            throw new InvalidOperationException();
        }

        var authenticatorCode = command.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, command.RememberMe, command.RememberMachine);

        LoginVm loginVm = new() { SignInResult = result };

        if (loginVm.SignInResult.Succeeded)
        {
            loginVm.Token = await _tokenService.GetTokenAsync(user, cancellationToken);
        }

        return loginVm;
    }
}
