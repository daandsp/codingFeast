using Application.Common.Interfaces;
using MediatR;

namespace Application.Actions.Authentication.Commands.RevokeToken;

public record RevokeTokenCommand : IRequest
{
    public string UserId { get; set; }
}

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand>
{
    private readonly IApplicationDbContext _context;

    public RevokeTokenCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        var user = _context.ApplicationUsers.SingleOrDefault(u => u.Id == request.UserId);

        user.RefreshToken = null;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}