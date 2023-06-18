using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string? Infix { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? BankingInfo { get; set; }
    public DateTime? InactiveSince { get; set; } = null;
    public bool IsDeleted { get; set; } = false;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public ApplicationUser() { }

    public ApplicationUser(string firstName, string infix, string lastName, string email, string phoneNumber, DateTime dateOfBirth)
    {
        UserName = firstName;
        FirstName = firstName;
        Infix = infix.Length > 0 ? infix : null;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }

    public ApplicationUser(string firstName, string infix, string lastName, string email, string phoneNumber, string bankingInfo)
    {
        UserName = firstName;
        FirstName = firstName;
        Infix = infix.Length > 0 ? infix : null;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        BankingInfo = bankingInfo;
    }

    public string GetFullName()
    {
        var infix = Infix == null ? " " : " " + Infix + " ";
        return $"{FirstName}{infix}{LastName}";
    }
}
