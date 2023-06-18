using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class CombiDeal
{
    public int Id { get; set; }

    [MaxLength(30)]
    public string Name { get; set; }

    [MaxLength(2)]
    public int DiscountPercentage { get; set; }

    [MaxLength(3)]
    public int AmountOfLessons { get; set; }
}
