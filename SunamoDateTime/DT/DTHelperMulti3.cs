namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperMulti
{
    /// <summary>
    /// Localization string for "not indicated" status.
    /// </summary>
    public static string XNotIndicated = "NotIndicated";
    /// <summary>
    /// Formats a DateTime's time component as a localized string (HH:mm), or returns "not indicated" if equal to minimum value.
    /// </summary>
    /// <param name="dateTime">The DateTime whose time to format</param>
    /// <param name="lang">The language for localization</param>
    /// <param name="dtMinVal">The minimum DateTime value representing an unset date</param>
    /// <returns>Formatted time string or localized "not indicated" text</returns>
    public static string TimeToString(DateTime dateTime, LangsDt lang, DateTime dtMinVal)
    {
        if (dateTime == dtMinVal)
        {
            if (lang == LangsDt.cs)
            {
                return XItWasNotMentioned;
            }
            else
            {
                return XNotIndicated;
            }
        }

        if (lang == LangsDt.cs)
        {
            // 21.6.1989 11:22 (fill zero)
            return dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2");
        }
        else
        {
            // 6/21/1989 11:22 (fill zero)
            return dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2");
        }
    }

    /// <summary>
    /// 21.6.1989 (středa) / 6/21/1989 (wednesday)
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "lang"></param>
    public static string DateWithDayOfWeek(DateTime dateTime, LangsDt lang)
    {
        int day = (int)dateTime.DayOfWeek;
        if (day == 0)
        {
            day = 6;
        }
        else
        {
            day--;
        }

        string dayOfWeek = DTConstants.DaysInWeekEN[day];
        if (lang == LangsDt.cs)
        {
            dayOfWeek = DTConstants.DaysInWeekCS[day];
        }

        return DateToString(dateTime, lang) + " (" + dayOfWeek + ")";
    }

    /// <summary>
    /// Formats a DateTime as a localized date string with day of week prefix (e.g. "Středa, 21.6.1989" / "Wednesday, 6/21/1989").
    /// </summary>
    /// <param name="dateTime">The DateTime to format</param>
    /// <param name="lang">The language determining the format</param>
    /// <returns>Date string with day of week prefix</returns>
    public static string DateToStringWithDayOfWeek(DateTime dateTime, LangsDt lang)
    {
        if (lang == LangsDt.en)
        {
            return DTHelperEn.DateToStringWithDayOfWeekEN(dateTime);
        }
        else if (lang == LangsDt.cs)
        {
            return DTHelperCs.DateToStringWithDayOfWeekCS(dateTime);
        }
        else
        {
            throw new NotImplementedException($"Language {lang} is not supported");
        }
    }

    /// <summary>
    /// Return whether can be parse with DTHelperCs.ParseDateCzech or DTHelperEn.ParseDateUSA
    /// </summary>
    /// <param name = "text"></param>
    public static DateTime IsValidDateText(string text)
    {
        DateTime result = DateTime.MinValue;
        text = text.Trim();
        if (text != "")
        {
            var dotIndex = text.IndexOf('.');
            if (dotIndex != -1)
            {
                result = DTHelperCs.ParseDateCzech(text);
            }
            else
            {
                result = DTHelperEn.ParseDateUSA(text);
            }
        }

        return result;
    }

    /// <summary>
    /// A1 can be in en or cs
    /// parse time after first space
    /// </summary>
    /// <param name = "text"></param>
    public static DateTime IsValidDateTimeText(string text)
    {
        DateTime result = DateTime.MinValue;
        int spaceIndex = text.IndexOf(' ');
        if (spaceIndex != -1)
        {
            var parsedDate = DateTime.Today;
            var parsedTime = DateTime.Today;
            var dateText = text.Substring(0, spaceIndex);
            var timeText = text.Substring(spaceIndex + 1);
            if (dateText.IndexOf('.') != -1)
            {
                parsedDate = DTHelperCs.ParseDateCzech(dateText);
            }
            else
            {
                parsedDate = DTHelperEn.ParseDateUSA(dateText);
            }

            if (timeText.IndexOf(' ') == -1)
            {
                parsedTime = DTHelperCs.ParseTimeCzech(timeText);
            }
            else
            {
                parsedTime = DTHelperEn.ParseTimeUSA(timeText);
            }

            if (parsedDate != DateTime.MinValue && parsedTime != DateTime.MinValue)
            {
                result = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, parsedTime.Hour, parsedTime.Minute, parsedTime.Second);
            }
        }

        return result;
    }

    /// <summary>
    /// Validates whether the text represents a valid time (Czech hh:mm:ss or US hh:mm tt format).
    /// </summary>
    /// <param name="text">The time text to validate</param>
    /// <returns>Parsed DateTime if valid, DateTime.MinValue otherwise</returns>
    public static DateTime IsValidTimeText(string text)
    {
        DateTime result = DateTime.MinValue;
        text = text.Trim();
        if (text != "")
        {
            var spaceIndex = text.IndexOf(' ');
            if (spaceIndex == -1)
            {
                result = DTHelperCs.ParseTimeCzech(text);
            }
            else
            {
                result = DTHelperEn.ParseTimeUSA(text);
            }
        }

        return result;
    }

    /// <summary>
    /// 21.6.1989 / 6/21/1989
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "lang"></param>
    public static string DateToString(DateTime dateTime, LangsDt lang)
    {
        if (lang == LangsDt.cs)
        {
            return dateTime.Day + "." + dateTime.Month + "." + dateTime.Year;
        }

        return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year;
    }

    /// <summary>
    /// Returns the localized string for "files found" with proper Czech declension based on count.
    /// </summary>
    /// <param name="count">The number of files found</param>
    /// <param name="lang">The language for localization</param>
    /// <returns>Localized "files found" string</returns>
    public static string FilesFounded(int count, LangsDt lang)
    {
        if (lang == LangsDt.cs)
        {
            if (count < 2)
            {
                return "soubor nalezen";
            }

            if (count < 5)
            {
                return "soubory nalezeny";
            }

            return "souborů nalezeno";
        }

        return XFilesFounded;
    }

    /// <summary>
    /// Localization string for "files founded" in English.
    /// </summary>
    public static string XFilesFounded = "filesFounded";
    /// <summary>
    /// Localization string for "it was not mentioned" status.
    /// </summary>
    public static string XItWasNotMentioned = "ItWasNotMentioned";
}