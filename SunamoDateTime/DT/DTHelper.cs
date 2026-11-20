namespace SunamoDateTime.DT;

/// <summary>
/// Represents the DT helper type.
/// </summary>
public partial class DTHelper
{
    /// <summary>
    /// Is valid time text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is valid time text result.</returns>
    public static DateTime IsValidTimeText(string text)
    {
        return DTHelperMulti.IsValidTimeText(text);
    }

    /// <summary>
    /// Is valid date time text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is valid date time text result.</returns>
    public static DateTime IsValidDateTimeText(string text)
    {
        return DTHelperMulti.IsValidDateTimeText(text);
    }

    /// <summary>
    /// Is valid date text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is valid date text result.</returns>
    public static DateTime IsValidDateText(string text)
    {
        return DTHelperMulti.IsValidDateText(text);
    }

    /// <summary>
    /// Parse date USA.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse date USA result.</returns>
    public static DateTime ParseDateUSA(string text)
    {
        return DTHelperEn.ParseDateUSA(text);
    }

    /// <summary>
    /// String to date time formalize date.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The string to date time formalize date result.</returns>
    public static DateTime StringToDateTimeFormalizeDate(string text)
    {
        return DTHelperFormalized.StringToDateTimeFormalizeDate(text);
    }

    /// <summary>
    /// Date to string with day of week CS.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The date to string with day of week CS result.</returns>
    public static string DateToStringWithDayOfWeekCS(DateTime dateTime)
    {
        return DTHelperCs.DateToStringWithDayOfWeekCS(dateTime);
    }

    /// <summary>
    /// Calculate age and add right string kym cim.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="calculateTime">The calculate time.</param>
    /// <param name="lang">The lang.</param>
    /// <param name="dtMinVal">The dt min val.</param>
    /// <returns>The calculate age and add right string kym cim result.</returns>
    public static string CalculateAgeAndAddRightStringKymCim(DateTime dateTime, bool calculateTime, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperCs.CalculateAgeAndAddRightStringKymCim(dateTime, calculateTime, lang, dtMinVal);
    }

    /// <summary>
    /// Make up to 2 numbers to zero.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The make up to 2 numbers to zero result.</returns>
    public static string MakeUpTo2NumbersToZero(int text)
    {
        return text.ToString("D2"); // NH.MakeUpTo2NumbersToZero(parameter);
    }

    /// <summary>
    /// Time to string angular time.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The time to string angular time result.</returns>
    public static string TimeToStringAngularTime(DateTime dateTime)
    {
        return DTHelperCode.TimeToStringAngularTime(dateTime);
    }

    /// <summary>
    /// Date to string angular date.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The date to string angular date result.</returns>
    public static string DateToStringAngularDate(DateTime dateTime)
    {
        return DTHelperCode.DateToStringAngularDate(dateTime);
    }

    /// <summary>
    /// Date to string.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <param name="lang">The lang.</param>
    /// <returns>The date to string result.</returns>
    public static string DateToString(DateTime parameter, LangsDt lang)
    {
        return DTHelperMulti.DateToString(parameter, lang);
    }

    /// <summary>
    /// Date time to string.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="lang">The lang.</param>
    /// <param name="dtMinVal">The dt min val.</param>
    /// <returns>The date time to string result.</returns>
    public static string DateTimeToString(DateTime dateTime, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperMulti.DateTimeToString(dateTime, lang, dtMinVal);
    }

    /// <summary>
    /// Only date properties.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <returns>The only date properties result.</returns>
    public static DateTime OnlyDateProperties(DateTime parameter)
    {
        return new DateTime(parameter.Year, parameter.Month, parameter.Day);
    }

    /// <summary>
    /// Calculate start of period.
    /// </summary>
    /// <param name="AddedAgo">The added ago.</param>
    /// <returns>The calculate start of period result.</returns>
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
    /// Date to string or SE.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    /// <param name="lang">The lang.</param>
    /// <param name="dtMinVal">The dt min val.</param>
    /// <returns>The date to string or SE result.</returns>
    public static string DateToStringOrSE(DateTime parameter, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperMulti.DateToStringOrSE(parameter, lang, dtMinVal);
    }

    /// <summary>
    /// Date with day of week.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="lang">The lang.</param>
    /// <returns>The date with day of week result.</returns>
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
