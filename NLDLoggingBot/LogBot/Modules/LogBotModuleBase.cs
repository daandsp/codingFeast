using Application.Common.Interfaces;
using Discord.Interactions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LogBot.Modules;

public abstract class LogBotModuleBase : InteractionModuleBase<SocketInteractionContext>
{
    private readonly IMediator _mediator;

    protected LogBotModuleBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task MediatorActionAsync<TAction>(TAction action)
    {
        if (action == null)
        {
            return;
        }

        _ = await _mediator.Send(action);
    }

    protected async Task PublishNotificationAsync<TNotification>(TNotification notification)
        where TNotification : INotification
    {
        if (notification == null)
        {
            return;
        }

        await _mediator.Publish(notification);
    }
}
