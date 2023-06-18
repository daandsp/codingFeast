namespace Bloxmod.Models.Roblox
{
    using Newtonsoft.Json;

    public partial class RobloxUserDetails
    {
        [JsonProperty("description")]
        public string? Description { get; set; } = null;

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("isBanned")]
        public bool IsBanned { get; set; }

        [JsonProperty("externalAppDisplayName")]
        public object ExternalAppDisplayName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public partial class RobloxUserDetails
    {
        public static RobloxUserDetails FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RobloxUserDetails>(json, Converter.Settings);
        }
    }
}
