namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelper
{
    public static DateTime IsValidTimeText(string r)
    {
        return DTHelperMulti.IsValidTimeText(r);
    }

    public static DateTime IsValidDateTimeText(string datum)
    {
        return DTHelperMulti.IsValidDateTimeText(datum);
    }

    public static DateTime IsValidDateText(string r)
    {
        return DTHelperMulti.IsValidDateText(r);
    }

    public static DateTime ParseDateUSA(string input)
    {
        return DTHelperEn.ParseDateUSA(input);
    }

    /// <summary>
    /// 2018-08-10T11:33:19Z
    /// </summary>
    /// <param name = "p"></param>
    public static DateTime StringToDateTimeFormalizeDate(string parameter)
    {
        return DTHelperFormalized.StringToDateTimeFormalizeDate(parameter);
    }

    public static string DateToStringWithDayOfWeekCS(DateTime dt)
    {
        return DTHelperCs.DateToStringWithDayOfWeekCS(dt);
    }

    public static string CalculateAgeAndAddRightStringKymCim(DateTime dateTime, bool calculateTime, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperCs.CalculateAgeAndAddRightStringKymCim(dateTime, calculateTime, lang, dtMinVal);
    }

    public static string MakeUpTo2NumbersToZero(int parameter)
    {
        return parameter.ToString("D2"); // NH.MakeUpTo2NumbersToZero(parameter);
    }

    public static string TimeToStringAngularTime(DateTime dt)
    {
        return DTHelperCode.TimeToStringAngularTime(dt);
    }

    public static string DateToStringAngularDate(DateTime dt)
    {
        return DTHelperCode.DateToStringAngularDate(dt);
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
    /// <param name = "dt"></param>
    public static string DateToStringjQueryDatePicker(DateTime dt)
    {
        return DTHelperCode.DateToStringjQueryDatePicker(dt);
    }

    /// <summary>
    /// 19890621T11:22:00
    /// </summary>
    /// <param name = "dt"></param>
    public static string DateAndTimeToStringAngularDateTime(DateTime dt)
    {
        return DTHelperCode.DateAndTimeToStringAngularDateTime(dt);
    }

    /// <summary>
    /// 1989-06-21T11:22
    /// </summary>
    /// <param name = "dt"></param>
    /// <param name = "dtMinVal"></param>
    public static string DateTimeToStringToInputDateTimeLocal(DateTime dt, DateTime dtMinVal)
    {
        return DTHelperCode.DateTimeToStringToInputDateTimeLocal(dt, dtMinVal);
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
    /// <param name = "dt"></param>
    public static string DateTimeToStringWithDayOfWeekCS(DateTime dt)
    {
        return DTHelperCs.DateTimeToStringWithDayOfWeekCS(dt);
    }

    /// <summary>
    /// 1989-06-21
    /// </summary>
    /// <param name = "dt"></param>
    public static string DateTimeToStringFormalizeDate(DateTime dt)
    {
        return DTHelperFormalized.DateTimeToStringFormalizeDate(dt);
    }

    /// <summary>
    /// 2011-10-18 10:30
    /// </summary>
    /// <param name = "dt"></param>
    /// <param name = "fullCalendar"></param>
    public static string FormatDateTime(DateTime dt, DateTimeFormatStyles fullCalendar)
    {
        return DTHelperFormalized.FormatDateTime(dt, fullCalendar);
    }

    /// <summary>
    /// yyyy-mm-ddT00:00:00
    /// </summary>
    /// <param name = "dt"></param>
    public static string DateTimeToStringFormalizeDateEmptyTime(DateTime dt)
    {
        return DTHelperFormalizedWithT.DateTimeToStringFormalizeDateEmptyTime(dt);
    }

    /// <summary>
    /// 1989-06-21T00:00:00.000Z
    /// </summary>
    /// <param name = "dt"></param>
    public static string DateTimeToStringStringifyDateEmptyTime(DateTime dt)
    {
        return DTHelperFormalizedWithT.DateTimeToStringStringifyDateEmptyTime(dt);
    }

    /// <summary>
    /// 1989-06-21Thh:mm:ss.000Z
    /// </summary>
    /// <param name = "dt"></param>
    public static string DateTimeToStringStringifyDateTime(DateTime dt)
    {
        return DTHelperFormalizedWithT.DateTimeToStringStringifyDateTime(dt);
    }

    /// <summary>
    /// 1989-06-21T11:22:00
    /// </summary>
    /// <param name = "dt"></param>
    public static string DateAndTimeToStringFormalizeDate(DateTime dt)
    {
        return DTHelperFormalizedWithT.DateAndTimeToStringFormalizeDate(dt);
    }

    /// <summary>
    /// yyyy_mm_dd
    /// With A2 append hh_mm
    /// </summary>
    /// <param name = "dt"></param>
    /// <param name = "time"></param>
    public static string DateTimeToFileName(DateTime dt, bool time)
    {
        return DTHelperUs.DateTimeToFileName(dt, time);
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
    /// <param name = "dt"></param>
    public static string DateTimeToFileName(DateTime dt)
    {
        return DTHelperUs.DateTimeToFileName(dt);
    }

    /// <summary>
    /// hh:mm:ss
    /// If fail, return DT.MinValue
    /// Seconds can be omit
    /// </summary>
    /// <param name = "t"></param>
    public static DateTime ParseTimeCzech(string t)
    {
        return DTHelperCs.ParseTimeCzech(t);
    }

    /// <summary>
    /// Seconds can be omit
    /// hh:mm tt
    /// </summary>
    /// <param name = "t"></param>
    public static DateTime ParseTimeUSA(string t)
    {
        return DTHelperEn.ParseTimeUSA(t);
    }
}