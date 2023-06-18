namespace Bloxmod.Models
{
    using Bloxmod.Models.BoredAPI;
    using Newtonsoft.Json;

    public static class Serialize
    {
        public static string ToJson(this Event self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
