namespace SunamoDateTime.Converters;

/// <summary>
/// Represents the unix date converter type.
/// </summary>
public class UnixDateConverter
{
    /// <summary>
    /// To.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The to result.</returns>
    public static long To(DateTime dateTime)
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
        var unixTimestamp = System.Convert.ToInt64((dateTime - unixEpoch).TotalSeconds);

        return unixTimestamp;
    }

    /// <summary>
    /// From.
    /// </summary>
    /// <param name="timestamp">The timestamp.</param>
    /// <returns>The from result.</returns>
    public static DateTime From(long timestamp)
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        return unixEpoch.AddSeconds(timestamp);
    }
}
