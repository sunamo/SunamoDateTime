namespace SunamoDateTime.Converters;

/// <summary>
/// Unix timestamp converter.
/// EN: Converts between DateTime and Unix timestamp (seconds since 1970-01-01).
/// CZ: Převádí mezi DateTime a Unix timestampem (sekundy od 1970-01-01).
/// </summary>
public class UnixDateConverter
{
    /// <summary>
    /// Converts DateTime to Unix timestamp.
    /// EN: Returns number of seconds since Unix epoch (1970-01-01 00:00:00).
    /// CZ: Vrací počet sekund od Unix epoch (1970-01-01 00:00:00).
    /// </summary>
    /// <param name="dateTime">The DateTime to convert</param>
    /// <returns>Unix timestamp in seconds</returns>
    public static long To(DateTime dateTime)
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
        var unixTimestamp = System.Convert.ToInt64((dateTime - unixEpoch).TotalSeconds);

        return unixTimestamp;
    }

    /// <summary>
    /// Converts Unix timestamp to DateTime.
    /// EN: Creates DateTime by adding timestamp seconds to Unix epoch (1970-01-01 00:00:00).
    /// CZ: Vytvoří DateTime přidáním timestamp sekund k Unix epoch (1970-01-01 00:00:00).
    /// </summary>
    /// <param name="timestamp">Unix timestamp in seconds</param>
    /// <returns>DateTime representation of the timestamp</returns>
    public static DateTime From(long timestamp)
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        return unixEpoch.AddSeconds(timestamp);
    }
}