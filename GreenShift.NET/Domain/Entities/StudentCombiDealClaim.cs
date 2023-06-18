namespace Domain.Entities;

public class StudentCombiDealClaim
{
    public int Id { get; set; }
    public string StudentId { get; set;}
    public int CombiDealId { get; set; }
    public DateTime PurchasedDate { get; set; }

    public ApplicationUser Student { get; set; }
    public CombiDeal CombiDeal { get; set; }
}
