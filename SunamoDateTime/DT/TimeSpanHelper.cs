// variables names: ok
namespace SunamoDateTime.DT;

public class TimeSpanHelper
{
    public static TimeSpan Parse(string span)
    {
        TimeSpan result = new TimeSpan(int.Parse(span.Split(':')[0]),    // hours
        int.Parse(span.Split(':')[1]),    // minutes
        0);
        return result;
    }
}