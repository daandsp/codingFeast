using Domain.Constants;

namespace Domain.Entities;

public class Reservation
{
    public int Id { get; set; }
    public string InstructorId { get; set; }
    public DateTime StartTime { get; set; }
    public ReservationType ReservationType { get; set; }

    public DateTime EndTime => GetEndTime();

    public ApplicationUser Instructor { get; set; }


    private DateTime GetEndTime()
    {
        return StartTime.Hour switch
        {
            CarReservationTimes.Morning => StartTime.AddHours(4),
            CarReservationTimes.Afternoon => StartTime.AddHours(6),
            CarReservationTimes.Evening => StartTime.AddHours(4),
            _ => throw new InvalidOperationException()
        };
    }
}

