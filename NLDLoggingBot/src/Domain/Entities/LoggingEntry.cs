namespace Domain.Entities;

public class LoggingEntry : IntervalUsingEntityBase
{
    public int DepartmentId { get; init; }
    public int UserId { get; init; }
    //public LoggingEntryType EntryType { get; init; }
    public DateTime DateCreated { get; init;  } = DateTime.Now;

    public Department Department { get; set; }
    public User User { get; set; }


    public LoggingEntry(int departmentId, int userId, ulong intervalStart)
        :base(intervalStart)
    {
        DepartmentId = departmentId;
        UserId = userId;
        //EntryType = type;
    }

    public LoggingEntry(int departmentId, int userId, ulong intervalStart, ulong intervalEnd)
        : base(intervalStart, intervalEnd)
    {
        DepartmentId = departmentId;
        UserId = userId;
        //EntryType = type;
    }

    public LoggingEntry(int departmentId, int userId, TimeSpan timeSpan)
        : base(timeSpan)
    {
        DepartmentId = departmentId;
        UserId = userId;
        //EntryType = type;
    }

}
