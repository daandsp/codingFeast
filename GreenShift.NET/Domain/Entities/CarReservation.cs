namespace Domain.Entities;

public class CarReservation
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int ReservationId { get; set; }

    public Car Car { get; set; }
    public Reservation Reservation { get; set; }
}
