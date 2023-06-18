using System.Collections;
using Application.Common.Interfaces;
using Application.Common.Models;
using Discord;
using Discord.Interactions;
using MediatR;

namespace Application.Discord.Actions.Reports.Commands;

public record GenerateHourRequirementReportCommand : IRequest
{
    public int Hours { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public SocketInteractionContext Context { get; set; }
}

public class GenerateHourRequirementReportCommandHandler : MediatRDiscordActionsBase, IRequestHandler<GenerateHourRequirementReportCommand>
{
    private readonly IReportService _reportService;

    public GenerateHourRequirementReportCommandHandler(IDepartmentService departmentService, 
        IDepartmentGuildService departmentDiscordService, 
        IUserService userService, 
        ILoggingEntriesService entriesService, 
        IEmbedCollection embedCollection, 
        IBloxLinkApiService bloxLinkApiService, 
        IRobloxUserApiService robloxUserApiService, 
        IComponentService componentService,
        IReportService reportService)
        : base(departmentService, 
            departmentDiscordService, 
            userService, 
            entriesService, 
            embedCollection, 
            bloxLinkApiService, 
            robloxUserApiService, 
            componentService)
    {
        _reportService = reportService;
    }

    public async Task<Unit> Handle(GenerateHourRequirementReportCommand request, CancellationToken cancellationToken)
    {
        var socket = request.Context.Interaction;
        await socket.DeferAsync();

        var startDate = request.StartDate;
        var endDate = request.EndDate;

        if (startDate == null && endDate != null)
        {
            startDate = endDate.Value.AddMonths(-1);
        }
        else if (startDate == null && endDate == null)
        {
            endDate = DateTime.Now;
            startDate = DateTime.Now.AddMonths(-1);
        }
        else if (startDate != null && endDate == null)
        {
            endDate = startDate.Value.AddMonths(1);
        }

        (var department, bool foundDept) = await GetDepartmentAsync(request.Context, cancellationToken);

        if (!foundDept) { return Unit.Value; }

        await socket.FollowupAsync("Your PDF will arrive shortly!");
        var originalMessage = await socket.GetOriginalResponseAsync();

        var file = await _reportService.GenerateHourRequirementPdf(startDate!.Value, endDate!.Value, request.Hours, department, cancellationToken);

        Stream stream = new MemoryStream(file!);
        List<FileAttachment> files = new()
        {
            new FileAttachment(stream, "RequiredHours")
        };

        await originalMessage.ModifyAsync(properties =>
        {
            properties.Content = file != null
                ? $"Here is a document highlighting which people have logged {request.Hours} Hours between: ***{startDate.Value.ToLongDateString()} - {endDate.Value.ToLongDateString()}***"
                : "Failed to generate PDF, please try again";
            properties.Attachments = files.Any() ? new Optional<IEnumerable<FileAttachment>>(files) : null;
        });
        throw new NotImplementedException();
    }
} 
