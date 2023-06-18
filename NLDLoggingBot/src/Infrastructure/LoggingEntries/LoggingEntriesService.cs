using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.LoggingEntries;

public class LoggingEntriesService : ILoggingEntriesService
{
    private readonly IApplicationDbContext _context;

    public LoggingEntriesService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteSingleAsync(int entryId, CancellationToken cancellationToken)
    {
        var entryToDelete = await _context.LoggingEntries
            .FirstOrDefaultAsync(entry => entry.Id == entryId, cancellationToken);
        
        if (entryToDelete == null)
        {
            return false;
        }

        _context.LoggingEntries.Remove(entryToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task DeleteListAsync(List<LoggingEntry> entries, CancellationToken cancellationToken)
    {
        _context.RemoveRange(entries);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteAllForUserAsync(int departmentId, int userId, CancellationToken cancellationToken)
    {
        var entriesToDelete = await _context.LoggingEntries
            .Where(entry => entry.UserId == userId 
                            && entry.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        if (!entriesToDelete.Any())
        {
            return false;
        }

        _context.RemoveRange(entriesToDelete);
        await _context.SaveChangesAsync(cancellationToken);
            
        return true;
    }

    public async Task<bool> DeleteAllForDepartmentAsync(int departmentId, CancellationToken cancellationToken)
    {
        var entriesToDelete = await _context.LoggingEntries
            .Where(entry => entry.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        if (!entriesToDelete.Any())
        {
            return false;
        }

        _context.RemoveRange(entriesToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> CloseOpenForUserAsync(int userId, CancellationToken cancellationToken)
    {
        var openLoggingEntry = await _context.LoggingEntries
            .FirstOrDefaultAsync(entry => entry.IntervalEnd == null, cancellationToken);

        if (openLoggingEntry == null)
        {
            return false;
        }

        openLoggingEntry.IntervalEnd = TimeHelper.GetEpochms();
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<LoggingEntry> CreateAsync(LoggingEntry loggingEntry, CancellationToken cancellationToken)
    {
        var addedLoggingEntry = await _context.LoggingEntries.AddAsync(loggingEntry, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return addedLoggingEntry.Entity;
    }

    public async Task<LoggingEntry?> GetSingleAsync(int entryId, CancellationToken cancellationToken)
    {
        return await _context.LoggingEntries.FindAsync(new object?[] { entryId }, cancellationToken);
    }

    public async Task<List<LoggingEntry>> GetAllForUserAsync(int departmentId, int userId, CancellationToken cancellationToken)
    {
        return await _context.LoggingEntries
            .Where(entry => entry.UserId == userId && entry.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<LoggingEntry>> GetAllForDepartmentAsync(int departmentId, CancellationToken cancellationToken)
    {
        return await _context.LoggingEntries
            .Where(entry => entry.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetUserCountAsync(int departmentId, int userId, CancellationToken cancellationToken)
    {
        return await _context.LoggingEntries.CountAsync(
            entry => entry.DepartmentId == departmentId && entry.UserId == userId, cancellationToken);
    }

    public async Task<LoggingEntry?> GetFirstLoggedAsync(int departmentId, int userId, CancellationToken cancellationToken)
    {
        return await _context.LoggingEntries
            .Where(entry => entry.DepartmentId == departmentId && entry.UserId == userId)
            .OrderByDescending(entry => entry.DateCreated)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
