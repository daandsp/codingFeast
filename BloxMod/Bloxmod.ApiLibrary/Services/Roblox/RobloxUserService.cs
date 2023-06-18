using Bloxmod.ApiLibrary.Interfaces.Roblox;
using Bloxmod.ApiLibrary.Models;
using RestSharp;

namespace Bloxmod.ApiLibrary.Services.Roblox
{
    public class RobloxUserService : IRobloxUserService
    {
        public async Task<RobloxUserInformation> GetRobloxUserByNameOrIdAsync(string robloxNameRobloxId)
        {
            int userId;
            bool isId = int.TryParse(robloxNameRobloxId, out userId);

            if (!isId)
            {
                var url = $"https://api.roblox.com/users/get-by-username?username={robloxNameRobloxId}";
                var client = new RestClient(url);
                var request = new RestRequest();

                var response = await client.GetAsync(request);
                var content = Newtonsoft.Json.JsonConvert.DeserializeObject<RobloxUser>(response.Content);

                userId = content.Id;
            }

            try
            {
                var url = $"https://users.roblox.com/v1/users/{userId}";
                var client = new RestClient(url);
                var request = new RestRequest();

                var response = await client.GetAsync(request);
                var content = Newtonsoft.Json.JsonConvert.DeserializeObject<RobloxUserInformation>(response.Content);

                return content is null ? null : content;
            }
            catch
            {
                return null;
            }
        }

        public async Task<RobloxUserThumbnail> GetRobloxUserThumbnailAsync(int robloxId)
        {
            var url = $"https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds={robloxId}&size=100x100&format=Png&isCircular=false";
            var client = new RestClient(url);
            var request = new RestRequest();

            var response = await client.GetAsync(request);
            var content = Newtonsoft.Json.JsonConvert.DeserializeObject<RobloxUserThumbnail>(response.Content);

            return content is null ? null : content;
        }
    }
}
