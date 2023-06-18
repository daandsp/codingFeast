using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IDepartmentGuildService
{
    public Task<bool> DeleteByGuildIdAsync(ulong guildId, CancellationToken cancellationToken);
    public Task<DepartmentGuild> CreateAsync(DepartmentGuild departmentDiscord, CancellationToken cancellationToken);
    public Task<DepartmentGuild?> GetByGuildIdAsync(ulong guildId, CancellationToken cancellationToken);
    public Task<DepartmentGuild?> GetByIdAsync(int id, CancellationToken cancellationToken);
    public Task<DepartmentGuild?> GetPrimaryByDepartmentId(int departmentId, CancellationToken cancellationToken);
}
