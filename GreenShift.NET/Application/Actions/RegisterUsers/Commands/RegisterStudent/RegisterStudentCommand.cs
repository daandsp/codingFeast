using Application.Actions.Authentication.Commands.UserLogin;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Actions.ApplicationUsers.Commands.RegisterStudent;

public record RegisterStudentCommand : IRequest<LoginVm>
{
    public string FirstName { get; set; }
    public string Infix { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; }
}

public class RegisterStudentHandler : IRequestHandler<RegisterStudentCommand, LoginVm>
{
    private readonly IIdentityService _identityService;

    public RegisterStudentHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<LoginVm> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser(request.FirstName, request.Infix, request.LastName, request.Email, request.PhoneNumber, DateTime.Now);

        return await _identityService.RegisterStudentAsync(user, request.Password, cancellationToken);
    }
}