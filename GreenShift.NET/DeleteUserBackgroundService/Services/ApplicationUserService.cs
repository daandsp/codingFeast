using Application.Common.Interfaces;
using DeleteUserBackgroundService.Services.Interfaces;
using Domain.Constants;
using Domain.Entities;
using IdentityModel;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DeleteUserBackgroundService.Services;

internal class ApplicationUserService : IApplicationUserService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public ApplicationUserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _context = context;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<List<string>> GetInactiveUsersAsync(CancellationToken cancellation)
    {
        return await _context.ApplicationUsers
            .Where(user => user.InactiveSince != null)
            .Select(user => user.Id)
            .ToListAsync(cancellation);
    }

    public async Task DeleteSingleUserAsync(string userId, CancellationToken cancellation)
    {
        var studentDeletionMonths = _configuration.GetValue<int>("ApplicationSettings:DeleteStudentsAfterMonths");
        var instructorDeletionMonths = _configuration.GetValue<int>("ApplicationSettings:DeleteInstructorsAfterMonths");

        var studentDeletionEpoch = new DateTime(0, studentDeletionMonths, 0).ToEpochTime();
        var instructorDeletionEpoch = new DateTime(0, instructorDeletionMonths, 0).ToEpochTime();

        var currentEpoch = DateTime.Now.ToEpochTime();

        var user = await _userManager.FindByIdAsync(userId);
        var isStudent = await _userManager.IsInRoleAsync(user, Roles.Student);
        var isInstructor = await _userManager.IsInRoleAsync(user, Roles.Instructor);

        var userEpoch = user.InactiveSince?.ToEpochTime();


        if ((isInstructor && currentEpoch - userEpoch < instructorDeletionEpoch) || (isStudent && currentEpoch - userEpoch < studentDeletionEpoch))
        {
            return;
        }

        user.LockoutEnabled = true;
        user.UserName = $"Deleted User#{userId}";
        user.Infix = null;
        user.FirstName = user.UserName;
        user.LastName = Guid.NewGuid().ToString();
        user.Address = Guid.NewGuid().ToString();
        user.BankingInfo = Guid.NewGuid().ToString();
        user.IsDeleted = true;

        await _context.SaveChangesAsync(cancellation);
    }
}
