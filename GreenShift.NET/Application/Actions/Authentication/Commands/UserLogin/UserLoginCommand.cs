using Application.Common.Interfaces;
using MediatR;

namespace Application.Actions.Authentication.Commands.UserLogin;

public record UserLoginCommand : IRequest<LoginVm>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, LoginVm>
{
    private readonly IAuthenticationService _authenticationService;

    public UserLoginCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<LoginVm> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.UserLoginAsync(request, cancellationToken);
    }
}