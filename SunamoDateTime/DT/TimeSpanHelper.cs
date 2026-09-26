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
        var parts = span.Split(':');
        return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
    }
}