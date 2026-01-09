// variables names: ok
namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelper
{
    public static DateTime IsValidTimeText(string text)
    {
        return DTHelperMulti.IsValidTimeText(text);
    }

    public static DateTime IsValidDateTimeText(string text)
    {
        return DTHelperMulti.IsValidDateTimeText(text);
    }

    public static DateTime IsValidDateText(string text)
    {
        return DTHelperMulti.IsValidDateText(text);
    }

    public static DateTime ParseDateUSA(string text)
    {
        return DTHelperEn.ParseDateUSA(text);
    }

    /// <summary>
    /// 2018-08-10T11:33:19Z
    /// </summary>
    /// <param name = "p"></param>
    public static DateTime StringToDateTimeFormalizeDate(string text)
    {
        return DTHelperFormalized.StringToDateTimeFormalizeDate(text);
    }

    public static string DateToStringWithDayOfWeekCS(DateTime dateTime)
    {
        return DTHelperCs.DateToStringWithDayOfWeekCS(dateTime);
    }

    public static string CalculateAgeAndAddRightStringKymCim(DateTime dateTime, bool calculateTime, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperCs.CalculateAgeAndAddRightStringKymCim(dateTime, calculateTime, lang, dtMinVal);
    }

    public static string MakeUpTo2NumbersToZero(int text)
    {
        return text.ToString("D2"); // NH.MakeUpTo2NumbersToZero(parameter);
    }

    public static string TimeToStringAngularTime(DateTime dateTime)
    {
        return DTHelperCode.TimeToStringAngularTime(dateTime);
    }

    public static string DateToStringAngularDate(DateTime dateTime)
    {
        return DTHelperCode.DateToStringAngularDate(dateTime);
    }

    public static string DateToString(DateTime parameter, LangsDt lang)
    {
        return DTHelperMulti.DateToString(parameter, lang);
    }

    public static string DateTimeToString(DateTime dateTime, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperMulti.DateTimeToString(dateTime, lang, dtMinVal);
    }

    //public static string DateTimeToStringWithoutDayOfWeek(DateTime actualMessageDt)
    //{
    //    return null;
    //}
    public static DateTime OnlyDateProperties(DateTime parameter)
    {
        return new DateTime(parameter.Year, parameter.Month, parameter.Day);
    }

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
    /// 21.6.1989
    /// </summary>
    /// <param name = "p"></param>
    /// <param name = "l"></param>
    /// <param name = "dtMinVal"></param>
    public static string DateToStringOrSE(DateTime parameter, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperMulti.DateToStringOrSE(parameter, lang, dtMinVal);
    }

    /// <summary>
    /// 21.6.1989 (středa) / 6/21/1989 (wednesday)
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "l"></param>
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