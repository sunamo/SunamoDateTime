namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperCs
{
    /// <summary>
    /// Calculates age from a date and returns it as a Czech localized string with instrumental case (kym/cim).
    /// </summary>
    /// <param name="dateTime">The birth/start date</param>
    /// <param name="calculateTime">Whether to include time units (hours, minutes, seconds)</param>
    /// <param name="lang">The language for localization (must be Czech)</param>
    /// <param name="dtMinVal">The minimum DateTime value representing an unset date</param>
    public static string CalculateAgeAndAddRightStringKymCim(DateTime dateTime, bool calculateTime, LangsDt lang, DateTime dtMinVal)
    {
        if (lang != LangsDt.cs)
        {
            ThrowEx.NotImplementedCase(lang);
        }

        if (dateTime == dtMinVal)
        {
            return "";
        }

        int age = DTHelperGeneral.CalculateAge(dateTime, dtMinVal);
        if (age == 0)
        {
            DateTime Date1 = dateTime;
            DateTime Date2 = DateTime.Now;
            int months = (Date2.Year - Date1.Year) * 12 + Date2.Month - Date1.Month;
            if (months < 3)
            {
                TimeSpan tt = Date2 - Date1;
                int totalWeeks = tt.Days / 7;
                if (totalWeeks == 0)
                {
                    if (tt.Days == 1)
                    {
                        return tt.Days + " dnem";
                    }
                    else if (tt.Days < 5 && tt.Days > 1)
                    {
                        return tt.Days + " dny";
                    }
                    else
                    {
                        if (calculateTime)
                        {
                            if (tt.Hours == 1)
                            {
                                return tt.Hours + " hodinou";
                            }
                            else if (tt.Hours > 1 && tt.Hours < 5)
                            {
                                return tt.Hours + " hodinami";
                            }
                            else if (tt.Hours > 4)
                            {
                                return tt.Hours + " hodinami";
                            }
                            else
                            {
                                // Hodin je méně než 1
                                if (tt.Minutes == 1)
                                {
                                    return tt.Minutes + " minutou";
                                }
                                else if (tt.Minutes > 1 && tt.Minutes < 5)
                                {
                                    return tt.Minutes + " minutami";
                                }
                                else if (tt.Minutes > 4)
                                {
                                    return tt.Minutes + " minutami";
                                }
                                else //if (tt.Minutes == 0)
                                {
                                    if (tt.Seconds == 1)
                                    {
                                        return tt.Seconds + " sekundou";
                                    }
                                    else if (tt.Seconds > 1 && tt.Seconds < 5)
                                    {
                                        return tt.Seconds + " sekundami";
                                    }
                                    else //if (tt.Seconds > 4)
                                    {
                                        return tt.Seconds + " sekundami";
                                    }
                                }
                            }
                        }
                        else
                        {
                            return "  dnem";
                        }
                    }
                //return tt.Days + " dnů";
                }
                else if (totalWeeks == 1)
                {
                    return totalWeeks + " t\u00FDdnem";
                }
                else if (totalWeeks < 5 && totalWeeks > 1)
                {
                    return totalWeeks + " t\u00FDdny";
                }
                else
                {
                    return totalWeeks + " t\u00FDdny";
                }
            }
            else
            {
                if (months == 1)
                {
                    return months + " m\u011Bs\u00EDcem";
                }
                else if (months > 1 && months < 5)
                {
                    return months + " m\u011Bs\u00EDci";
                }
                else
                {
                    return months + " m\u011Bs\u00EDc\u016F";
                }
            }
        }
        else if (age == 1)
        {
            return "  rokem";
        }
        else if (age > 1 && age < 5)
        {
            return age + " roky";
        }
        else if (age > 4 || age == 0)
        {
            return age + " roky";
        }
        else
        {
            return "Nezn\u00E1m\u00FD v\u011Bk";
        }
    }

    /// <summary>
    /// Formats a date-time interval as a localized string (e.g. "21.6.1989 11:22-22.6.1989 14:00").
    /// </summary>
    /// <param name="startDateTime">The start of the interval</param>
    /// <param name="endDateTime">The end of the interval</param>
    /// <param name="lang">The language for localization</param>
    /// <param name="dtMinVal">The minimum DateTime value representing an unset date</param>
    /// <returns>Formatted interval string</returns>
    public static string IntervalToString(DateTime startDateTime, DateTime endDateTime, LangsDt lang, DateTime dtMinVal)
    {
        return DTHelperMulti.DateTimeToString(startDateTime, lang, dtMinVal) + "-" + DTHelperMulti.DateTimeToString(endDateTime, lang, dtMinVal);
    }

    /// <param name = "dayOfWeek"></param>
    public static string DayOfWeek2DenVTydnu(DayOfWeek dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case DayOfWeek.Monday:
                return DTConstants.Pondeli;
            case DayOfWeek.Tuesday:
                return DTConstants.Utery;
            case DayOfWeek.Wednesday:
                return DTConstants.Streda;
            case DayOfWeek.Thursday:
                return DTConstants.Ctvrtek;
            case DayOfWeek.Friday:
                return DTConstants.Patek;
            case DayOfWeek.Saturday:
                return DTConstants.Sobota;
            case DayOfWeek.Sunday:
                return DTConstants.Nedele;
        }

        throw new Exception("Nezn\u00E1m\u00FD den v t\u00FDdnu");
    }

    /// <summary>
    /// Return actual time(for example 12:00:00:000) and after that A1 postfix
    /// </summary>
    /// <param name = "postfix"></param>
    public static string AppendToFrontOnlyTime(string postfix)
    {
        DateTime dt = DateTime.Now;
        return dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2") + ":" + dt.Millisecond.ToString("D3") + "" + postfix;
    }

    /// <summary>
    /// 21.6.1989
    /// </summary>
    /// <param name = "dateTime">DateTime to convert</param>
    public static string ToShortDate(DateTime dateTime)
    {
        return string.Join(".", dateTime.Day, dateTime.Month, dateTime.Year);
    }

    /// <summary>
    ///
    /// Wednesday, 21.6.1989 11:22 (dont fill with zero)
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateTimeToStringWithDayOfWeekCS(DateTime dateTime)
    {
        return DayOfWeek2DenVTydnu(dateTime.DayOfWeek) + ", " + dateTime.Day + "." + dateTime.Month + "." + dateTime.Year + " " + dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2");
    }

    /// <summary>
    /// Parses a Czech-formatted date-time string using the Czech culture info.
    /// </summary>
    /// <param name="text">The Czech date-time string to parse</param>
    /// <returns>Parsed DateTime</returns>
    public static DateTime ParseDateTimeCzech(string text)
    {
        var dateTime = DateTime.Parse(text, CultureInfos.Cz);
        return dateTime;
    }

    /// <summary>
    /// Returns a Czech "time ago" string describing how long ago the past date was relative to the current date.
    /// </summary>
    /// <param name="pastDate">The past date to compare</param>
    /// <param name="currentDate">The current/reference date</param>
    /// <returns>Czech localized "time ago" string</returns>
    public static string ToTimeAgo(DateTime pastDate, DateTime currentDate)
    {
        TimeSpan timeSince = currentDate.Subtract(pastDate);
        if (timeSince.TotalSeconds < 1)
        {
            return "právě teď";
        }

        if (timeSince.TotalSeconds < 60)
        {
            int seconds = (int)timeSince.TotalSeconds;
            return seconds == 1 ? "před 1 sekundou" : $"před {seconds} sekundami";
        }

        if (timeSince.TotalMinutes < 60)
        {
            int minutes = (int)timeSince.TotalMinutes;
            return minutes == 1 ? "před 1 minutou" : $"před {minutes} minutami";
        }

        if (timeSince.TotalHours < 24)
        {
            int hours = (int)timeSince.TotalHours;
            return hours == 1 ? "před 1 hodinou" : $"před {hours} hodinami";
        }

        if (timeSince.TotalDays < 30) // Approximate month
        {
            int days = (int)timeSince.TotalDays;
            if (days == 1)
                return "včera";
            if (days < 5)
                return $"před {days} dny"; // For 2, 3, 4 days
            return $"před {days} dny"; // For 5+ days (same skloňování as above for simplicity)
        }

        if (timeSince.TotalDays < 365) // Approximate year
        {
            int months = (int)(timeSince.TotalDays / 30.436875); // Average days in a month
            if (months <= 1)
                return "před 1 měsícem"; // Handle 0 or 1 month as "před 1 měsícem"
            if (months < 5)
                return $"před {months} měsíci";
            return $"před {months} měsíci"; // For 5+ months (same skloňování)
        }
        else
        {
            int years = (int)(timeSince.TotalDays / 365.25); // Account for leap years
            if (years <= 1)
                return "před 1 rokem";
            if (years < 5)
                return $"před {years} lety";
            return $"před {years} lety"; // For 5+ years (same skloňování)
        }
    }

    /// <summary>
    /// Returns a Czech "time ago" string describing how long ago the past date was relative to now.
    /// </summary>
    /// <param name="pastDate">The past date to compare</param>
    /// <returns>Czech localized "time ago" string</returns>
    public static string ToTimeAgo(DateTime pastDate)
    {
        return ToTimeAgo(pastDate, DateTime.Now);
    }
}