using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> User { get; }
    DbSet<Department> Department { get; }
    DbSet<DepartmentGuild> DepartmentGuilds { get; }
    DbSet<DepartmentChannel> DepartmentChannels { get; }
    DbSet<LoggingEntry> LoggingEntries { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    void RemoveRange(IEnumerable<object> entities);
}
