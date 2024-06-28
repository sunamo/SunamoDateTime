namespace SunamoDateTime;


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
    internal static string ToNiceString(this TimeSpan timeSpan)
    {
        string ret = timeSpan.ToString();
        string secondPostfix = ":00";
        if (ret.EndsWith(secondPostfix))
        {
            ret = ret.Substring(0, ret.Length - secondPostfix.Length);
        }
        return ret;
    }
}