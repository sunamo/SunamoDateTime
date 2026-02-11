namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// Main facade class providing DateTime parsing, formatting and validation operations. Delegates to specialized helper classes.
/// </summary>
public partial class DTHelper
{
    /// <summary>
    /// Validates whether the text represents a valid time. Returns DateTime.MinValue if invalid.
    /// </summary>
    /// <param name="text">The time text to validate</param>
    /// <returns>Parsed DateTime if valid, DateTime.MinValue otherwise</returns>
    public static DateTime IsValidTimeText(string text)
    {
        return DTHelperMulti.IsValidTimeText(text);
    }

    /// <summary>
    /// Validates whether the text represents a valid date and time. Returns DateTime.MinValue if invalid.
    /// </summary>
    /// <param name="text">The date-time text to validate</param>
    /// <returns>Parsed DateTime if valid, DateTime.MinValue otherwise</returns>
    public static DateTime IsValidDateTimeText(string text)
    {
        return DTHelperMulti.IsValidDateTimeText(text);
    }

    /// <summary>
    /// Validates whether the text represents a valid date. Returns DateTime.MinValue if invalid.
    /// </summary>
    /// <param name="text">The date text to validate</param>
    /// <returns>Parsed DateTime if valid, DateTime.MinValue otherwise</returns>
    public static DateTime IsValidDateText(string text)
    {
        return DTHelperMulti.IsValidDateText(text);
    }

    /// <summary>
    /// Parses a date string in US format (mm/dd/yyyy).
    /// </summary>
    /// <param name="text">The date text in US format</param>
    /// <returns>Parsed DateTime, or DateTime.MinValue if parsing fails</returns>
    public static DateTime ParseDateUSA(string text)
    {
        return DTHelperEn.ParseDateUSA(text);
    }

    /// <summary>
    /// Parses a formalized date string (e.g. 2018-08-10T11:33:19Z) into DateTime.
    /// </summary>
    /// <param name="text">The formalized date string to parse</param>
    public static DateTime StringToDateTimeFormalizeDate(string text)
    {
        return DTHelperFormalized.StringToDateTimeFormalizeDate(text);
    }

    /// <summary>
    /// Formats a DateTime as a Czech date string with day of week prefix (e.g. "Středa, 21.6.1989").
    /// </summary>
    /// <param name="dateTime">The DateTime to format</param>
    /// <returns>Czech-formatted date string with day of week</returns>
    public static string DateToStringWithDayOfWeekCS(DateTime dateTime)
    {
        return DTHelperCs.DateToStringWithDayOfWeekCS(dateTime);
    }

    /// <summary>
    /// Calculates the age from a date and returns it as a Czech localized string with instrumental case (kym/cim).
    /// </summary>
    /// <param name="dateTime">The birth/start date</param>
    /// <param name="calculateTime">Whether to include time units (hours, minutes, seconds)</param>
    /// <param name="lang">The language for localization</param>
    /// <param name="dtMinVal">The minimum DateTime value representing an unset date</param>
    /// <returns>Localized age string in instrumental case</returns>
    public static string CalculateAgeAndAddRightStringKymCim(DateTime dateTime, bool calculateTime, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperCs.CalculateAgeAndAddRightStringKymCim(dateTime, calculateTime, lang, dtMinVal);
    }

    /// <summary>
    /// Formats a number to a two-digit zero-padded string (e.g. 5 becomes "05").
    /// </summary>
    /// <param name="text">The number to format</param>
    /// <returns>Two-digit zero-padded string</returns>
    public static string MakeUpTo2NumbersToZero(int text)
    {
        return text.ToString("D2"); // NH.MakeUpTo2NumbersToZero(parameter);
    }

    /// <summary>
    /// Formats a DateTime's time component as an Angular-compatible time string (HH:mm:ss).
    /// </summary>
    /// <param name="dateTime">The DateTime whose time to format</param>
    /// <returns>Time string in HH:mm:ss format</returns>
    public static string TimeToStringAngularTime(DateTime dateTime)
    {
        return DTHelperCode.TimeToStringAngularTime(dateTime);
    }

    /// <summary>
    /// Formats a DateTime as an Angular-compatible date string (yyyyMMddT00:00:00).
    /// </summary>
    /// <param name="dateTime">The DateTime to format</param>
    /// <returns>Date string in Angular format</returns>
    public static string DateToStringAngularDate(DateTime dateTime)
    {
        return DTHelperCode.DateToStringAngularDate(dateTime);
    }

    /// <summary>
    /// Formats a DateTime as a localized date string (cs: d.M.yyyy, en: M/d/yyyy).
    /// </summary>
    /// <param name="parameter">The DateTime to format</param>
    /// <param name="lang">The language determining the format</param>
    /// <returns>Localized date string</returns>
    public static string DateToString(DateTime parameter, LangsDt lang)
    {
        return DTHelperMulti.DateToString(parameter, lang);
    }

    /// <summary>
    /// Formats a DateTime as a localized date-time string, or returns "not indicated" text if equal to minimum value.
    /// </summary>
    /// <param name="dateTime">The DateTime to format</param>
    /// <param name="lang">The language determining the format</param>
    /// <param name="dtMinVal">The minimum DateTime value representing an unset date</param>
    /// <returns>Localized date-time string</returns>
    public static string DateTimeToString(DateTime dateTime, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperMulti.DateTimeToString(dateTime, lang, dtMinVal);
    }

