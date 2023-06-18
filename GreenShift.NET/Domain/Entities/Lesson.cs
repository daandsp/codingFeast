using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Lesson
{
    public int Id { get; set; }
    public string? StudentId { get; set; }
    public LessonType LessonType { get; set; }
    public int ReservationId { get; set; }
    public bool? CancelledOnTime { get; set; } = null;

    [MaxLength(250)]
    public string? StudentNote { get; set; }

    [MaxLength(250)]
    public string? InstructorNote { get; set; }


    public ApplicationUser Student { get; set; }
    public Reservation Reservation { get; set; }
}