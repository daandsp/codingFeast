using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IUserService
{
    public Task<bool> UpdateAsync(User user, CancellationToken cancellationToken);
    public Task<User> CreateAsync(User user, CancellationToken cancellationToken);
    public Task<User?> GetByDiscordIdAsync(ulong discordUserId, CancellationToken cancellationToken);
    public Task<User> GetAsync(ulong guildUserId, ulong robloxId, CancellationToken cancellationToken);
    public Task<User> GetByLoggingEntryIdAsync(int entryId, CancellationToken cancellationToken);
    public Task<List<User>> GetUsersWithDepartmentLogsAsync(int departmentId, CancellationToken cancellationToken);
    public Task<List<User>> GetUsersTogetherWithDepartmentLogsAsync(int departmentId, CancellationToken cancellationToken);
}
