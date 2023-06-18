using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ILoggingEntriesService
{
    public Task<bool> DeleteSingleAsync(int entryId, CancellationToken cancellationToken);
    public Task DeleteListAsync(List<LoggingEntry> entries, CancellationToken cancellationToken);
    public Task<bool> DeleteAllForUserAsync(int departmentId, int userId, CancellationToken cancellationToken);
    public Task<bool> DeleteAllForDepartmentAsync(int departmentId, CancellationToken cancellationToken);
    public Task<bool> CloseOpenForUserAsync(int userId, CancellationToken cancellationToken);
    public Task<LoggingEntry> CreateAsync(LoggingEntry loggingEntry, CancellationToken cancellationToken);
    public Task<LoggingEntry?> GetSingleAsync(int entryId, CancellationToken cancellationToken);
    public Task<List<LoggingEntry>> GetAllForUserAsync(int departmentId, int userId, CancellationToken cancellationToken);
    public Task<List<LoggingEntry>> GetAllForDepartmentAsync(int departmentId, CancellationToken cancellationToken);
    public Task<int> GetUserCountAsync(int departmentId, int userId, CancellationToken cancellationToken);
    public Task<LoggingEntry?> GetFirstLoggedAsync(int departmentId, int userId, CancellationToken cancellationToken);
}
