namespace Application.Common.Models.ApiModels;

public class RobloxUser
{
    public ulong Id { get; set; }
    public string Username { get; set; }
    public object AvatarUri { get; set; }
    public bool AvatarFinal { get; set; }
    public bool IsOnline { get; set; }
}

public class RobloxUserInformation
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public bool IsBanned { get; set; }
    public bool HasVerifiedBadge { get; set; }
    public object ExternalAppDisplayName { get; set; }
}

public class BasicRobloxUser
{
    public bool HasVerifiedBadge { get; set; }
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }

    public BasicRobloxUser(string name)
    {
        Name = name;
    }
}

public class BasicRobloxUserList
{
    public List<BasicRobloxUser> Data { get; set; }
}

public class ImageInformation
{
    public ulong TargetId { get; set; }
    public string State { get; set; }
    public string ImageUrl { get; set; }
}

public class RobloxUserImages
{
    public List<ImageInformation> Data { get; set; }
}

public class GetMultipleUsersByUsername
{
    public List<string> Usernames { get; set; }

    public GetMultipleUsersByUsername(List<string> usernames)
    {
        Usernames = usernames;
    }
}

public class GetMultipleUsersById
{
    public List<ulong> UserIds { get; set; }

    public GetMultipleUsersById(List<ulong> userIds)
    {
        UserIds = userIds;
    }
}

public class RobloxUserAndImage
{
    public BasicRobloxUser RobloxUser { get; set; }
    public ImageInformation Image { get; set; }
}
