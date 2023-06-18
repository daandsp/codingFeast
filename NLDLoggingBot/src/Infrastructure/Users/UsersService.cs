using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users;

public class UsersService : IUserService
{
    private readonly IApplicationDbContext _context;

    public UsersService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        var userToUpdate = await _context.User.FindAsync(new object?[] { user.Id }, cancellationToken);

        if (userToUpdate == null)
        {
            return false;
        }

        userToUpdate = user;
        _context.User.Update(userToUpdate);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken)
    {
        var created = await _context.User.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return created.Entity;
    }

    public async Task<User?> GetByDiscordIdAsync(ulong discordUserId, CancellationToken cancellationToken)
    {
        return await _context.User.FirstOrDefaultAsync(user => user.DiscordId == discordUserId, cancellationToken);
    }

    public async Task<User> GetAsync(ulong guildUserId, ulong robloxId, CancellationToken cancellationToken)
    {
        if (await _context.User.AnyAsync(user => user.DiscordId == guildUserId && user.RobloxId == robloxId, cancellationToken))
            return await _context.User.FirstAsync(user => user.DiscordId == guildUserId && user.RobloxId == robloxId, cancellationToken);

        var newUser = await _context.User
            .AddAsync(new User
            {
                DiscordId = guildUserId,
                RobloxId = robloxId
            }, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return newUser.Entity;
    }

    public async Task<User> GetByLoggingEntryIdAsync(int entryId, CancellationToken cancellationToken)
    {
        return await _context.LoggingEntries
            .Include(entry => entry.User)
            .Where(entry => entry.Id == entryId)
            .Select(entry => entry.User)
            .FirstAsync(cancellationToken);
    }

    public async Task<List<User>> GetUsersWithDepartmentLogsAsync(int departmentId, CancellationToken cancellationToken)
    {
        var userIdsWithLogs = await _context.LoggingEntries
            .Where(entry => entry.DepartmentId == departmentId)
            .Select(entry => entry.UserId)
            .ToListAsync(cancellationToken);

        var userIds = userIdsWithLogs.Distinct().ToList();

        var users = await _context.User
            .Where(user => userIds.Contains(user.Id))
            .ToListAsync(cancellationToken);

        return users;
    }

    public async Task<List<User>> GetUsersTogetherWithDepartmentLogsAsync(int departmentId, CancellationToken cancellationToken)
    {
        var userIdsWithLogs = await _context.LoggingEntries
            .Where(entry => entry.DepartmentId == departmentId)
            .Select(entry => entry.UserId)
            .ToListAsync(cancellationToken);

        var userIds = userIdsWithLogs.Distinct().ToList();

        var users = await _context.User
            .Where(user => userIds.Contains(user.Id))
            .Include(user => user.LogEntries
                .Where(loggingEntry => loggingEntry.DepartmentId == departmentId))
            .ToListAsync(cancellationToken);

        return users;
    }
}
