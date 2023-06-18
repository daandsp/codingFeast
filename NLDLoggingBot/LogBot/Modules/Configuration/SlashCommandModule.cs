using Application.Discord.Actions.DepartmentDiscords.Commands.ConfigureDepartmentDiscord;
using Application.Discord.Actions.DepartmentDiscords.Commands.DeleteDepartmentDiscord;
using Discord.Interactions;
using Domain.Enums;
using LogBot.Common.Attributes;
using MediatR;

namespace LogBot.Modules.Configuration;

public class SlashCommandModule : LogBotModuleBase
{
    public SlashCommandModule(IMediator mediator)
        : base(mediator)
    { }

    [RequireLoggingBotAccess]
    [SlashCommand("configure", "Allows people with LogBot Access to configure certain features.")]
    public async Task ConfigureBot()
    {
        //await MediatorActionAsync<>(new());
    }

    public class ConfigurationCommands : LogBotModuleBase
    {
        public ConfigurationCommands(IMediator mediator)
            : base(mediator)
        { }

        [RequireOwner]
        [Group("department-link", "Configures discord server connections to a department.")]
        public class ConfigureDepartmentConnection : LogBotModuleBase
        {
            public ConfigureDepartmentConnection(IMediator mediator)
                : base(mediator)
            { }

            //[SlashCommand("add", "Connects the discord server with a department.")]
            //public async Task AddDepartmentDiscordAsync(
            //    [Summary("Department"), Autocomplete(typeof(ConfigureDepartmentDiscordAutocompleteHandler))] 
            //    int departmentId,
            //    [Summary("Permissions"), Choice("Primary", "1"), Choice("Secondary", "2")] 
            //    int priority)
            //{
            //    var priorityEnum = priority == 1 ? Permissions.FullAccess : Permissions.LogOnly;

            //    await PublishNotificationAsync<ConfigureDepartmentDiscordCmdNotification>(new(departmentId, priorityEnum, Context));
            //}

            [SlashCommand("add", "Connect to a department.")]
            public async Task AddDepartmentLinkAsync(
                [Summary("Link"), Choice("Server", "1"), Choice("Channel", "2")]
                int priority)
            {
                var priorityEnum = priority == 1 ? Permissions.FullAccess : Permissions.LogOnly;

                await PublishNotificationAsync<ConfigureDepartmentDiscordCmdNotification>(new(1, priorityEnum, Context));
            }

            [SlashCommand("remove", "Removes the discord server from its connected department.")]
            public async Task RemoveDepartmentLinkAsync()
            {
                await PublishNotificationAsync<DeleteDepartmentDiscordCmdNotification>(new(Context));
            }
        }
    }
}
