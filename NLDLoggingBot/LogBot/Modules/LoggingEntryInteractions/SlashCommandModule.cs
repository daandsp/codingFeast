using Application.Discord.Actions.LoggingEntries.Commands.Department.DeleteEntries;
using Application.Discord.Actions.LoggingEntries.Commands.Department.DisplayEntries;
using Application.Discord.Actions.LoggingEntries.Commands.Users.CreateEntry;
using Application.Discord.Actions.LoggingEntries.Commands.Users.DeleteEntries;
using Application.Discord.Actions.LoggingEntries.Commands.Users.DisplayEntries;
using Discord;
using Discord.Interactions;
using LogBot.Common.Attributes;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace LogBot.Modules.LoggingEntryInteractions;

public class SlashCommandModule : LogBotModuleBase
{
    protected readonly IConfiguration _configuration;

    public SlashCommandModule(IMediator mediator,
        IConfiguration configuration)
        : base(mediator)
    {
        _configuration = configuration;
    }

    public class GuildUserSlashCommands : LogBotModuleBase
    {
        public GuildUserSlashCommands(IMediator mediator)
            : base(mediator)
        { }

        [Group("patrol", "All options available to interact with logged patrols.")]
        public class PatrolLogsCommands : LogBotModuleBase
        {
            public PatrolLogsCommands(IMediator mediator)
                : base(mediator)
            { }

            [SlashCommand("log", "Log your patrol hours")]
            public async Task LogManualPatrolAsync(int hours, int minutes)
            {
                await PublishNotificationAsync<CreateEntryCmdNotification>(new(hours, minutes, Context));
            }

            [Group("display", "Displays the logs of either a person or your entire department.")]
            public class DisplayPatrolLogsCommands : LogBotModuleBase
            {
                public DisplayPatrolLogsCommands(IMediator mediator)
                    : base(mediator)
                { }

                [SlashCommand("user", "Displays the logs of the specified user.")]
                [UserCommand("Display Logs")]
                public async Task DisplayUserPatrols(IUser user)
                {
                    await PublishNotificationAsync<GetUserEntriesCmdNotification>(new(user, Context));
                }

                [SlashCommand("department", "Displays the logs of your department.")]
                public async Task DisplayDepartmentPatrols()
                {
                    await PublishNotificationAsync<GetDepartmentEntriesCmdNotification>(new(Context));
                }
            }
        }
    }

    [RequireLoggingBotAccess]
    public class GuildModeratorSlashCommands : LogBotModuleBase
    {
        public GuildModeratorSlashCommands(IMediator mediator)
            : base(mediator)
        { }

        [Group("delete", "Deletes the logs of either a person or your entire department.")]
        public class DeleteLogsCommands : LogBotModuleBase
        {
            public DeleteLogsCommands(IMediator mediator)
                : base(mediator)
            { }

            [SlashCommand("user-logs", "Deletes all logs connected to a user within a department.")]
            [UserCommand("Delete Logs")]
            public async Task DeleteUserLogsAsync(IUser user)
            {
                await PublishNotificationAsync<DeleteUserEntriesCmdNotification>(new(user, Context));
            }

            [SlashCommand("department-logs", "Deletes all logs connected to a department.")]
            public async Task DeleteDepartmentLogsAsync()
            {
                await PublishNotificationAsync<DeleteDepartmentEntriesCmdNotification>(new(Context));
            }
        }
    }
}
