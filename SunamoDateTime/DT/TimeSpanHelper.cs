namespace SunamoDateTime.DT;

public class TimeSpanHelper
{
    public static TimeSpan Parse(string span)
    {
        var parts = span.Split(':');
        return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
    }
}
