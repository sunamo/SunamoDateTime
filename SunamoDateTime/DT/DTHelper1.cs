namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelper
{
    /// <summary>
    /// 21.6.1989
    /// </summary>
    /// <param name = "input"></param>
    public static DateTime ParseDateCzech(string input)
    {
        return DTHelperCs.ParseDateCzech(input);
    }

    /// <summary>
    /// mm/d/yyyy
    /// </summary>
    /// <param name = "p"></param>
    public static DateTime? ParseDateMonthDayYear(string parameter)
    {
        int? dayTo = -1;
        return DTHelperMulti.ParseDateMonthDayYear(parameter, out dayTo);
    }

    /// <summary>
    /// Input in format like 2015-09-03T21:01
    /// </summary>
    /// <param name = "v"></param>
    /// <param name = "dtMinVal"></param>
    public static DateTime StringToDateTimeFromInputDateTimeLocal(string v, DateTime dtMinVal)
    {
        return DTHelperCode.StringToDateTimeFromInputDateTimeLocal(v, dtMinVal);
    }

    /// <summary>
    /// 1989_06_21_11_22 or 1989_06_21 if !A2
    /// </summary>
    /// <param name = "fnwoe"></param>
    /// <param name = "time"></param>
    /// <param name = "prefix"></param>
    public static DateTime? FileNameToDateTimePrefix(string fnwoe, bool time, out string prefix)
    {
        return DTHelperUs.FileNameToDateTimePrefix(fnwoe, time, out prefix);
    }

    /// <summary>
    /// Return null if wont have right format
    /// If A2, A1 must have format ????_??_??_??_??
    /// if !A2, A1 must have format ????_??_??
    /// In any case what is after A2 is not important
    /// </summary>
    /// <param name = "fnwoe"></param>
    /// <param name = "time"></param>
    /// <param name = "postfix"></param>
    public static DateTime? FileNameToDateTimePostfix(string fnwoe, bool time, out string postfix)
    {
        return DTHelperUs.FileNameToDateTimePostfix(fnwoe, time, out postfix);
    }

    /// <summary>
    /// Return null if wont have right format
    /// If A2, A1 must have format ????_??_??_??_??
    /// if !A2, A1 must have format ????_??_??
    /// In any case what is after A2 is not important
    /// </summary>
    /// <param name = "fnwoe"></param>
    /// <param name = "serie"></param>
    /// <param name = "postfix"></param>
    public static DateTime? FileNameToDateWithSeriePostfix(string fnwoe, out int? serie, out string postfix)
    {
        return DTHelperUs.FileNameToDateWithSeriePostfix(fnwoe, out serie, out postfix);
    }

    /// <summary>
    /// 1989_06_21_11_22
    /// </summary>
    /// <param name = "fnwoe"></param>
    public static DateTime? FileNameToDateTime(string fnwoe)
    {
        return DTHelperUs.FileNameToDateTime(fnwoe);
    }

    /// <summary>
    /// If A1 could be lower than 1d, return 1d
    /// </summary>
    /// <param name = "tt"></param>
    /// <param name = "calculateTime"></param>
    /// <param name = "l"></param>
    public static string AddRightStringToTimeSpan(TimeSpan tt, bool calculateTime, LangsDt l)
    {
        return DTHelperMulti.AddRightStringToTimeSpan(tt, calculateTime, l);
    }

    public static string OperationLastedInLocalizateString(TimeSpan tt, LangsDt l)
    {
        return DTHelperMulti.OperationLastedInLocalizateString(tt, l);
    }

    public static string TimeInMsToSeconds(Stopwatch parameter)
    {
        return DTHelperGeneral.TimeInMsToSeconds(parameter);
    }

    public static DateTime TodayPlusActualHour()
    {
        return DTHelperGeneral.TodayPlusActualHour();
    }

    public static long DateTimeToSecondsOnlyTime(DateTime t)
    {
        return DTHelperGeneral.DateTimeToSecondsOnlyTime(t, DTConstants.secondsInHour);
    }

    public static string CalculateAgeAndAddRightString(DateTime dateTime, bool calculateTime, DateTime dtMinVal)
    {
        return DTHelperCs.CalculateAgeAndAddRightString(dateTime, calculateTime, dtMinVal);
    }

    public static string DayOfWeek2DenVTydnu(DayOfWeek dayOfWeek)
    {
        return DTHelperCs.DayOfWeek2DenVTydnu(dayOfWeek);
    }

    public static DateTime ParseLl(string v, Func<string, int> ConvertMonthShortcutNumberFromShortcut)
    {
        var parameter = v.Split(' '); //SHSplit.Split(v, "");
        return new DateTime(DateTime.Today.Year, ConvertMonthShortcutNumberFromShortcut(parameter[0]), int.Parse(parameter[1]));
    }
}