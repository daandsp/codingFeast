using Application.Actions.Authentication.Commands.UserLogin;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Actions.Authentication.Queries.Manage2fa;

public record GetManage2FaDataQuery : IRequest<GetManage2FaDataVm>
{
    public string UserId { get; set; }
}

public class Manage2FaQueryHandler : IRequestHandler<GetManage2FaDataQuery, GetManage2FaDataVm>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public Manage2FaQueryHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<GetManage2FaDataVm> Handle(GetManage2FaDataQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            return null;
        }

        var response = new GetManage2FaDataVm()
        {
            HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null,
            Is2faEnabled = await _userManager.GetTwoFactorEnabledAsync(user),
            IsMachineRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user),
            RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user)
        };

        return response;
    }
}
