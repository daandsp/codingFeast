using Discord.Interactions;
using MediatR;

namespace Application.Common.Models;

public class BaseNotification : INotification
{
    public SocketInteractionContext Context { get; set; }

    public BaseNotification(SocketInteractionContext context)
    {
        Context = context;
    }
}
