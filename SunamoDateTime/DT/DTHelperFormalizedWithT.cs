namespace SunamoDateTime.DT;

public class DTHelperFormalizedWithT
{
    #region ToString
    // yyyy-mm-ddT00:00:00 (without timezone)
    public static string DateTimeToStringFormalizeDateEmptyTime(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T00:00:00";
    }
    #endregion

    #region ToString
    // 1989-06-21T00:00:00.000Z (Z/TZD/+hh:mm/-hh:mm - timezone designation)
    public static string DateTimeToStringStringifyDateEmptyTime(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T00:00:00.000Z";
    }

    // 1989-06-21Thh:mm:ss.000Z
    public static string DateTimeToStringStringifyDateTime(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2") + "." + dt.Millisecond.ToString("D3") + "Z";
    }

    // 1989-06-21T11:22:00
    public static string DateAndTimeToStringFormalizeDate(DateTime dt)
    {
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2");
    }
    #endregion
}
