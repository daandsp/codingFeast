using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Departments;

public class DepartmentsService : IDepartmentService
{
    private readonly IApplicationDbContext _context;

    public DepartmentsService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteByIdAsync(int departmentId, CancellationToken cancellationToken)
    {
        var objectToDelete = await _context.Department
            .FindAsync(new object?[] {departmentId}, cancellationToken);

        if (objectToDelete == null)
        {
            return false;
        }

        _context.Department.Remove(objectToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        var x = 4;

        return true;
    }

    public async Task<bool> DeleteByGuildIdAsync(ulong guildId, CancellationToken cancellationToken)
    {
        var objectToDelete = await _context.DepartmentGuilds
            .Include(departmentGuild => departmentGuild.Department)
            .Where(department => department.GuildId == guildId)
            .Select(departmentGuild => departmentGuild.Department)
            .FirstOrDefaultAsync(cancellationToken);

        if (objectToDelete == null)
        {
            return false;
        }

        _context.Department.Remove(objectToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<Department> CreateAsync(Department department, CancellationToken cancellationToken)
    {
        var created = await _context.Department.AddAsync(department, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return created.Entity;
    }

    public async Task<Department?> GetByIdAsync(int departmentId, CancellationToken cancellationToken)
    {
        return await _context.Department.FindAsync(new object?[] {departmentId}, cancellationToken);
    }

    public async Task<Department?> GetByGuildIdAsync(ulong guildId, CancellationToken cancellationToken)
    {
        return await _context.DepartmentGuilds
            .Include(departmentGuild => departmentGuild.Department)
            .Where(departmentGuild => departmentGuild.GuildId == guildId)
            .Select(departmentGuild => departmentGuild.Department)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<Department?> GetByChannelIdAsync(ulong channelId, CancellationToken cancellationToken)
    {
        return await _context.DepartmentChannels
            .Include(DepartmentChannel => DepartmentChannel.Department)
            .Where(departmentChannel => departmentChannel.ChannelId == channelId)
            .Select(departmentChannel => departmentChannel.Department)
            .SingleOrDefaultAsync(cancellationToken);
    }
}
