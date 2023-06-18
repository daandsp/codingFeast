using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IDepartmentService
{
    public Task<bool> DeleteByIdAsync(int departmentId, CancellationToken cancellationToken);
    public Task<bool> DeleteByGuildIdAsync(ulong guildId, CancellationToken cancellationToken);
    public Task<Department> CreateAsync(Department department, CancellationToken cancellationToken);
    public Task<Department?> GetByIdAsync(int departmentId, CancellationToken cancellationToken);
    public Task<Department?> GetByGuildIdAsync(ulong guildId, CancellationToken cancellationToken);
    public Task<Department?> GetByChannelIdAsync(ulong channelId, CancellationToken cancellationToken);
}
