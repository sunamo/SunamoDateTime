namespace SunamoDateTime.DT;

/// <summary>
/// Represents the DT helper en type.
/// </summary>
public class DTHelperEn
{
    static Type type = typeof(DTHelperEn);

    #region Parse
    #region Only Date
    // return MinValue when fail
    /// <summary>
    /// Parse date USA.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse date USA result.</returns>
    public static DateTime ParseDateUSA(string text)
    {
        DateTime result = DateTime.MinValue;
        var parts = text.Split('/'); //SHSplit.SplitChar(input, new Char[] { '/' });
        var day = -1;
        var month = -1;
        var year = -1;

        TryParse.Integer tpi = new TryParse.Integer();
        if (tpi.TryParseInt(parts[0]))
        {
            month = tpi.LastInt;
            if (tpi.TryParseInt(parts[1]))
            {
                day = tpi.LastInt;
                if (tpi.TryParseInt(parts[2]))
                {
                    year = tpi.LastInt;
                    try
                    {
                        result = new DateTime(year, month, day, 0, 0, 0);
                    }
                    catch (Exception ex)
                    {
                        ThrowEx.CannotCreateDateTime(year, month, day, 0, 0, 0, ex);
                    }
                }
            }
        }
        return result;
    }
    #endregion

    #region Only time
    // Parses a US time string (hh:mm tt). Seconds can be omitted.
    /// <summary>
    /// Parse time USA.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse time USA result.</returns>
    public static DateTime ParseTimeUSA(string text)
    {
        var result = DateTime.MinValue;
        var mainParts = text.Split(' ').ToList(); //SHSplit.SplitChar(text, new Char[] { ' ' });
        if (mainParts.Count == 2)
        {
            var isPm = false;
            var amOrPm = mainParts[1].ToLower();

            if (amOrPm == "pm" || amOrPm == "am")
            {
                if (amOrPm == "pm")
                {
                    isPm = true;
                }
                var timeText = mainParts[0];
                var parts = timeText.Split(':').ToList(); //SH.SplitChar(timeText, new Char[] { ':' });
                if (parts.Count == 2)
                {
                    text += ":00";
                    parts = text.Split(':').ToList(); //SHSplit.SplitChar(text, new Char[] { ':' });
                }
                int hours = -1;
                int minutes = -1;
                int seconds = -1;
                if (parts.Count == 3)
                {
                    TryParse.Integer itp = new TryParse.Integer();
                    if (itp.TryParseInt(parts[0]))
                    {
                        hours = itp.LastInt;
                        if (itp.TryParseInt(parts[1]))
                        {
                            minutes = itp.LastInt;
                            if (itp.TryParseInt(parts[2]))
                            {
                                seconds = itp.LastInt;
                                result = DateTime.Today;
                                if (!isPm && hours == 12)
                                {
                                    hours = 0;
                                }
                                else if (isPm)
                                {
                                    hours += 12;
                                }
                                result = result.AddHours(hours);
                                result = result.AddMinutes(minutes);
                                result = result.AddSeconds(seconds);
                            }
                        }
                    }
                }
            }
        }
        return result;
    }
    #endregion

    #region Date and time
    // Parses a US date-time string (mm/dd/yyyy hh:mm tt). Seconds can be omitted.
    /// <summary>
    /// Parse date time USA.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse date time USA result.</returns>
    public static DateTime ParseDateTimeUSA(string text)
    {
        var parts = text.Split(' '); //SHSplit.Split(text, "");
        DateTime date = ParseDateUSA(parts[0]);
        var time = ParseTimeUSA(parts[1] + " " + parts[2]);
        return DTHelperGeneral.Combine(date, time);
    }
    #endregion
    #endregion



    #region Helper
    // Calculates a past date by subtracting the specified period from today.
    // Input format: "{number}_{days|weeks|years|months}" (e.g. "7_days", "2_weeks").
    /// <summary>
    /// Calculate start of period.
    /// </summary>
    /// <param name="periodText">The period text.</param>
    /// <returns>The calculate start of period result.</returns>
    public static DateTime CalculateStartOfPeriod(string periodText)
    {
        int days = -1;
        int number = -1;

        var parts = periodText.Split('_').ToList(); //SHSplit.SplitNone(periodText, new String[] { "_" });
        if (parts.Count == 2)
        {
            TryParse.Integer intParser = new TryParse.Integer();
            if (intParser.TryParseInt(parts[0].ToString()))
            {
                number = intParser.LastInt;
            }
            else
            {
                number = 1;
            }

            switch (parts[1])
            {
                case "days":
                    days = number;
                    break;
                case "weeks":
                    days = 7 * number;
                    break;
                case "years":
                    days = 365 * number;
                    break;
                case "months":
                    days = 31 * number;
                    break;
                default:
                    days = 1;
                    break;
            }
        }
        days *= -1;
        return DateTime.Today.AddDays(days);
    }

    // Formats a DateTime as an English date string with day of week prefix (e.g. "Wednesday, 6/21/1989").
    /// <summary>
    /// Date to string with day of week EN.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The date to string with day of week EN result.</returns>
    public static string DateToStringWithDayOfWeekEN(DateTime dt)
    {
        return dt.DayOfWeek.ToString() + ", " + ToShortDateString(dt);
    }
    #endregion

    #region Date and time
    // Its named ToString due to exactly same format return dt.ToString while is en-us localization
    // 21.6.1989 / 6/21/1989 + " " + mm:ss tt
    /// <summary>
    /// To string.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The to string result.</returns>
    public static string ToString(DateTime dt)
    {
        return ToShortDateString(dt) + " " + ToShortTimeString(dt);
    }
    #endregion

    #region ToString
    #region Only date
    // 21.6.1989 / 6/21/1989
    /// <summary>
    /// To short date string.
    /// </summary>
    /// <param name="today">The today.</param>
    /// <returns>The to short date string result.</returns>
    public static string ToShortDateString(DateTime today)
    {
        return ToShortDateString(today, DateTime.MinValue, DTHelperMulti.DateToString(today, LangsDt.en));
    }

    // 21.6.1989 / 6/21/1989
    /// <summary>
    /// To short date string.
    /// </summary>
    /// <param name="today">The today.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <param name="returnWhenA1isA2">The return when a 1 is a 2.</param>
    /// <returns>The to short date string result.</returns>
    public static string ToShortDateString(DateTime today, DateTime defaultValue, string returnWhenA1isA2)
    {
        if (today == defaultValue)
        {
            return returnWhenA1isA2;
        }
        return DTHelperMulti.DateToString(today, LangsDt.en);
    }
    #endregion



    #region Only time (without seconds)
    // mm:ss tt
    /// <summary>
    /// To short time string.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>The to short time string result.</returns>
    public static string ToShortTimeString(DateTime dt)
    {
        return string.Format("{0:hh:mm tt}", dt);
    }
    #endregion
    #endregion
}
