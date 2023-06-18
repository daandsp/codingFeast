using Domain.Entities;

namespace Application.Common.ExtensionMethods;

public static class LoggingEntryExtensionMethods
{
    public static TimeSpan GetLoggingTotal(this List<LoggingEntry> loggingEntries)
    {
        return TimeSpan.FromSeconds(loggingEntries.Select(entry => Convert.ToInt64(entry.GetIntervalDurationInMs() / 1000)).Sum());
    }
}
