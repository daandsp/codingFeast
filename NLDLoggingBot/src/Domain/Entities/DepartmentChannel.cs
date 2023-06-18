namespace Domain.Entities;

public class DepartmentChannel : EntityBase
{
    public ulong ChannelId { get; set; }
    public int DepartmentId { get; set; }
    public int DepartmentGuildId { get; set; }
    public Permissions Permissions { get; set; }

    public Department Department { get; set; }
    public DepartmentGuild DepartmentGuild { get; set; }


    public DepartmentChannel(ulong channelId, int departmentId, 
        int departmentGuildId, Permissions permissions)
    {
        ChannelId = channelId;
        DepartmentId = departmentId;
        DepartmentGuildId = departmentGuildId;
        Permissions = permissions;
    }
}
