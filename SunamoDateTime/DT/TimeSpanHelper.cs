// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoDateTime.DT;

public class TimeSpanHelper
{
    public static TimeSpan Parse(string span)
    {
        TimeSpan ts = new TimeSpan(int.Parse(span.Split(':')[0]),    // hours
        int.Parse(span.Split(':')[1]),    // minutes
        0);
        return ts;
    }
}
