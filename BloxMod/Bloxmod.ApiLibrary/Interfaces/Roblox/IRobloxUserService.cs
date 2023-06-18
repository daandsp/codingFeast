using Bloxmod.ApiLibrary.Models;

namespace Bloxmod.ApiLibrary.Interfaces.Roblox
{
    public interface IRobloxUserService
    {
        Task<RobloxUserInformation> GetRobloxUserByNameOrIdAsync(string robloxNameRobloxId);
        Task<RobloxUserThumbnail> GetRobloxUserThumbnailAsync(int robloxId);
    }
}
