namespace SunamoDateTime.DT;

public partial class DTHelperGeneral
{
    /// <summary>
    /// Time in ms to seconds.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <returns>The time in ms to seconds result.</returns>
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
    /// Calculate age string.
    /// </summary>
    /// <param name="bday">The bday.</param>
    /// <param name="dtMinVal">The dt min val.</param>
    /// <returns>The calculate age string result.</returns>
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
    /// Today plus actual hour.
    /// </summary>
    /// <returns>The today plus actual hour result.</returns>
    public static DateTime TodayPlusActualHour()
    {
        DateTime dt = DateTime.Today;
        return dt.AddHours(DateTime.Now.Hour);
    }

    /// <summary>
    /// Combine.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <param name="time">The time.</param>
    /// <returns>The combine result.</returns>
    public static DateTime Combine(DateTime result, DateTime time)
    {
        result.AddHours(time.Hour);
        result.AddMinutes(time.Minute);
        result.AddSeconds(time.Second);
        result.AddMilliseconds(time.Millisecond);
        return result;
    }
}
