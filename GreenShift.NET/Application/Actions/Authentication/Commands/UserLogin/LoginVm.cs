using Microsoft.AspNetCore.Identity;

namespace Application.Actions.Authentication.Commands.UserLogin;

public class LoginVm
{
    public string? Token { get; set; }
    public SignInResult SignInResult { get; set; }
}
