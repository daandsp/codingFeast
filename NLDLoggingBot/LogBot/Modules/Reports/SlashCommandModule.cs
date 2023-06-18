using Application.Discord.Actions.Reports.Commands;
using Discord.Interactions;
using MediatR;

namespace LogBot.Modules.Reports;

public class SlashCommandModule : LogBotModuleBase
{
    public SlashCommandModule(IMediator mediator)
        : base(mediator)
    { }

    //[SlashCommand("test", "test")]
    //public async Task Test(
    //    [Summary("hours", "Minimum hours users should have patrolled in the time frame provided (Default 1 month)")] int hours,
    //    [Summary("startDate", "Input a date and time in the following format: MM/DD/YYYY HH:MM")] DateTime? startDate = null,
    //    [Summary("endDate", "Input a date and time in the following format: MM/DD/YYYY HH:MM")] DateTime? endDate = null)
    //{

    //    await MediatorActionAsync<GenerateHourRequirementReportCommand>(new()
    //    {
    //        Hours = hours,
    //        StartDate = startDate,
    //        EndDate = endDate,
    //        Context = Context
    //    });
    //}
}