    //public static string DateTimeToStringWithoutDayOfWeek(DateTime actualMessageDt)
    //{
    //    return null;
    //}
    /// <summary>
    /// Returns a new DateTime with only the date component (year, month, day), zeroing the time part.
    /// </summary>
    /// <param name="parameter">The DateTime to extract the date from</param>
    /// <returns>A DateTime with only the date component</returns>
    public static DateTime OnlyDateProperties(DateTime parameter)
    {
        return new DateTime(parameter.Year, parameter.Month, parameter.Day);
    }

    /// <summary>
    /// Calculates a past date by subtracting the specified period (e.g. "7_days", "2_weeks") from today.
    /// </summary>
    /// <param name="AddedAgo">The period string in format "number_unit" (days/weeks/months/years)</param>
    /// <returns>The calculated past DateTime</returns>
    public static DateTime CalculateStartOfPeriod(string AddedAgo)
    {
        return DTHelperEn.CalculateStartOfPeriod(AddedAgo);
    }

    /// <summary>
    /// mm/dd/yyyy
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateToStringjQueryDatePicker(DateTime dateTime)
    {
        return DTHelperCode.DateToStringjQueryDatePicker(dateTime);
    }

    /// <summary>
    /// 19890621T11:22:00
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateAndTimeToStringAngularDateTime(DateTime dateTime)
    {
        return DTHelperCode.DateAndTimeToStringAngularDateTime(dateTime);
    }

    /// <summary>
    /// 1989-06-21T11:22
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "dtMinVal"></param>
    public static string DateTimeToStringToInputDateTimeLocal(DateTime dateTime, DateTime dtMinVal)
    {
        return DTHelperCode.DateTimeToStringToInputDateTimeLocal(dateTime, dtMinVal);
    }

    /// <summary>
    /// Return actual time(for example 12:00:00:000) and after that A1 postfix
    /// </summary>
    /// <param name = "defin"></param>
    public static string AppendToFrontOnlyTime(string defin)
    {
        return DTHelperCs.AppendToFrontOnlyTime(defin);
    }

    /// <summary>
    /// Wednesday, 21.6.1989 11:22 (dont fill with zero)
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateTimeToStringWithDayOfWeekCS(DateTime dateTime)
    {
        return DTHelperCs.DateTimeToStringWithDayOfWeekCS(dateTime);
    }

    /// <summary>
    /// 1989-06-21
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateTimeToStringFormalizeDate(DateTime dateTime)
    {
        return DTHelperFormalized.DateTimeToStringFormalizeDate(dateTime);
    }

    /// <summary>
    /// 2011-10-18 10:30
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "fullCalendar"></param>
    public static string FormatDateTime(DateTime dateTime, DateTimeFormatStyles fullCalendar)
    {
        return DTHelperFormalized.FormatDateTime(dateTime, fullCalendar);
    }

    /// <summary>
    /// yyyy-mm-ddT00:00:00
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateTimeToStringFormalizeDateEmptyTime(DateTime dateTime)
    {
        return DTHelperFormalizedWithT.DateTimeToStringFormalizeDateEmptyTime(dateTime);
    }

    /// <summary>
    /// 1989-06-21T00:00:00.000Z
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateTimeToStringStringifyDateEmptyTime(DateTime dateTime)
    {
        return DTHelperFormalizedWithT.DateTimeToStringStringifyDateEmptyTime(dateTime);
    }

    /// <summary>
    /// 1989-06-21Thh:mm:ss.000Z
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateTimeToStringStringifyDateTime(DateTime dateTime)
    {
        return DTHelperFormalizedWithT.DateTimeToStringStringifyDateTime(dateTime);
    }

    /// <summary>
    /// 1989-06-21T11:22:00
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateAndTimeToStringFormalizeDate(DateTime dateTime)
    {
        return DTHelperFormalizedWithT.DateAndTimeToStringFormalizeDate(dateTime);
    }

    /// <summary>
    /// yyyy_mm_dd
    /// With A2 append hh_mm
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "time"></param>
    public static string DateTimeToFileName(DateTime dateTime, bool time)
    {
        return DTHelperUs.DateTimeToFileName(dateTime, time);
    }

    /// <summary>
    /// Formats a DateTime as a localized date string, or returns empty string if equal to minimum value. (e.g. 21.6.1989)
    /// </summary>
    /// <param name="parameter">The DateTime to format</param>
    /// <param name="lang">The language determining the format</param>
    /// <param name="dtMinVal">The minimum DateTime value representing an unset date</param>
    public static string DateToStringOrSE(DateTime parameter, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperMulti.DateToStringOrSE(parameter, lang, dtMinVal);
    }

    /// <summary>
    /// Formats a DateTime as a localized date with day of week in parentheses. (e.g. 21.6.1989 (středa) / 6/21/1989 (wednesday))
    /// </summary>
    /// <param name="dateTime">The DateTime to format</param>
    /// <param name="lang">The language determining the format and day name</param>
    public static string DateWithDayOfWeek(DateTime dateTime, LangsDt lang)
    {
        return DTHelperMulti.DateWithDayOfWeek(dateTime, lang);
    }

    /// <summary>
    /// yyyy_mm_dd
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateTimeToFileName(DateTime dateTime)
    {
        return DTHelperUs.DateTimeToFileName(dateTime);
    }

    /// <summary>
    /// hh:mm:ss
    /// If fail, return DT.MinValue
    /// Seconds can be omit
    /// </summary>
    /// <param name = "text"></param>
    public static DateTime ParseTimeCzech(string text)
    {
        return DTHelperCs.ParseTimeCzech(text);
    }

    /// <summary>
    /// Seconds can be omit
    /// hh:mm tt
    /// </summary>
    /// <param name = "text"></param>
    public static DateTime ParseTimeUSA(string text)
    {
        return DTHelperEn.ParseTimeUSA(text);
    }
}