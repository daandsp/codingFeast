using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Actions.ApplicationUsers.Commands.RegisterInstructor;

public record RegisterInstructorCommand : IRequest<ApplicationUser>
{
    public string FirstName { get; set; }
    public string Infix { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string BankingInfo { get; set; }
    public string Password { get; set; }
}

public class RegisterInstructorHandler : IRequestHandler<RegisterInstructorCommand, Domain.Entities.ApplicationUser>
{
    private readonly IIdentityService _identityService;

    public RegisterInstructorHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<ApplicationUser> Handle(RegisterInstructorCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser(request.FirstName, request.Infix, request.LastName, request.Email, request.PhoneNumber, request.BankingInfo);

        return await _identityService.RegisterInstructorAsync(user, "Hallo1@", cancellationToken);
    }
}