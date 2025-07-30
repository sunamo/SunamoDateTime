namespace SunamoDateTime.DT;

public class DTHelperCs
{
    static Type type = typeof(DTHelperCs);

    #region ToString
    #region Only date
    /// <summary>
    /// Středa, 21.6.1989
    /// </summary>
    /// <param name="dt"></param>
    public static string DateToStringWithDayOfWeekCS(DateTime dt)
    {
        return DayOfWeek2DenVTydnu(dt.DayOfWeek) + ", " + dt.Day + "." + dt.Month + "." + dt.Year;
    }
    #endregion

    #region Time with seconds
    /// <summary>
    /// 11:22 dont fill up with zero
    /// </summary>
    /// <param name="from"></param>
    public static string ToShortTimeFromSeconds(long from)
    {
        var dt = DateTime.MinValue;
        dt = dt.AddSeconds(from);

        return ToShortTime(dt, true);
    }

    /// <summary>
    /// With seconds
    /// 11:22:00 (depends on A2)
    /// </summary>
    /// <param name="value"></param>
    /// <param name="fillUpByZeros"></param>
    public static string ToShortTimeWithSecond(DateTime value, bool fillUpByZeros = false)
    {
        // Must be array due to params []
        var parts = new int[] { value.Hour, value.Minute, value.Second };

        return ToShortTimeWorker(parts, fillUpByZeros);
    }
    #endregion

    /// <summary>
    /// Must be int[] due to params[]
    /// </summary>
    /// <param name="parts"></param>
    /// <param name="fillUpByZeros"></param>
    static string ToShortTimeWorker(int[] parts, bool fillUpByZeros)
    {
        if (fillUpByZeros)
        {
            return string.Join(":", parts);
        }
        return string.Join(":", parts);
    }

    #region Time without seconds
    /// <summary>
    /// 11:22
    /// Without seconds
    /// </summary>
    /// <param name="value"></param>
    /// <param name="fillUpByZeros"></param>
    public static string ToShortTime(DateTime value, bool fillUpByZeros = false)
    {
        // Must be array due to params []
        var parts = new List<int>([value.Hour, value.Minute]).ToArray(); //CAG.ToArrayT();

        return ToShortTimeWorker(parts, fillUpByZeros);
    }
    #endregion
    #endregion

    #region Parse
    #region Time with seconds
    /// <summary>
    /// hh:mm:ss
    /// If fail, return DT.MinValue
    /// Seconds can be omit
    /// </summary>
    /// <param name="t"></param>
    public static DateTime ParseTimeCzech(string t)
    {
        var vr = DateTime.MinValue;
        var parts = t.Split(':').ToList(); //SHSplit.SplitChar(t, new char[] { ':' });
        if (parts.Count == 2)
        {
            t += ":00";
            parts = t.Split(':').ToList(); //SHSplit.SplitChar(t, new char[] { ':' });
        }
        int hours = -1;
        int minutes = -1;
        int seconds = -1;
        if (parts.Count == 3)
        {
            TryParse.Integer itp = new TryParse.Integer();
            if (itp.TryParseInt(parts[0]))
            {
                hours = itp.lastInt;
                if (itp.TryParseInt(parts[1]))
                {
                    minutes = itp.lastInt;
                    if (itp.TryParseInt(parts[2]))
                    {
                        seconds = itp.lastInt;
                        vr = DateTime.Today;
                        vr = vr.AddHours(hours);
                        vr = vr.AddMinutes(minutes);
                        vr = vr.AddSeconds(seconds);
                    }
                }
            }
        }
        return vr;
    }
    #endregion

    #region Date
    /// <summary>
    /// 21.6.1989. DateTime.MinValue when cannot be parsed
    /// </summary>
    /// <param name="input"></param>
    public static DateTime ParseDateCzech(string input)
    {
        DateTime vr = DateTime.MinValue;
        var parts = input.Split('.').ToList(); //SHSplit.SplitChar(input, new char[] { '.' });
        var day = -1;
        var month = -1;
        var year = -1;
        var dt = DateTime.Today;

        TryParse.Integer tpi = new TryParse.Integer();
        if (tpi.TryParseInt(parts[0]))
        {
            day = tpi.lastInt;
            if (parts.Count > 1)
            {

                if (tpi.TryParseInt(parts[1]))
                {

                    month = tpi.lastInt;
                    if (parts.Count > 2)
                    {
                        if (tpi.TryParseInt(parts[2]))
                        {
                            year = tpi.lastInt;
                            try
                            {
                                vr = new DateTime(year, month, day, 0, 0, 0);
                            }
                            catch (Exception ex)
                            {
                                ThrowEx.CannotCreateDateTime(year, month, day, 0, 0, 0, ex);
                            }
                        }
                    }
                    else
                    {
                        year = dt.Year;
                    }
                }

            }
            else
            {
                month = dt.Month;
            }
        }
        return vr;
    }
    #endregion
    #endregion

