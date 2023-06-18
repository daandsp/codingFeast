namespace Domain.Entities;

public class DepartmentGuild : EntityBase
{
    public ulong GuildId { get; set; }
    public int? DepartmentId { get; set; }
    public Permissions Permissions { get; set; }

    public Department? Department { get; set; }


    public DepartmentGuild(ulong guildId,
        Permissions permissions)
    {
        GuildId = guildId;
        Permissions = permissions;
    }

    public DepartmentGuild(ulong guildId, int departmentId, 
        Permissions permissions)
    {
        GuildId = guildId;
        DepartmentId = departmentId;
        Permissions = permissions;
    }
}
