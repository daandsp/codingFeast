namespace GreenShift.NET.API.Models;

public class ApplicationUser
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public ApplicationUser(string username, string password)
    {
        UserName = username;
        Password = password;
    }
}

