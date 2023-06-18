namespace Bloxmod.Models.Roblox
{
    using Newtonsoft.Json;

    public partial class RobloxUser
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }
    }

    public partial class RobloxUser
    {
        public static RobloxUser FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RobloxUser>(json, Converter.Settings);
        }
    }
}
