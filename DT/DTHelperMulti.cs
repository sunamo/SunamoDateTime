namespace SunamoDateTime.DT;

public class DTHelperMulti
{
    public System.DateTime lastDateTime = System.DateTime.Today;

    /// <summary>
    /// Vrátí True pokud se podaří vyparsovat, jinak false.
    /// Výsledek najdeš v proměnné lastDateTime
    /// </summary>
    /// <param name="p"></param>
    public bool TryParseDateTime(string r)
    {
        bool isValid = false;
        lastDateTime = DTHelper.IsValidDateTimeText(r);
        isValid = lastDateTime != System.DateTime.MinValue;
        //}
        if (!isValid)
        {
            lastDateTime = DTHelper.IsValidDateText(r);
            isValid = lastDateTime != System.DateTime.MinValue;
        }
        if (!isValid)
        {
            lastDateTime = DTHelper.IsValidTimeText(r);
            isValid = lastDateTime != System.DateTime.MinValue;
        }
        return lastDateTime != System.DateTime.MinValue;
    }

    #region Other
    /// <summary>
    /// If A1 could be lower than 1d, return 1d
    /// </summary>
    /// <param name="ts"></param>
    /// <param name="calculateTime"></param>
    public static string AddRightStringToTimeSpan(TimeSpan tt, bool calculateTime, LangsDt l)
    {
        int age = tt.TotalYears();

        if (tt.TotalMilliseconds == 0)
        {
            int months = tt.TotalMonths();
            if (months < 3)
            {
                int totalWeeks = tt.Days / 7;
                if (totalWeeks == 0)
                {
                    if (tt.Days == 1)
                    {
                        if (l == LangsDt.cs)
                        {
                            return tt.Days + " den";
                        }
                        else
                        {
                            return tt.Days + " day";
                        }
                    }
                    else if (tt.Days < 5 && tt.Days > 1)
                    {
                        if (l == LangsDt.cs)
                        {
                            return tt.Days + " dn\u00ED";
                        }
                        else
                        {
                            return tt.Days + " days";
                        }
                    }
                    else
                    {
                        if (calculateTime)
                        {
                            if (tt.Hours == 1)
                            {
                                if (l == LangsDt.cs)
                                {
                                    return tt.Hours + " hodinu";
                                }
                                else
                                {
                                    return tt.Hours + " hour";
                                }
                            }
                            else if (tt.Hours > 1 && tt.Hours < 5)
                            {
                                if (l == LangsDt.cs)
                                {
                                    return tt.Hours + " hodiny";
                                }
                                else
                                {
                                    return tt.Hours + " hours";
                                }
                            }
                            else if (tt.Hours > 4)
                            {
                                if (l == LangsDt.cs)
                                {
                                    return tt.Hours + " hodin";
                                }
                                else
                                {
                                    return tt.Hours + " hours";
                                }
                            }
                            else
                            {
                                // Hodin je méně než 1
                                if (tt.Minutes == 1)
                                {
                                    if (l == LangsDt.cs)
                                    {
                                        return tt.Minutes + " minutu";
                                    }
                                    else
                                    {
                                        return tt.Minutes + " minute";
                                    }
                                }
                                else if (tt.Minutes > 1 && tt.Minutes < 5)
                                {
                                    if (l == LangsDt.cs)
                                    {
                                        return tt.Minutes + " minuty";
                                    }
                                    else
                                    {
                                        return tt.Minutes + " minutes";
                                    }
                                }
                                else if (tt.Minutes > 4)
                                {
                                    if (l == LangsDt.cs)
                                    {
                                        return tt.Minutes + " minut";
                                    }
                                    else
                                    {
                                        return tt.Minutes + " minutes";
                                    }
                                }
                                else //if (tt.Minutes == 0)
                                {
                                    if (tt.Seconds == 1)
                                    {
                                        if (l == LangsDt.cs)
                                        {
                                            return tt.Seconds + " sekundu";
                                        }
                                        else
                                        {
                                            return tt.Seconds + " second";
                                        }
                                    }
                                    else if (tt.Seconds > 1 && tt.Seconds < 5)
                                    {
                                        if (l == LangsDt.cs)
                                        {
                                            return tt.Seconds + " sekundy";
                                        }
                                        else
                                        {
                                            return tt.Seconds + " seconds";
                                        }
                                    }
                                    else //if (tt.Seconds > 4)
                                    {
                                        if (l == LangsDt.cs)
                                        {
                                            return tt.Seconds + " sekund";
                                        }
                                        else
                                        {
                                            return tt.Seconds + " seconds";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (l == LangsDt.cs)
                            {
                                return "~1 den";
                            }
                            else
                            {
                                return "~1 day";
                            }
                        }
                    }
                }
                else if (totalWeeks == 1)
                {
                    if (l == LangsDt.cs)
                    {
                        return totalWeeks + " t\u00FDden";
                    }
                    else
                    {
                        return totalWeeks + " week";
                    }
                }
                else if (totalWeeks < 5 && totalWeeks > 1)
                {
                    if (l == LangsDt.cs)
                    {
                        return totalWeeks + " t\u00FDdny";
                    }
                    else
                    {
                        return totalWeeks + " weeks";
                    }
                }
                else
                {
                    if (l == LangsDt.cs)
                    {
                        return totalWeeks + " t\u00FDdn\u016F";
                    }
                    else
                    {
                        return totalWeeks + " weeks";
                    }
                }
            }
            else
            {
                if (months == 1)
                {
                    if (l == LangsDt.cs)
                    {
                        return months + " m\u011Bs\u00EDc";
                    }
                    else
                    {
                        return months + " months";
                    }
                }
                else if (months > 1 && months < 5)
                {
                    if (l == LangsDt.cs)
                    {
                        return months + " m\u011Bs\u00EDce";
                    }
                    else
                    {
                        return months + " months";
                    }
                }
                else
                {
                    if (l == LangsDt.cs)
                    {
                        return months + " m\u011Bs\u00EDc\u016F";
                    }
                    else
                    {
                        return months + " months";
                    }
                }
            }
        }
        else if (age == 1)
        {
            if (l == LangsDt.cs)
            {
                return "  rok";
            }
            else
            {
                return "  year";
            }
        }
        else if (age > 1 && age < 5)
        {
            if (l == LangsDt.cs)
            {
                return age + " roky";
            }
            else
            {
                return age + " years";
            }
        }
        else if (age > 4 || age == 0)
        {
            if (l == LangsDt.cs)
            {
                return age + " rok\u016F";
            }
            else
            {
                return age + " years";
            }
        }
        else
        {
            if (l == LangsDt.cs)
            {
                return "Nezn\u00E1m\u00FD \u010Das";
            }
            return xNoKnownPeriod;
        }
    }

    public static string xNoKnownPeriod = "NoKnownPeriod";

    /// <summary>
    /// If A1 could be lower than 1d, return 1d
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="calculateTime"></param>
    public static string OperationLastedInLocalizateString(TimeSpan tt, LangsDt l)
    {
        List<string> vr = new List<string>();

        if (tt.Hours == 1)
        {
            if (l == LangsDt.cs)
            {
                vr.Add(tt.Hours + " hodinu");
            }
            else
            {
                vr.Add(tt.Hours + " hour");
            }
        }
        else if (tt.Hours > 1 && tt.Hours < 5)
        {
            if (l == LangsDt.cs)
            {
                vr.Add(tt.Hours + " hodiny");
            }
            else
            {
                vr.Add(tt.Hours + " hours");
            }
        }
        else if (tt.Hours > 4)
        {
            if (l == LangsDt.cs)
            {
                vr.Add(tt.Hours + " hodin");
            }
            else
            {
                vr.Add(tt.Hours + " hours");
            }
        }
        else
        {
            // Hodin je méně než 1
            if (tt.Minutes == 1)
            {
                if (l == LangsDt.cs)
                {
                    vr.Add(tt.Minutes + " minutu");
                }
                else
                {
                    vr.Add(tt.Minutes + " minute");
                }
            }
            else if (tt.Minutes > 1 && tt.Minutes < 5)
            {
                if (l == LangsDt.cs)
                {
                    vr.Add(tt.Minutes + " minuty");
                }
                else
                {
                    vr.Add(tt.Minutes + " minutes");
                }
            }
            else if (tt.Minutes > 4)
            {
                if (l == LangsDt.cs)
                {
                    vr.Add(tt.Minutes + " minut");
                }
                else
                {
                    vr.Add(tt.Minutes + " minutes");
                }
            }
            else //if (tt.Minutes == 0)
            {
                if (tt.Seconds == 1)
                {
                    if (l == LangsDt.cs)
                    {
                        vr.Add(tt.Seconds + " sekundu");
                    }
                    else
                    {
                        vr.Add(tt.Seconds + " second");
                    }
                }
                else if (tt.Seconds > 1 && tt.Seconds < 5)
                {
                    if (l == LangsDt.cs)
                    {
                        vr.Add(tt.Seconds + " sekundy");
                    }
                    else
                    {
                        vr.Add(tt.Seconds + " seconds");
                    }
                }
                else if (tt.Seconds > 4)
                {
                    if (l == LangsDt.cs)
                    {
                        vr.Add(tt.Seconds + " sekund");
                    }
                    else
                    {
                        vr.Add(tt.Seconds + " seconds");
                    }
                }
                else
                {
                    if (tt.Seconds == 1)
                    {
                        if (l == LangsDt.cs)
                        {
                            vr.Add(tt.Milliseconds + " milisekundu");
                        }
                        else
                        {
                            vr.Add(tt.Milliseconds + " millisecond");
                        }
                    }
                    else if (tt.Seconds > 1 && tt.Seconds < 5)
                    {
                        if (l == LangsDt.cs)
                        {
                            vr.Add(tt.Milliseconds + " milisekundy");
                        }
                        else
                        {
                            vr.Add(tt.Milliseconds + " milliseconds");
                        }
                    }
                    else if (tt.Seconds > 4)
                    {
                        if (l == LangsDt.cs)
                        {
                            vr.Add(tt.Milliseconds + " milisekund");
                        }
                        else
                        {
                            vr.Add(tt.Milliseconds + " milliseconds");
                        }
                    }
                    else
                    {
                        if (l == LangsDt.cs)
                        {
                            vr.Add(tt.Milliseconds + " milisekund");
                        }
                        else
                        {
                            vr.Add(tt.Milliseconds + " milliseconds");
                        }
                    }
                }
            }
        }

        string s = string.Join(' ', vr);

        return s;
    }
    #endregion


    #region ToString
    /// <summary>
    /// 21.6.1989 / 6/21/1989
    /// </summary>
    /// <param name="p"></param>
    /// <param name="l"></param>
    /// <param name="dtMinVal"></param>
    public static string DateToStringOrSE(DateTime p, LangsDt l, DateTime dtMinVal)
    {
        if (p == dtMinVal)
        {
            return "";
        }
        return DTHelperMulti.DateToString(p, l);
    }
    #endregion



    #region Parse
    /// <summary>
    /// m/d/yyyy / d/m/yyyy
    /// </summary>
    /// <param name="p"></param>
    public static DateTime? ParseDateMonthDayYear(string p, out int? dayTo)
    {
        dayTo = -1;

        var s = SHSplit.SplitNone(p, new string[] { "/" });
        if (s.Count == 1)
        {
            s = SHSplit.SplitNone(p, new string[] { "." });

            s[0] = DayTo(s[0], out dayTo);

            DateTime vr = DTHelperCs.ParseDateCzech(s[0] + "." + s[1] + "." + s[2]);
            if (vr != DateTime.MinValue)
            {
                return vr;
            }
        }
        else
        {
            s[1] = DayTo(s[1], out dayTo);

            DateTime vr = DTHelperCs.ParseDateCzech(s[1] + "." + s[0] + "." + s[2]);
            if (vr != DateTime.MinValue)
            {
                return vr;
            }
        }
        return null;
    }

    private static string DayTo(string v, out int? dayTo)
    {
        if (v.Contains("-"))
        {

            var b = v.Split('-')[0];
            dayTo = int.Parse(v);
            return b;
        }
        dayTo = -1;
        return v;
    }
    #endregion

    static Type type = typeof(DTHelperMulti);

    #region ToString
    /// <summary>
    /// 21.6.1989 11:22 (fill zero)
    /// 6/21/1989 11:22 (fill zero)
    /// Vrátí datum a čas v českém formátu bez ms a s
    /// </summary>
    /// <param name="d"></param>
    public static string DateTimeToString(DateTime d, LangsDt l, DateTime dtMinVal)
    {
        if (d == dtMinVal)
        {
            if (l == LangsDt.cs)
            {
                return xItWasNotMentioned;
            }
            else
            {
                return xNotIndicated;
            }
        }

        if (l == LangsDt.cs)
        {
            // 21.6.1989 11:22 (fill zero)
            return d.Day + "." + d.Month + "." + d.Year + " " + d.Hour.ToString("D2") + ":" + d.Hour.ToString("D2");
        }
        else
        {
            // 6/21/1989 11:22 (fill zero)
            return d.Month + "/" + d.Day + "/" + d.Year + " " + d.Hour.ToString("D2") + ":" + d.Minute.ToString("D2");
        }
    }

    public static string xItWasNotMentioned = "ItWasNotMentioned";
    public static string xNotIndicated = "NotIndicated";

    public static string TimeToString(DateTime d, LangsDt l, DateTime dtMinVal)
    {
        if (d == dtMinVal)
        {
            if (l == LangsDt.cs)
            {
                return xItWasNotMentioned;
            }
            else
            {
                return xNotIndicated;
            }
        }

        if (l == LangsDt.cs)
        {
            // 21.6.1989 11:22 (fill zero)
            return d.Hour.ToString("D2") + ":" + d.Minute.ToString("D2");
        }
        else
        {
            // 6/21/1989 11:22 (fill zero)
            return d.Hour.ToString("D2") + ":" + d.Minute.ToString("D2");
        }
    }



    /// <summary>
    /// 21.6.1989 (středa) / 6/21/1989 (wednesday)
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="l"></param>
    public static string DateWithDayOfWeek(DateTime dateTime, LangsDt l)
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

        string dayOfWeek = DTConstants.daysInWeekEN[day];
        if (l == LangsDt.cs)
        {
            dayOfWeek = DTConstants.daysInWeekCS[day];
        }

        return DateToString(dateTime, l) + " (" + dayOfWeek + ")";
    }
    #endregion

    public static string DateToStringWithDayOfWeek(DateTime dt, LangsDt l)
    {
        if (l == LangsDt.en)
        {
            return DTHelperEn.DateToStringWithDayOfWeekEN(dt);
        }
        else if (l == LangsDt.cs)
        {
            return DTHelperCs.DateToStringWithDayOfWeekCS(dt);
        }
        else
        {
            ThrowEx.NotImplementedCase(l);
            return null;
        }
    }

    #region IsValid*
    /// <summary>
    /// Return whether can be parse with DTHelperCs.ParseDateCzech or DTHelperEn.ParseDateUSA
    /// </summary>
    /// <param name="r"></param>
    public static DateTime IsValidDateText(string r)
    {
        DateTime dt = DateTime.MinValue;
        r = r.Trim();
        if (r != "")
        {
            var indexTecky = r.IndexOf('.');
            if (indexTecky != -1)
            {
                dt = DTHelperCs.ParseDateCzech(r);
            }
            else
            {
                dt = DTHelperEn.ParseDateUSA(r);
            }
        }
        return dt;
    }

    /// <summary>
    /// A1 can be in en or cs
    /// parse time after first space
    /// </summary>
    /// <param name="datum"></param>
    public static DateTime IsValidDateTimeText(string datum)
    {
        DateTime vr = DateTime.MinValue;
        int indexMezery = datum.IndexOf(' ');
        if (indexMezery != -1)
        {
            var datum2 = DateTime.Today;
            var cas2 = DateTime.Today;
            var datum3 = datum.Substring(0, indexMezery);
            var cas3 = datum.Substring(indexMezery + 1);

            if (datum3.IndexOf('.') != -1)
            {
                datum2 = DTHelperCs.ParseDateCzech(datum3);
            }
            else
            {
                datum2 = DTHelperEn.ParseDateUSA(datum3);
            }

            if (cas3.IndexOf(' ') == -1)
            {
                cas2 = DTHelperCs.ParseTimeCzech(cas3);
            }
            else
            {
                cas2 = DTHelperEn.ParseTimeUSA(cas3);
            }

            if (datum2 != DateTime.MinValue && cas2 != DateTime.MinValue)
            {
                vr = new DateTime(datum2.Year, datum2.Month, datum2.Day, cas2.Hour, cas2.Minute, cas2.Second);
            }
        }

        return vr;
    }

    public static DateTime IsValidTimeText(string r)
    {
        DateTime dt = DateTime.MinValue;
        r = r.Trim();
        if (r != "")
        {
            var indexMezery = r.IndexOf(' ');
            if (indexMezery == -1)
            {
                dt = DTHelperCs.ParseTimeCzech(r);
            }
            else
            {
                dt = DTHelperEn.ParseTimeUSA(r);
            }
        }
        return dt;
    }
    #endregion

    /// <summary>
    /// 21.6.1989 / 6/21/1989
    /// </summary>
    /// <param name="p"></param>
    public static string DateToString(DateTime p, LangsDt l)
    {
        if (l == LangsDt.cs)
        {
            return p.Day + "." + p.Month + "." + p.Year;
        }
        return p.Month + "/" + p.Day + "/" + p.Year;
    }

    public static string FilesFounded(int c, LangsDt l)
    {
        if (l == LangsDt.cs)
        {
            if (c < 2)
            {
                return "soubor nalezen";
            }
            if (c < 5)
            {
                return "soubory nalezeny";
            }
            return "souborů nalezeno";
        }
        return xfilesFounded;
    }

    public static string xfilesFounded = "filesFounded";
}
