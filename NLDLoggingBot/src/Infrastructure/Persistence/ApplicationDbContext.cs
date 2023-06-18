using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Identity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }

    public DbSet<User> User => Set<User>();
    public DbSet<Department> Department => Set<Department>();
    public DbSet<DepartmentGuild> DepartmentGuilds => Set<DepartmentGuild>();
    public DbSet<DepartmentChannel> DepartmentChannels => Set<DepartmentChannel>();
    public DbSet<LoggingEntry> LoggingEntries => Set<LoggingEntry>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable(nameof(User));
        builder.Entity<Department>().ToTable(nameof(Department));
        builder.Entity<DepartmentGuild>().ToTable(nameof(DepartmentGuild));
        builder.Entity<DepartmentChannel>().ToTable(nameof(DepartmentChannels));
        builder.Entity<LoggingEntry>().ToTable(nameof(LoggingEntry));
    }
}