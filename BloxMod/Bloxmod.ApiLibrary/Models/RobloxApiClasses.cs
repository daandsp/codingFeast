namespace Bloxmod.ApiLibrary.Models
{
    public class RobloxUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public object AvatarUri { get; set; }
        public bool AvatarFinal { get; set; }
        public bool IsOnline { get; set; }
    }

    public class RobloxUserInformation
    {
        public int id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
        public DateTime created { get; set; }
        public bool isBanned { get; set; }
        public bool hasVerifiedBadge { get; set; }
        public object externalAppDisplayName { get; set; }
    }

    public class Datum
    {
        public int targetId { get; set; }
        public string state { get; set; }
        public string imageUrl { get; set; }
    }

    public class RobloxUserThumbnail
    {
        public List<Datum> data { get; set; }
    }
}
