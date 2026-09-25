namespace SunamoDateTime.Converters;

public class UnixDateConverter
{
    public static long To(DateTime dateTime)
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
        var unixTimestamp = System.Convert.ToInt64((dateTime - unixEpoch).TotalSeconds);

        return unixTimestamp;
    }

    public static DateTime From(long timestamp)
    {
        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        return unixEpoch.AddSeconds(timestamp);
    }
}
