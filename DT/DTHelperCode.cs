namespace SunamoDateTime;


/// <summary>
/// For web frameworks - angular, jquery etc.
/// Must contains in header Input, Angular, jQuery, etc.
/// Next relative methods are in DTHelperFormalized / DTHelperFormalizedWithT
/// </summary>
public partial class DTHelperCode
{
    #region ToString
    #region Date with time (without seconds)
    /// <summary>
    /// 1989-06-21T11:22
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dtMinVal"></param>
    public static string DateTimeToStringToInputDateTimeLocal(DateTime dt, DateTime dtMinVal)
    {
        if (dt == dtMinVal)
        {
            return "";
        }
        return dt.Year + AllStrings.dash + dt.Month.ToString("D2") + AllStrings.dash + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + AllStrings.colon + dt.Minute.ToString("D2");
    }
    #endregion

    #region Only date
    /// <summary>
    /// mm/dd/yyyy
    ///
    /// Method will be always timeless! Also because of has in name only Date.
    /// Input in name mean that output of this method I will insert only to input, it dont mean anything method argument
    /// </summary>
    /// <param name="dt"></param>
    public static string DateToStringjQueryDatePicker(DateTime dt)
    {
        //return dt.Day.ToString("D2") + AllStrings.dot + dt.Month.ToString("D2") + AllStrings.dot + dt.Year;
        return dt.Month.ToString("D2") + AllStrings.slash + dt.Day.ToString("D2") + AllStrings.slash + dt.Year;
    }
    #endregion


    #region Date with time
    /// <summary>
    /// 19890621T11:22:00
    /// </summary>
    /// <param name="dt"></param>
    public static string DateAndTimeToStringAngularDateTime(DateTime dt)
    {
        return dt.Year + dt.Month.ToString("D2") + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + AllStrings.colon + dt.Minute.ToString("D2") + AllStrings.colon + dt.Second.ToString("D2");
    }
    #endregion
    #endregion
}
