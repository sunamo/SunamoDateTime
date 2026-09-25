namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperGeneral
{
    /// <summary>
    /// Converts elapsed milliseconds from a Stopwatch to a seconds string (e.g. "1.23s") and resets the Stopwatch.
    /// </summary>
    /// <param name="parameter">The Stopwatch to read and reset</param>
    /// <returns>Elapsed time in seconds as string with "s" suffix</returns>
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

    /// <summary>
    /// Calculates age from a birth date and returns it as a string. Returns empty string for unset dates (255).
    /// </summary>
    /// <param name="bday">The birth date</param>
    /// <param name="dtMinVal">The minimum DateTime value representing an unset date</param>
    /// <returns>Age as string, or empty string if date is unset</returns>
    public static string CalculateAgeString(DateTime bday, DateTime dtMinVal)
    {
        byte b = CalculateAge(bday, dtMinVal);
        if (b == 255)
        {
            return "";
        }

        return b.ToString();
    }

    /// <summary>
    /// Returns today's date with the current hour added.
    /// </summary>
    /// <returns>Today at the current hour</returns>
    public static DateTime TodayPlusActualHour()
    {
        DateTime dt = DateTime.Today;
        return dt.AddHours(DateTime.Now.Hour);
    }

    /// <summary>
    /// Combines the date part of the first DateTime with the time part of the second DateTime.
    /// </summary>
    /// <param name="result">The DateTime providing the date part</param>
    /// <param name="time">The DateTime providing the time part</param>
    /// <returns>Combined DateTime</returns>
    public static DateTime Combine(DateTime result, DateTime time)
    {
        result.AddHours(time.Hour);
        result.AddMinutes(time.Minute);
        result.AddSeconds(time.Second);
        result.AddMilliseconds(time.Millisecond);
        return result;
    }
}