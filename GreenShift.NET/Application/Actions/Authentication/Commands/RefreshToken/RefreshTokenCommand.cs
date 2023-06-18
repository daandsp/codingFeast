using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Actions.Authentication.Commands.RefreshToken;

public record RefreshTokenCommand : IRequest<string>
{
    public string UserId { get; set; }
    public string RefreshToken { get; set; }
}

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, string>
{
    private readonly ITokenService _tokenService;
    private readonly IIdentityService _identityService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IApplicationDbContext _context;

    public RefreshTokenCommandHandler(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService,
        IIdentityService identityService,
        IApplicationDbContext context)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _identityService = identityService;
        _context = context;
    }

    public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return null;
        }

        var roles = await _identityService.GetUserRolesAsync(request.UserId);

        var token = _tokenService.GetToken(roles.ToList(), user.Id, out string newRefreshToken);

        user.RefreshToken = newRefreshToken;
        await _context.SaveChangesAsync(cancellationToken);

        return token;
    }
}