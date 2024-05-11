namespace SunamoDateTime;


public partial class DTHelperCode
{
    #region ToString
    #region Time (with seconds)
    /// <summary>
    /// 12:00:00
    /// </summary>
    /// <param name="dt"></param>
    public static string TimeToStringAngularTime(DateTime dt)
    {
        return dt.Hour.ToString("D2") + AllStrings.colon + dt.Minute.ToString("D2") + AllStrings.colon + dt.Second.ToString("D2");
    }
    #endregion

    #region Date and time (with seconds)
    /// <summary>
    /// 19890621T00:00:00
    /// </summary>
    /// <param name="dt"></param>
    public static string DateToStringAngularDate(DateTime dt)
    {
        return dt.Year + dt.Month.ToString("D2") + dt.Day.ToString("D2") + "T00:00:00";
    }
    #endregion
    #endregion
}
