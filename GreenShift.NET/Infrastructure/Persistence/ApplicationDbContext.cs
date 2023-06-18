using Application.Common.Interfaces;
using Domain.Entities;
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

    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<CombiDeal> CombiDeals => Set<CombiDeal>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<CarReservation> CarReservations => Set<CarReservation>();
    public DbSet<StudentCombiDealClaim> StudentCombiDealClaims => Set<StudentCombiDealClaim>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Car>().ToTable(nameof(Car));
        builder.Entity<Lesson>().ToTable(nameof(Lesson));
        builder.Entity<CombiDeal>().ToTable(nameof(CombiDeal));
        builder.Entity<Reservation>().ToTable(nameof(Reservation));
        builder.Entity<CarReservation>().ToTable(nameof(CarReservation));
        builder.Entity<StudentCombiDealClaim>().ToTable(nameof(StudentCombiDealClaim));
    }
}