    #region Helper
    /// <summary>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="calculateTime"></param>
    public static string CalculateAgeAndAddRightStringKymCim(DateTime dateTime, bool calculateTime, LangsDt l, DateTime dtMinVal)
    {
        if (l != LangsDt.cs)
        {
            ThrowEx.NotImplementedCase(l);
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

    public static string IntervalToString(DateTime oDTStart, DateTime oDTEnd, LangsDt l, DateTime dtMinVal)
    {
        return DTHelperMulti.DateTimeToString(oDTStart, l, dtMinVal) + "-" + DTHelperMulti.DateTimeToString(oDTEnd, l, dtMinVal);
    }

    /// <param name="dayOfWeek"></param>
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
        return null;
    }
    #endregion

    #region ToString
    #region Time (with s and ms)
    /// <summary>
    /// Return actual time(for example 12:00:00:000) and after that A1 postfix
    /// </summary>
    /// <param name="defin"></param>
    public static string AppendToFrontOnlyTime(string defin)
    {
        DateTime dt = DateTime.Now;
        return dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2") + ":" + dt.Millisecond.ToString("D3") + "" + defin;
    }
    #endregion

    #region Date
    /// <summary>
    /// 21.6.1989
    /// </summary>
    /// <param name="d"></param>
    public static string ToShortDate(DateTime d)
    {
        return string.Join(".", d.Day, d.Month, d.Year);
    }
    #endregion

    #region Date with time (with seconds and Day of week)
    /// <summary>
    ///
    /// Wednesday, 21.6.1989 11:22 (dont fill with zero)
    /// </summary>
    /// <param name="dt"></param>
    public static string DateTimeToStringWithDayOfWeekCS(DateTime dt)
    {
        return DayOfWeek2DenVTydnu(dt.DayOfWeek) + ", " + dt.Day + "." + dt.Month + "." + dt.Year + " " + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2");
    }

    public static DateTime ParseDateTimeCzech(string s)
    {
        var dt = DateTime.Parse(s, CultureInfos.cz);
        return dt;
    }
    #endregion
    #endregion

    #region Calculating
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
            if (days == 1) return "včera";
            if (days < 5) return $"před {days} dny"; // For 2, 3, 4 days
            return $"před {days} dny"; // For 5+ days (same skloňování as above for simplicity)
        }
        if (timeSince.TotalDays < 365) // Approximate year
        {
            int months = (int)(timeSince.TotalDays / 30.436875); // Average days in a month
            if (months <= 1) return "před 1 měsícem"; // Handle 0 or 1 month as "před 1 měsícem"
            if (months < 5) return $"před {months} měsíci";
            return $"před {months} měsíci"; // For 5+ months (same skloňování)
        }
        else
        {
            int years = (int)(timeSince.TotalDays / 365.25); // Account for leap years
            if (years <= 1) return "před 1 rokem";
            if (years < 5) return $"před {years} lety";
            return $"před {years} lety"; // For 5+ years (same skloňování)
        }
    }

    public static string ToTimeAgo(DateTime pastDate)
    {
        return ToTimeAgo(pastDate, DateTime.Now);
    }

    /// <summary>
    /// If !A2 and time will be lower than 1 day, I got day
    /// A3 was be originally SqlServerHelper.DateTimeMinVal. Return empty string when A3 == A1
    /// 
    /// dtMinVal je skutečně nutné zadávat ručně, protože DateTime nemůže být deklarován jako Consts. Nejde ho ani zadat jako = new DateTime(1, 1, 1, 0, 0, 0). Jediná možnost je = new DateTime() která má stejné hodnoty propert jako MinValue.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="calculateTime"></param>
    public static string CalculateAgeAndAddRightString(DateTime dateTime, bool calculateTime, DateTime dtMinVal = new DateTime())
    {
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
                        return "  den";
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
                                return tt.Hours + " hodina";
                            }
                            else if (tt.Hours > 1 && tt.Hours < 5)
                            {
                                return tt.Hours + " hodiny";
                            }
                            else if (tt.Hours > 4)
                            {
                                return tt.Hours + " hodin";
                            }
                            else
                            {
                                // Hodin je méně než 1
                                if (tt.Minutes == 1)
                                {
                                    return tt.Minutes + " minuta";
                                }
                                else if (tt.Minutes > 1 && tt.Minutes < 5)
                                {
                                    return tt.Minutes + " minuty";
                                }
                                else if (tt.Minutes > 4)
                                {
                                    return tt.Minutes + " minut";
                                }
                                else //if (tt.Minutes == 0)
                                {
                                    if (tt.Seconds == 1)
                                    {
                                        return tt.Seconds + " sekunda";
                                    }
                                    else if (tt.Seconds > 1 && tt.Seconds < 5)
                                    {
                                        return tt.Seconds + " sekundy";
                                    }
                                    else //if (tt.Seconds > 4)
                                    {
                                        return tt.Seconds + " sekund";
                                    }
                                }
                            }
                        }
                        else
                        {
                            return tt.Days + " dn\u016F";
                        }
                    }
                }
                else if (totalWeeks == 1)
                {
                    return totalWeeks + " t\u00FDden";
                }
                else if (totalWeeks < 5 && totalWeeks > 1)
                {
                    return totalWeeks + " t\u00FDdny";
                }
                else
                {
                    return totalWeeks + " t\u00FDdn\u016F";
                }
            }
            else
            {
                if (months == 1)
                {
                    return months + " m\u011Bs\u00EDc";
                }
                else if (months > 1 && months < 5)
                {
                    return months + " m\u011Bs\u00EDce";
                }
                else
                {
                    return months + " m\u011Bs\u00EDc\u016F";
                }
            }
        }
        else if (age == 1)
        {
            return "  rok";
        }
        else if (age > 1 && age < 5)
        {
            return age + " roky";
        }
        else if (age > 4 || age == 0)
        {
            return age + " rok\u016F";
        }
        else
        {
            return "Nezn\u00E1m\u00FD v\u011Bk";
        }
    }
    #endregion
}