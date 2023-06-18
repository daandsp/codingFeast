using System.Linq.Expressions;

namespace Domain.Utilities;

public static class TimeHelper
{
    public const ulong MillisecondsInMinute = 3600000 / 60;
    public const ulong MillisecondsInQuarter = 3600000 / 4;
    public const ulong MillisecondsInHour = 3600000;
    public const ulong MillisecondsInDay = 3600000 * 24;

    public static ulong GetEpochms()
    {
        return GetEpochms(DateTime.UtcNow);
    }

    public static ulong GetEpochms(DateTime currentDateTime)
    {
        return (ulong)(currentDateTime - new DateTime(1970, 1, 1)).TotalMilliseconds;
    }

    public static ulong? MaxOrDefault<T>(this IQueryable<T> source, Expression<Func<T, ulong?>> selector, ulong? nullValue = null)
    {
        return source.Max(selector) ?? nullValue;
    }

    public static ulong GetLastFullHour(ulong currentEpoch)
    {
        return currentEpoch - (currentEpoch % MillisecondsInHour);
    }

    public static ulong GetPreviousFullHour(ulong currentEpoch)
    {
        return GetLastFullHour(currentEpoch) - MillisecondsInHour;
    }

    public static ulong GetNextFullHour(ulong currentEpoch)
    {
        return GetLastFullHour(currentEpoch) + MillisecondsInHour;
    }

    public static ulong GetLastFullDayUtcZero(ulong currentEpoch)
    {
        return currentEpoch - (currentEpoch % MillisecondsInDay);
    }

    public static ulong GetPreviousFullDayUtcZero(ulong currentEpoch)
    {
        return GetLastFullDayUtcZero(currentEpoch) - MillisecondsInDay;
    }

    public static ulong GetNextFullDayUtcZero(ulong currentEpoch)
    {
        return GetLastFullDayUtcZero(currentEpoch) + MillisecondsInDay;
    }

    public static ulong GetLastFullQuarter(ulong currentEpoch)
    {
        return currentEpoch - (currentEpoch % MillisecondsInQuarter);
    }

    public static ulong GetPreviousFullQuarter(ulong currentEpoch)
    {
        return GetLastFullQuarter(currentEpoch) - MillisecondsInQuarter;
    }

    public static ulong GetNextFullQuarter(ulong currentEpoch)
    {
        return GetLastFullQuarter(currentEpoch) + MillisecondsInQuarter;
    }

    public static ulong ApplyUtc(this ulong currentEpoch, double currentUtc)
    {
        return (ulong)(currentEpoch + (currentUtc * MillisecondsInHour));
    }

    public static ulong RemoveUtc(this ulong currentEpoch, double currentUtc)
    {
        return (ulong)(currentEpoch - (currentUtc * MillisecondsInHour));
    }

    public static DateTime EpochTimeStampToDateTimeSecond(ulong currentEpoch)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        dateTime = dateTime.AddSeconds(currentEpoch / 1000);
        return dateTime;
    }

    public static DateTime EpochTimeStampToDateTimeMillisecond(ulong currentEpoch)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        dateTime = dateTime.AddSeconds(currentEpoch / 1000);
        dateTime = dateTime.AddMilliseconds(currentEpoch % 1000);
        return dateTime;
    }
}

