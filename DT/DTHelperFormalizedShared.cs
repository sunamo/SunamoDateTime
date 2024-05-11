namespace SunamoDateTime;


public partial class DTHelperFormalized
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
            return dt.Year + AllStrings.dash + dt.Month.ToString("D2") + AllStrings.dash + dt.Day.ToString("D2") + AllStrings.space + dt.Hour.ToString("D2") + AllStrings.colon + dt.Minute.ToString("D2");
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
        return dt.Year + AllStrings.dash + dt.Month.ToString("D2") + AllStrings.dash + dt.Day.ToString("D2");
    }
    #endregion
    #endregion
}
