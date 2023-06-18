using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IReportService
{
    public Task<byte[]?> GenerateHourRequirementPdf(DateTime startDate, DateTime endDate, int hours, Department department, CancellationToken cancellationToken);
}
