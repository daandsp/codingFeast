using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DepartmentDiscords;

public class DepartmentDiscordsService : IDepartmentGuildService
{
    private readonly IApplicationDbContext _context;

    public DepartmentDiscordsService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteByGuildIdAsync(ulong guildId, CancellationToken cancellationToken)
    {
        var departmentDiscordToDelete = await _context.DepartmentGuilds
            .FirstOrDefaultAsync(department => department.GuildId == guildId, cancellationToken);

        if (departmentDiscordToDelete == null)
        {
            return false;
        }

        _context.DepartmentGuilds.Remove(departmentDiscordToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<DepartmentGuild> CreateAsync(DepartmentGuild departmentDiscord, CancellationToken cancellationToken)
    {
        var created = await _context.DepartmentGuilds.AddAsync(departmentDiscord, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return created.Entity;
    }

    public async Task<DepartmentGuild?> GetByGuildIdAsync(ulong guildId, CancellationToken cancellationToken)
    {
        return await _context.DepartmentGuilds
            .Where(department => department.GuildId == guildId)
            .Include(department => department.Department)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<DepartmentGuild?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.DepartmentGuilds
            .Where(department => department.Id == id)
            .Include(department => department.Department)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<DepartmentGuild?> GetPrimaryByDepartmentId(int departmentId, CancellationToken cancellationToken)
    {
        return await _context.DepartmentGuilds
            .Where(department => department.DepartmentId == departmentId
                                && department.Permissions == Permissions.FullAccess)
            .Include(department => department.Department)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
