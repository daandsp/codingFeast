using Domain.Utilities;

namespace Domain.Common;

public class IntervalUsingEntityBase : EntityBase
{
    public ulong IntervalStart { get; set; } = 0;
    public ulong? IntervalEnd { get; set; }


    public IntervalUsingEntityBase(ulong intervalStart)
    {
        IntervalStart = intervalStart;
    }

    public IntervalUsingEntityBase(ulong intervalStart, ulong intervalEnd)
    {
        IntervalStart = intervalStart;
        IntervalEnd = intervalEnd;
    }

    public IntervalUsingEntityBase(TimeSpan timeSpan)
    {
        IntervalEnd = Convert.ToUInt64(timeSpan.TotalMilliseconds);
    }

    public TimeSpan GetIntervalDuration()
    {
        return TimeSpan.FromMilliseconds(IntervalEnd ?? TimeHelper.GetEpochms() - IntervalStart);
    }

    public ulong GetIntervalDurationInMs()
    {
        return IntervalEnd ?? TimeHelper.GetEpochms() - IntervalStart;
    }
}
