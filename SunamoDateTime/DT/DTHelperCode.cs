// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoDateTime.DT;

public class DTHelperCode
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
        return dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2");
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
        //return dt.Day.ToString("D2") + "." + dt.Month.ToString("D2") + "." + dt.Year;
        return dt.Month.ToString("D2") + "/" + dt.Day.ToString("D2") + "/" + dt.Year;
    }
    #endregion


    #region Date with time
    /// <summary>
    /// 19890621T11:22:00
    /// </summary>
    /// <param name="dt"></param>
    public static string DateAndTimeToStringAngularDateTime(DateTime dt)
    {
        return dt.Year + dt.Month.ToString("D2") + dt.Day.ToString("D2") + "T" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2");
    }
    #endregion
    #endregion

    #region ToString
    #region Time (with seconds)
    /// <summary>
    /// 12:00:00
    /// </summary>
    /// <param name="dt"></param>
    public static string TimeToStringAngularTime(DateTime dt)
    {
        return dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2");
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

    #region Parse
    #region Date with time (without seconds)
    /// <summary>
    /// Input in format like 2015-09-03T21:01
    /// </summary>
    /// <param name="v"></param>
    /// <param name="dtMinVal"></param>
    public static DateTime StringToDateTimeFromInputDateTimeLocal(string v, DateTime dtMinVal)
    {
        if (!v.Contains("-"))
        {
            return dtMinVal;
        }
        //2015-09-03T21:01
        var sp = v.Split(new Char[] { '-', 'T', ':' }).ToList();
        var dd = CAToNumber.ToInt0(sp);
        return new DateTime(dd[0], dd[1], dd[2], dd[3], dd[4], 0);
    }
    #endregion
    #endregion
}
