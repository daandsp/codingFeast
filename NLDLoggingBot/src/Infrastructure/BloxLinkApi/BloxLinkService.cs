using Application.Common.Interfaces;
using Application.Common.Models.ApiModels;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Infrastructure.BloxLinkApi;

public class BloxLinkService : IBloxLinkApiService
{
    private readonly IConfiguration _configuration;

    public BloxLinkService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<BloxLinkRobloxUser?> GetRobloxIdByDiscordIdAsync(ulong discordId, CancellationToken cancellationToken)
    {
        const string url = $"https://v3.blox.link/developer/discord/";

        var client = new RestClient(url + discordId);
        var request = new RestRequest();

        request.AddHeader("api-key", _configuration.GetValue<string>("ApplicationSettings:BloxLinkApiToken"));

        var response = await client.GetAsync(request, cancellationToken);
        var content = response.Content;

        var model = Newtonsoft.Json.JsonConvert.DeserializeObject<BloxLinkResponse>(content);
        var robloxUser = model?.user;

        return robloxUser;
    }
}
