namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperMulti
{
    public static string XNoKnownPeriod = "NoKnownPeriod";
    /// <summary>
    /// If A1 could be lower than 1d, return 1d
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "calculateTime"></param>
    public static string OperationLastedInLocalizateString(TimeSpan tt, LangsDt lang)
    {
        List<string> vr = new List<string>();
        if (tt.Hours == 1)
        {
            if (lang == LangsDt.cs)
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
            if (lang == LangsDt.cs)
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
            if (lang == LangsDt.cs)
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
                if (lang == LangsDt.cs)
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
                if (lang == LangsDt.cs)
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
                if (lang == LangsDt.cs)
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
                    if (lang == LangsDt.cs)
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
                    if (lang == LangsDt.cs)
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
                    if (lang == LangsDt.cs)
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
                        if (lang == LangsDt.cs)
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
                        if (lang == LangsDt.cs)
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
                        if (lang == LangsDt.cs)
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
                        if (lang == LangsDt.cs)
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

        string text = string.Join(' ', vr);
        return text;
    }

    /// <summary>
    /// 21.6.1989 / 6/21/1989
    /// </summary>
    /// <param name = "p"></param>
    /// <param name = "l"></param>
    /// <param name = "dtMinVal"></param>
    public static string DateToStringOrSE(DateTime dateTime, LangsDt lang, DateTime dtMinVal)
    {
        if (dateTime == dtMinVal)
        {
            return "";
        }

        return DTHelperMulti.DateToString(dateTime, lang);
    }

    /// <summary>
    /// m/d/yyyy / d/m/yyyy
    /// </summary>
    /// <param name = "p"></param>
    public static DateTime? ParseDateMonthDayYear(string p, out int? dayTo)
    {
        dayTo = -1;
        var text = SHSplit.SplitNone(p, new string[] { "/" });
        if (text.Count == 1)
        {
            text = SHSplit.SplitNone(p, new string[] { "." });
            text[0] = DayTo(text[0], out dayTo);
            DateTime vr = DTHelperCs.ParseDateCzech(text[0] + "." + text[1] + "." + text[2]);
            if (vr != DateTime.MinValue)
            {
                return vr;
            }
        }
        else
        {
            text[1] = DayTo(text[1], out dayTo);
            DateTime vr = DTHelperCs.ParseDateCzech(text[1] + "." + text[0] + "." + text[2]);
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
            var builder = v.Split('-')[0];
            dayTo = int.Parse(v);
            return builder;
        }

        dayTo = -1;
        return v;
    }

    static Type type = typeof(DTHelperMulti);
    /// <summary>
    /// 21.6.1989 11:22 (fill zero)
    /// 6/21/1989 11:22 (fill zero)
    /// Vrátí datum a čas v českém formátu bez ms a text
    /// </summary>
    /// <param name = "d"></param>
    public static string DateTimeToString(DateTime dateTime, LangsDt lang, DateTime dtMinVal)
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
            return dateTime.Day + "." + dateTime.Month + "." + dateTime.Year + " " + dateTime.Hour.ToString("D2") + ":" + dateTime.Hour.ToString("D2");
        }
        else
        {
            // 6/21/1989 11:22 (fill zero)
            return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year + " " + dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2");
        }
    }
}