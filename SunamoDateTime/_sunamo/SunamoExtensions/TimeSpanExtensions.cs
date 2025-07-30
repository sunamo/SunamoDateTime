namespace SunamoDateTime._sunamo.SunamoExtensions;

internal static class TimeSpanExtensions
{
    #region For easy copy from TimeSpanExtensionsSunamo.cs
    internal static int TotalYears(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 365.2425);
    }
    internal static int TotalMonths(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 30.436875);
    }
    #endregion
}