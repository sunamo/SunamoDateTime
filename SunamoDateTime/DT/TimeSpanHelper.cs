namespace SunamoDateTime.DT;

/// <summary>
/// Represents the time span helper type.
/// </summary>
public class TimeSpanHelper
{
    /// <summary>
    /// Parse.
    /// </summary>
    /// <param name="span">The span.</param>
    /// <returns>The parse result.</returns>
    public static TimeSpan Parse(string span)
    {
        var parts = span.Split(':');
        return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
    }
}
