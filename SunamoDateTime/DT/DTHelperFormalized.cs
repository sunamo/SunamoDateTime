namespace SunamoDateTime.DT;

/// <summary>
/// Represents the DT helper formalized type.
/// </summary>
public class DTHelperFormalized
{
    #region ToString
    #region Date with time (without seconds)
    // 2011-10-18 10:30
    /// <summary>
    /// Format date time.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <param name="fullCalendar">The full calendar.</param>
    /// <returns>The format date time result.</returns>
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
    // 1989-06-21
    /// <summary>
    /// Date time to string formalize date.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The date time to string formalize date result.</returns>
    public static string DateTimeToStringFormalizeDate(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2");
    }
    #endregion
    #endregion

    #region Parse
    // Is used in GpxTrackFile
    // 2018-08-10T11:33:19Z
    /// <summary>
    /// String to date time formalize date.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The string to date time formalize date result.</returns>
    public static DateTime StringToDateTimeFormalizeDate(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return DateTime.MinValue;
        }

        if (DateTime.TryParse(text, null, System.Globalization.DateTimeStyles.None, out var result))
        {
            return result;
        }

        return DateTime.MinValue;
    }
    #endregion

    // Formats a DateTime as a dashed date string (yyyy-MM-dd). Alias for DateTimeToStringFormalizeDate.
    /// <summary>
    /// Date time to string dashed.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The date time to string dashed result.</returns>
    public static string DateTimeToStringDashed(DateTime dt)
    {
        return DateTimeToStringFormalizeDate(dt);
    }

    // Checks whether the text can be parsed as a formalized date.
    /// <summary>
    /// Is formalized date.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is formalized date result.</returns>
    public static bool IsFormalizedDate(string text)
    {
        var dateTime = DTHelperFormalized.StringToDateTimeFormalizeDate(text);
        return dateTime != DateTime.MinValue;
    }
}
