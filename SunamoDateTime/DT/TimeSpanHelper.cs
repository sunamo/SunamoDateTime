namespace SunamoDateTime.DT;

/// <summary>
/// Provides helper methods for parsing TimeSpan values from strings.
/// </summary>
public class TimeSpanHelper
{
    /// <summary>
    /// Parses a time string in HH:mm format into a TimeSpan.
    /// </summary>
    /// <param name="span">The time string in HH:mm format</param>
    /// <returns>A TimeSpan representing the parsed hours and minutes</returns>
    public static TimeSpan Parse(string span)
    {
        TimeSpan result = new TimeSpan(int.Parse(span.Split(':')[0]),    // hours
        int.Parse(span.Split(':')[1]),    // minutes
        0);
        return result;
    }
}