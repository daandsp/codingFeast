using Application.Actions.Authentication.Queries.Manage2fa;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Actions.Authentication.Commands.Enable2Fa;

public record Enable2FaCommand : IRequest<bool>
{
    public string UserId { get; set; }
    public string Code { get; set; }
    public string TwoFactorToken { get; set; }
}

public class Enable2FaCommandHandler : IRequestHandler<Enable2FaCommand, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public Enable2FaCommandHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> Handle(Enable2FaCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            return false;
        }

        var verificationCode = request.Code.Replace(" ", string.Empty).Replace("-", string.Empty);

        var is2FaTokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);

        if (!is2FaTokenValid)
        {
            return is2FaTokenValid;
        }

        await _userManager.SetTwoFactorEnabledAsync(user, true);

        if (await _userManager.CountRecoveryCodesAsync(user) == 0)
        {
            //var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
        }

        return is2FaTokenValid;
    }
}
