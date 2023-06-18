namespace Domain.Entities;

public class Department : EntityBase
{
    public string Name { get; set; }


    public List<DepartmentGuild> DepartmentDiscords { get; set; } = new List<DepartmentGuild>();
    public List<LoggingEntry> LogEntries { get; set; } = new List<LoggingEntry>();


    public Department(string name)
    {
        Name = name;
    }
}
