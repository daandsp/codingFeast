using Application.Actions.Authentication.Commands.LoginWith2fa;
using Application.Actions.Authentication.Commands.UserLogin;
using Microsoft.AspNetCore.Identity;

namespace Application.Common.Interfaces;

public interface IAuthenticationService
{
    Task<LoginVm> UserLoginAsync(UserLoginCommand command, CancellationToken cancellationToken);
    Task<LoginVm> TwoFactorSignInAsync(LoginWith2FaCommand command, CancellationToken cancellationToken);
}

