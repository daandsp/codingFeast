using Application.Actions.ApplicationUsers.Commands.RegisterInstructor;
using Application.Actions.ApplicationUsers.Commands.RegisterStudent;
using Application.Actions.Authentication.Commands.UserLogin;
using Application.Common.Interfaces;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class RegisterUserController : ApiControllerBase
{
    private readonly IIdentityService _identityService;

    public RegisterUserController(
        IIdentityService identityService,
        IMediator mediator)
        : base(mediator)
    {
        _identityService = identityService;
    }

    [HttpGet("GetUserName")]
    public async Task<string?> GetName()
    {
        return await _identityService.GetUserFullNameAsync(GetRequestUserId());
    }

    [AllowAnonymous]
    [HttpPost("RegisterStudent")]
    public async Task<ActionResult<LoginVm>> RegisterStudent(RegisterStudentCommand command)
    {
        return await MediatorActionAsync<LoginVm, RegisterStudentCommand>(command);
    }

    [Roles(Roles.Admin)]
    [HttpPost("RegisterInstructor")]
    public async Task<ActionResult> RegisterInstructor(RegisterInstructorCommand command)
    {
        return await MediatorActionAsync<RegisterInstructorCommand>(command);
    }
}
