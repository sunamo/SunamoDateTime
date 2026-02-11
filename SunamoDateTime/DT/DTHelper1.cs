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
    /// Parses a date in month/day/year format (e.g. mm/d/yyyy).
    /// </summary>
    /// <param name="text">The date text to parse</param>
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

    /// <summary>
    /// Returns a localized string describing how long an operation lasted.
    /// </summary>
    /// <param name="duration">The duration of the operation</param>
    /// <param name="lang">The language for localization</param>
    /// <returns>Localized duration string</returns>
    public static string OperationLastedInLocalizateString(TimeSpan duration, LangsDt lang)
    {
        return DTHelperMulti.OperationLastedInLocalizateString(duration, lang);
    }

    /// <summary>
    /// Converts elapsed milliseconds from a Stopwatch to a seconds string (e.g. "1.23s") and resets the Stopwatch.
    /// </summary>
    /// <param name="parameter">The Stopwatch to read and reset</param>
    /// <returns>Elapsed time in seconds as string</returns>
    public static string TimeInMsToSeconds(Stopwatch parameter)
    {
        return DTHelperGeneral.TimeInMsToSeconds(parameter);
    }

    /// <summary>
    /// Returns today's date with the current hour added.
    /// </summary>
    /// <returns>Today's date at the current hour</returns>
    public static DateTime TodayPlusActualHour()
    {
        return DTHelperGeneral.TodayPlusActualHour();
    }

    /// <summary>
    /// Converts a DateTime's time component to total seconds as a non-normalized long value.
    /// </summary>
    /// <param name="dateTime">The DateTime whose time to convert</param>
    /// <returns>Time in seconds as a long value</returns>
    public static long DateTimeToSecondsOnlyTime(DateTime dateTime)
    {
        return DTHelperGeneral.DateTimeToSecondsOnlyTime(dateTime, DTConstants.SecondsInHour);
    }

    /// <summary>
    /// Calculates age from a date and returns it as a Czech localized string with nominative case.
    /// </summary>
    /// <param name="dateTime">The birth/start date</param>
    /// <param name="calculateTime">Whether to include time units (hours, minutes, seconds)</param>
    /// <param name="dtMinVal">The minimum DateTime value representing an unset date</param>
    /// <returns>Localized age string</returns>
    public static string CalculateAgeAndAddRightString(DateTime dateTime, bool calculateTime, DateTime dtMinVal)
    {
        return DTHelperCs.CalculateAgeAndAddRightString(dateTime, calculateTime, dtMinVal);
    }

    /// <summary>
    /// Converts a DayOfWeek enum value to its Czech name (e.g. Monday becomes "Pondělí").
    /// </summary>
    /// <param name="dayOfWeek">The day of week to convert</param>
    /// <returns>Czech name of the day</returns>
    public static string DayOfWeek2DenVTydnu(DayOfWeek dayOfWeek)
    {
        return DTHelperCs.DayOfWeek2DenVTydnu(dayOfWeek);
    }

    /// <summary>
    /// Parses a date from a text containing a month shortcut and day number (e.g. "Jan 15").
    /// </summary>
    /// <param name="text">The text containing month shortcut and day</param>
    /// <param name="ConvertMonthShortcutNumberFromShortcut">Function to convert month shortcut to month number</param>
    /// <returns>Parsed DateTime with current year</returns>
    public static DateTime ParseLl(string text, Func<string, int> ConvertMonthShortcutNumberFromShortcut)
    {
        var parts = text.Split(' '); //SHSplit.Split(text, "");
        return new DateTime(DateTime.Today.Year, ConvertMonthShortcutNumberFromShortcut(parts[0]), int.Parse(parts[1]));
    }
}