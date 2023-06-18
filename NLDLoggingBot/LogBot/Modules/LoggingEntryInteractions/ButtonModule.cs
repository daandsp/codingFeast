using MediatR;

namespace LogBot.Modules.LoggingEntryInteractions;

public class ButtonModule : LogBotModuleBase
{
    public ButtonModule(IMediator mediator) 
        : base(mediator)
    { }
}
