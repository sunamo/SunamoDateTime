// variables names: ok
namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperGeneral
{
    public static string TimeInMsToSeconds(Stopwatch parameter)
    {
        var d2 = (double)parameter.ElapsedMilliseconds;
        parameter.Reset();
        string d = (d2 / 1000).ToString();
        if (d.Length > 4)
        {
            d = d.Substring(0, 4);
        }

        return d + "s";
    }

    public static string CalculateAgeString(DateTime bday, DateTime dtMinVal)
    {
        byte b = CalculateAge(bday, dtMinVal);
        if (b == 255)
        {
            return "";
        }

        return b.ToString();
    }

    public static DateTime TodayPlusActualHour()
    {
        DateTime dt = DateTime.Today;
        return dt.AddHours(DateTime.Now.Hour);
    }

    public static DateTime Combine(DateTime result, DateTime time)
    {
        result.AddHours(time.Hour);
        result.AddMinutes(time.Minute);
        result.AddSeconds(time.Second);
        result.AddMilliseconds(time.Millisecond);
        return result;
    }
}