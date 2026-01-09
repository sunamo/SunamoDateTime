// variables names: ok
namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelper
{
    /// <summary>
    /// 21.6.1989
    /// </summary>
    /// <param name = "text"></param>
    public static DateTime ParseDateCzech(string text)
    {
        return DTHelperCs.ParseDateCzech(text);
    }

    /// <summary>
    /// mm/d/yyyy
    /// </summary>
    /// <param name = "p"></param>
    public static DateTime? ParseDateMonthDayYear(string text)
    {
        int? dayTo = -1;
        return DTHelperMulti.ParseDateMonthDayYear(text, out dayTo);
    }

    /// <summary>
    /// Input in format like 2015-09-03T21:01
    /// </summary>
    /// <param name = "text">Input text in format YYYY-MM-DDTHH:MM</param>
    /// <param name = "dtMinVal">Minimum DateTime value</param>
    public static DateTime StringToDateTimeFromInputDateTimeLocal(string text, DateTime dtMinVal)
    {
        return DTHelperCode.StringToDateTimeFromInputDateTimeLocal(text, dtMinVal);
    }

    /// <summary>
    /// 1989_06_21_11_22 or 1989_06_21 if !A2
    /// </summary>
    /// <param name = "filenameWithoutExtension"></param>
    /// <param name = "time"></param>
    /// <param name = "prefix"></param>
    public static DateTime? FileNameToDateTimePrefix(string filenameWithoutExtension, bool time, out string prefix)
    {
        return DTHelperUs.FileNameToDateTimePrefix(filenameWithoutExtension, time, out prefix);
    }

    /// <summary>
    /// Return null if wont have right format
    /// If A2, A1 must have format ????_??_??_??_??
    /// if !A2, A1 must have format ????_??_??
    /// In any case what is after A2 is not important
    /// </summary>
    /// <param name = "filenameWithoutExtension"></param>
    /// <param name = "time"></param>
    /// <param name = "postfix"></param>
    public static DateTime? FileNameToDateTimePostfix(string filenameWithoutExtension, bool time, out string postfix)
    {
        return DTHelperUs.FileNameToDateTimePostfix(filenameWithoutExtension, time, out postfix);
    }

    /// <summary>
    /// Return null if wont have right format
    /// If A2, A1 must have format ????_??_??_??_??
    /// if !A2, A1 must have format ????_??_??
    /// In any case what is after A2 is not important
    /// </summary>
    /// <param name = "filenameWithoutExtension"></param>
    /// <param name = "serie"></param>
    /// <param name = "postfix"></param>
    public static DateTime? FileNameToDateWithSeriePostfix(string filenameWithoutExtension, out int? serie, out string postfix)
    {
        return DTHelperUs.FileNameToDateWithSeriePostfix(filenameWithoutExtension, out serie, out postfix);
    }

    /// <summary>
    /// 1989_06_21_11_22
    /// </summary>
    /// <param name = "filenameWithoutExtension"></param>
    public static DateTime? FileNameToDateTime(string filenameWithoutExtension)
    {
        return DTHelperUs.FileNameToDateTime(filenameWithoutExtension);
    }

    /// <summary>
    /// If A1 could be lower than 1d, return 1d
    /// </summary>
    /// <param name = "timeSpan"></param>
    /// <param name = "calculateTime"></param>
    /// <param name = "lang"></param>
    public static string AddRightStringToTimeSpan(TimeSpan timeSpan, bool calculateTime, LangsDt lang)
    {
        return DTHelperMulti.AddRightStringToTimeSpan(timeSpan, calculateTime, lang);
    }

    public static string OperationLastedInLocalizateString(TimeSpan duration, LangsDt lang)
    {
        return DTHelperMulti.OperationLastedInLocalizateString(duration, lang);
    }

    public static string TimeInMsToSeconds(Stopwatch parameter)
    {
        return DTHelperGeneral.TimeInMsToSeconds(parameter);
    }

    public static DateTime TodayPlusActualHour()
    {
        return DTHelperGeneral.TodayPlusActualHour();
    }

    public static long DateTimeToSecondsOnlyTime(DateTime dateTime)
    {
        return DTHelperGeneral.DateTimeToSecondsOnlyTime(dateTime, DTConstants.SecondsInHour);
    }

    public static string CalculateAgeAndAddRightString(DateTime dateTime, bool calculateTime, DateTime dtMinVal)
    {
        return DTHelperCs.CalculateAgeAndAddRightString(dateTime, calculateTime, dtMinVal);
    }

    public static string DayOfWeek2DenVTydnu(DayOfWeek dayOfWeek)
    {
        return DTHelperCs.DayOfWeek2DenVTydnu(dayOfWeek);
    }

    public static DateTime ParseLl(string text, Func<string, int> ConvertMonthShortcutNumberFromShortcut)
    {
        var parts = text.Split(' '); //SHSplit.Split(text, "");
        return new DateTime(DateTime.Today.Year, ConvertMonthShortcutNumberFromShortcut(parts[0]), int.Parse(parts[1]));
    }
}