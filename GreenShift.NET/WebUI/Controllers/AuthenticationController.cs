using Application.Actions.Authentication.Commands.Enable2Fa;
using Application.Actions.Authentication.Commands.LoginWith2fa;
using Application.Actions.Authentication.Commands.RefreshToken;
using Application.Actions.Authentication.Commands.RevokeToken;
using Application.Actions.Authentication.Commands.UserLogin;
using Application.Actions.Authentication.Queries.Enable2fa;
using Application.Actions.Authentication.Queries.Manage2fa;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class AuthenticationController : ApiControllerBase
{
    public AuthenticationController(IMediator mediator)
        : base(mediator)
    { }

    [HttpGet("GetManage2faData")]
    public async Task<ActionResult<GetManage2FaDataVm>> GetManage2FaDataAsync()
    {
        return await MediatorActionAsync<GetManage2FaDataVm, GetManage2FaDataQuery>(new() { UserId = GetRequestUserId() });
    }

    [HttpGet("GetEnable2faData")]
    public async Task<ActionResult<GetEnable2FaDataVm>> GetEnable2FaDataAsync()
    {
        return await MediatorActionAsync<GetEnable2FaDataVm, GetEnable2FaDataQuery>(new() { UserId = GetRequestUserId() });
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<LoginVm>> Login(UserLoginCommand command)
    {
        return await MediatorActionAsync<LoginVm, UserLoginCommand>(command);
    }

    [AllowAnonymous]
    [HttpPost("LoginWith2fa")]
    public async Task<ActionResult<LoginVm>> LoginWith2fa(LoginWith2FaCommand command)
    {
        return await MediatorActionAsync<LoginVm, LoginWith2FaCommand>(command);
    }

    [HttpPost("Verify2faEnabling")]
    public async Task<ActionResult<bool>> Verify2FaEnablingAsync(string code)
    {
        return await MediatorActionAsync<bool, Enable2FaCommand>(new() { Code = code, UserId = GetRequestUserId() });
    }

    [HttpPost("RefreshToken")]
    public async Task<ActionResult<string>> RefreshTokenAsync()
    {
        return await MediatorActionAsync<string, RefreshTokenCommand>(new()
        {
            UserId = GetRequestUserId(),
            RefreshToken = GetRefreshToken()
        });
    }

    [HttpPost("RevokeToken")]
    public async Task<ActionResult> RevokeTokenAsync()
    {
        return await MediatorActionAsync<RevokeTokenCommand>(new() { UserId = GetRequestUserId() });
    }
}
