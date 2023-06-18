using Bloxmod.Data.Context;
using Bloxmod.Data.Interfaces;

namespace Bloxmod.Data
{
    public class DataAccessLayer
    {
        private readonly BloxmodDbContext _context;

        public DataAccessLayer(BloxmodDbContext context)
        {
            _context = context;
        }

        //public async Task CreateGuild(ulong id)
        //{
        //    await using var context = _context.CreateDbContext();
        //    if (context.Guilds.Any(x => x.Id == id))
        //        return;

        //    context.Add(new Guild {Id = id});
        //    await context.SaveChangesAsync();
        //}

        //public string GetPrefix(ulong id)
        //{
        //    using var context = _context.CreateDbContext();
        //    var guild = context.Guilds
        //        .SingleOrDefault(x => x.Id == id);


        //    if (guild == null)
        //    {
        //        context.Add(new Guild { Id = id });
        //        context.SaveChanges();
        //    }

        //    return guild.Prefix;
        //}

        //public async Task SetPrefix(ulong id, string prefix)
        //{
        //    await using var context = _context.CreateDbContext();
        //    var guild = context.Guilds
        //        .SingleOrDefault(x => x.Id == id);

        //    if (guild != null)
        //    {
        //        var votingInDb = context.Guilds.Single(c => c.Id == id);
        //        votingInDb.Prefix = prefix;
        //    }
        //    else
        //    {
        //        context.Add(new Guild {Id = id, Prefix = prefix});
        //    }

        //    await context.SaveChangesAsync();
        //}

        //public async Task DeleteGuild(ulong id)
        //{
        //    await using var context = _context.CreateDbContext();
        //    var guild = context.Guilds
        //        .SingleOrDefault(x => x.Id == id);

        //    if (guild == null)
        //        return;

        //    context.Remove(guild);
        //    await context.SaveChangesAsync();
        //}

        //public async Task SetTrelloKeys(ulong id, string userKey, string apiToken, string boardId)
        //{
        //    await using var context = _context.CreateDbContext();
        //    var existingGuildKeys = context.GuildTrelloKeys
        //        .SingleOrDefault(x => x.Id == id);

        //    if (existingGuildKeys != null)
        //    {
        //        var inDatabase = context.GuildTrelloKeys.Single(c => c.Id == id);
        //        inDatabase.Id = id;
        //        inDatabase.APIToken = apiToken;
        //        inDatabase.BoardId = boardId;
        //        inDatabase.UserKey = userKey;

        //    }
        //    else if (existingGuildKeys == null)
        //    {
        //        context.Add(new GuildTrelloKey { Id = id, APIToken = apiToken, BoardId = boardId, UserKey = userKey});
        //    }

        //    await context.SaveChangesAsync();
        //}

        //public GuildTrelloKey GetTrelloKeys(ulong id)
        //{
        //    using var context = _context.CreateDbContext();
        //    var guildKeys = context.GuildTrelloKeys
        //        .SingleOrDefault(x => x.Id == id);

        //    if (guildKeys == null)
        //    {
        //        return null;
        //    }

        //    return guildKeys;
        //}

        //public async Task NewGuildRobloxBan(ulong id, string user, string reason, string moderator, double? banTime)
        //{
        //    await using var context = _context.CreateDbContext();
        //    DateTime unbanDate = DateTime.Now;

        //    if (banTime != null)
        //    {
        //        DateTime today = DateTime.Now;
        //        unbanDate = today.AddDays((double)banTime);
        //    }

        //    context.Add(new GuildRobloxBan { GuildId = id, UserId = user, Reason = reason, Moderator = moderator, UnbanDateTime = unbanDate });

        //    await context.SaveChangesAsync();
        //}

        //public GuildRobloxBan GetGuildRobloxBans(ulong id, string user)
        //{
        //    using var context = _context.CreateDbContext();
        //    var GuildRobloxBans = context.GuildRobloxBans
        //        .Where(x => x.GuildId == id && x.UserId == user);

        //    if (GuildRobloxBans == null)
        //    {
        //        return null;
        //    }

        //    return (GuildRobloxBan)GuildRobloxBans;
        //}
    }
}
