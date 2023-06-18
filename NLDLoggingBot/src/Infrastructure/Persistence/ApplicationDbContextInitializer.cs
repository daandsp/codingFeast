using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
                _logger.LogInformation("Database is up to date");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        if (!await _context.Department.AnyAsync())
        {
            List<Department> departmentsToSeed = new()
            {
                new Department("Koninklijke Marechaussee"),
                new Department("Koninklijke Marine"),
                new Department("Koninklijke Luchtmacht"),
                new Department("Koninklijke Mariniers"),
                new Department("Koninklijke Nationale Politie"),
                new Department("Ambulance Zorg"),
                new Department("Brandweer"),
            };

            await _context.Department.AddRangeAsync(departmentsToSeed);
            await _context.SaveChangesAsync();
        }
    }
}
