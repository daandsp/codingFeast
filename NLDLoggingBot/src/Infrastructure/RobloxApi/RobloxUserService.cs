using Application.Common.Interfaces;
using Application.Common.Models.ApiModels;
using RestSharp;

namespace Infrastructure.RobloxApi;

public class RobloxUserService : IRobloxUserApiService
{
    private ulong UserId { get; set; } = 0;

    public async Task<RobloxUserAndImage> GetFullUserAsync(string nameOrId, CancellationToken cancellationToken)
    {
        return new RobloxUserAndImage()
        {
            RobloxUser = await GetBasicUserAsync(nameOrId, cancellationToken),
            Image = await GetUserImageByIdAsync(UserId, cancellationToken)
        };
    }

    public async Task<BasicRobloxUser> GetBasicUserAsync(string nameOrId, CancellationToken cancellationToken)
    {
        bool isId = ulong.TryParse(nameOrId, out var userId);
        RobloxUserAndImage robloxUser = new();

        if (!isId)
        {
            List<string> usernamesList = new() { nameOrId };

            const string url = "https://users.roblox.com/v1/usernames/users";
            var client = new RestClient(url);
            var request = new RestRequest()
                .AddBody(new GetMultipleUsersByUsername(usernamesList));

            try
            {
                var response = await client.PostAsync(request, cancellationToken);
                var content = Newtonsoft.Json.JsonConvert.DeserializeObject<BasicRobloxUserList>(response.Content);

                if (content != null)
                {
                    UserId = content.Data[0].Id;
                }

                return content!.Data[0];
            }
            catch
            {
                return new BasicRobloxUser("**Failed to fetch**");
            }
        }
        else
        {
            List<ulong> userIdsList = new() { userId };

            const string url = "https://users.roblox.com/v1/users";
            var client = new RestClient(url);
            var request = new RestRequest()
                .AddBody(new GetMultipleUsersById(userIdsList));

            try
            {
                var response = await client.PostAsync(request, cancellationToken);
                var content = Newtonsoft.Json.JsonConvert.DeserializeObject<BasicRobloxUserList>(response.Content);

                if (content != null)
                {
                    UserId = content.Data[0].Id;
                }

                return content!.Data[0];
            }
            catch
            {
                return new BasicRobloxUser("**Failed to fetch**");
            }
        }
    }

    public async Task<ImageInformation> GetUserImageByIdAsync(ulong Id, CancellationToken cancellationToken)
    {
        var url = $"https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds={Id}&size=100x100&format=Png&isCircular=false";
        var client = new RestClient(url);
        var request = new RestRequest();

        try
        {
            var response = await client.GetAsync(request, cancellationToken);
            var content = Newtonsoft.Json.JsonConvert.DeserializeObject<RobloxUserImages>(response.Content);

            return content!.Data[0];
        }
        catch
        {
            return new ImageInformation();
        }
    }
}
