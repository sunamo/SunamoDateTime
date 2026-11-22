namespace SunamoDateTime.DT;

/// <summary>
/// Represents the DT helper formalized with t type.
/// </summary>
public class DTHelperFormalizedWithT
{
    #region ToString
    // yyyy-mm-ddT00:00:00 (without timezone)
    /// <summary>
    /// Date time to string formalize date empty time.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The date time to string formalize date empty time result.</returns>
    public static string DateTimeToStringFormalizeDateEmptyTime(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T00:00:00";
    }
    #endregion

    #region ToString
    // 1989-06-21T00:00:00.000Z (Z/TZD/+hh:mm/-hh:mm - timezone designation)
    /// <summary>
    /// Date time to string stringify date empty time.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The date time to string stringify date empty time result.</returns>
    public static string DateTimeToStringStringifyDateEmptyTime(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T00:00:00.000Z";
    }

    // 1989-06-21Thh:mm:ss.000Z
    /// <summary>
    /// Date time to string stringify date time.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The date time to string stringify date time result.</returns>
    public static string DateTimeToStringStringifyDateTime(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2") + "." + dt.Millisecond.ToString("D3") + "Z";
    }

    // 1989-06-21T11:22:00
    /// <summary>
    /// Date and time to string formalize date.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The date and time to string formalize date result.</returns>
    public static string DateAndTimeToStringFormalizeDate(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2");
    }
    #endregion
}
