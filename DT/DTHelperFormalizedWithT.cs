namespace SunamoDateTime.DT;


/// <summary>
/// Methods which in string result have T as delimiter date and time
/// Next relative methods are in DTHelperFormalized / DTHelperCode
/// </summary>
public partial class DTHelperFormalizedWithT
{
    #region ToString
    /// <summary>
    /// 1989-06-21T00:00:00.000Z (Z/TZD/+hh:mm/-hh:mm - timezone designation)
    /// </summary>
    /// <param name="dt"></param>
    public static string DateTimeToStringStringifyDateEmptyTime(DateTime dt)
    {
        return dt.Year + AllStrings.dash + dt.Month.ToString("D2") + AllStrings.dash + dt.Day.ToString("D2") + "T00:00:00.000Z";
    }

    /// <summary>
    /// 1989-06-21Thh:mm:ss.000Z
    /// </summary>
    /// <param name="dt"></param>
    public static string DateTimeToStringStringifyDateTime(DateTime dt)
    {
        return dt.Year + AllStrings.dash + dt.Month.ToString("D2") + AllStrings.dash + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + AllStrings.colon + dt.Minute.ToString("D2") + AllStrings.colon + dt.Second.ToString("D2") + AllStrings.dot + dt.Millisecond.ToString("D3") + "Z";
    }

    /// <summary>
    /// 1989-06-21T11:22:00
    /// </summary>
    /// <param name = "dt"></param>
    public static string DateAndTimeToStringFormalizeDate(DateTime dt)
    {
        return dt.Year + AllStrings.dash + dt.Month.ToString("D2") + AllStrings.dash + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + AllStrings.colon + dt.Minute.ToString("D2") + AllStrings.colon + dt.Second.ToString("D2");
    }
    #endregion
}
