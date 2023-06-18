namespace Application.Common.Models.ApiModels;

public class BloxLinkResponse
{
    public bool success { get; set; }
    public BloxLinkRobloxUser user { get; set; }
}

public class BloxLinkRobloxUser
{
    public string robloxId { get; set; }
    public string primaryAccount { get; set; }
}
