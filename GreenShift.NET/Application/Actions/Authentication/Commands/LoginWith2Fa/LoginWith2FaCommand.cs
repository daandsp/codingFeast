using Application.Actions.Authentication.Commands.UserLogin;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Actions.Authentication.Commands.LoginWith2fa;

public record LoginWith2FaCommand : IRequest<LoginVm>
{
    public string TwoFactorCode { get; set; }
    public string TwoFactorToken { get; set; }
    public bool RememberMachine { get; set; }
    public bool RememberMe { get; set; }
}

public class LoginWith2FaCommandHandler : IRequestHandler<LoginWith2FaCommand, LoginVm>
{
    private readonly IAuthenticationService _authenticationService;
    public LoginWith2FaCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<LoginVm> Handle(LoginWith2FaCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.TwoFactorSignInAsync(request, cancellationToken);
    }
}
