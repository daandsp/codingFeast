using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ApplicationUser> ApplicationUsers { get; }
    DbSet<Car> Cars { get; }
    DbSet<Lesson> Lessons { get; }
    DbSet<CombiDeal> CombiDeals { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<CarReservation> CarReservations { get; }
    DbSet<StudentCombiDealClaim> StudentCombiDealClaims { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    void RemoveRange(IEnumerable<object> entities);
}
