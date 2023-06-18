using Application.Common.Interfaces;
using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitializer(
        ILogger<ApplicationDbContextInitializer> logger,
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
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
            //await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        var adminRole = await _roleManager.FindByNameAsync(Roles.Admin);
        var instructorRole = await _roleManager.FindByNameAsync(Roles.Instructor);
        var studentRole = await _roleManager.FindByNameAsync(Roles.Student);

        if (adminRole == null)
        {
            await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }

        if (instructorRole == null)
        {
            await _roleManager.CreateAsync(new IdentityRole(Roles.Instructor));
        }

        if (studentRole == null)
        {
            await _roleManager.CreateAsync(new IdentityRole(Roles.Student));
        }

        var user = await _userManager.FindByNameAsync("Admin");
        if (user == null)
        {
            var newUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Greenshift@admin.nl",
                FirstName = "Admin",
                LastName = ""
            };

            var password = "Admin1@";

            await _userManager.CreateAsync(newUser, password);
            var createdUser = await _userManager.FindByIdAsync(newUser.Id);
            await _userManager.AddToRoleAsync(createdUser, Roles.Admin);
        }
    }
}
