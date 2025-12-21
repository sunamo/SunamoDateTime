namespace SunamoDateTime.DT;

public class DTHelperFormalized
{
    #region ToString
    #region Date with time (without seconds)
    /// <summary>
    /// 2011-10-18 10:30
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="fullCalendar"></param>
    public static string FormatDateTime(DateTime dt, DateTimeFormatStyles fullCalendar)
    {
        if (fullCalendar == DateTimeFormatStyles.FullCalendar)
        {
            //2011-10-18 10:30
            return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + " " + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2");
        }

        return "";
    }
    #endregion

    #region Date
    /// <summary>
    /// 1989-06-21
    /// </summary>
    /// <param name = "dt"></param>
    public static string DateTimeToStringFormalizeDate(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2");
    }
    #endregion
    #endregion

    #region Parse
    /// <summary>
    /// Is used in GpxTrackFile
    /// 2018-08-10T11:33:19Z
    ///
    /// </summary>
    /// <param name="p"></param>
    public static DateTime StringToDateTimeFormalizeDate(string p)
    {
        if (string.IsNullOrEmpty(p))
        {
            return DateTime.MinValue;
        }

        if (DateTime.TryParse(p, null, out var result/*, System.Globalization.DateTimeStyles.None*/))
        {
            return result;
        }

        return DateTime.MinValue;
    }
    #endregion

    public static string DateTimeToStringDashed(DateTime dt)
    {
        return DateTimeToStringFormalizeDate(dt);
    }

    public static bool IsFormalizedDate(string v)
    {
        var dt = DTHelperFormalized.StringToDateTimeFormalizeDate(v);
        return dt != DateTime.MinValue;
    }
}