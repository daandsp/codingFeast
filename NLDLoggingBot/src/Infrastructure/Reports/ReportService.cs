using System.Text;
using Application.Common.ExtensionMethods;
using Application.Common.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Reports;

public class ReportService : IReportService
{
    private readonly IUserService _userService;
    private readonly IServiceProvider _provider;

    public ReportService(IUserService userService, IServiceProvider provider)
    {
        _userService = userService;
        _provider = provider;
    }

    public async Task<byte[]?> GenerateHourRequirementPdf(DateTime startDate, DateTime endDate, int hours, Department department, CancellationToken cancellationToken)
    {

        var users = await _userService.GetUsersTogetherWithDepartmentLogsAsync(department.Id, cancellationToken);
        List<User> userWithRequiredHours = new();
        List<User> userWithoutRequiredHours = new();

        users.ForEach(user =>
        {
            if (user.LogEntries.GetLoggingTotal().Hours >= hours)
            {
                userWithRequiredHours.Add(user);
            }
            else
            {
                userWithoutRequiredHours.Add(user);
            }
        });

        var htmlTemplate = HtmlGenerator(userWithRequiredHours, userWithoutRequiredHours);

        var globalSettings = new GlobalSettings()
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings {Top = 10},
            DocumentTitle = $"{department.Name}_{startDate.ToShortDateString()}_{endDate.ToShortDateString()}"
        };
        var objectSettings = new ObjectSettings()
        {
            PagesCount = true,
            HtmlContent = htmlTemplate,
            WebSettings = {DefaultEncoding = "utf-8", UserStyleSheet = "Utilities/PdfTemplates/PdfStyle.scss"},
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Left = $"LoggingBot | {DateTime.Now.ToLongDateString()}, {DateTime.Now.ToShortTimeString()}"},
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true}
        };
        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        using IServiceScope scope = _provider.CreateScope();
        try
        {
            var localConverter = scope.ServiceProvider.GetRequiredService<IConverter>();
            return localConverter.Convert(pdf);
        }
        catch { }

        return null;
    }

    private string HtmlGenerator(List<User> usersRequiredHours, List<User> users)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder = GeneratePdfHeader(stringBuilder);

        return stringBuilder.ToString();
    }


    private StringBuilder GeneratePdfHeader(StringBuilder stringBuilder)
    {
        return stringBuilder.AppendFormat(@"<html><head></head><body>");
    }
}
