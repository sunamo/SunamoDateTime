namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperMulti
{
    public static string XNoKnownPeriod = "NoKnownPeriod";

    public static string OperationLastedInLocalizateString(TimeSpan timeSpan, LangsDt lang)
    {
        List<string> timeParts = new List<string>();
        if (timeSpan.Hours == 1)
        {
            if (lang == LangsDt.cs)
            {
                timeParts.Add(timeSpan.Hours + " hodinu");
            }
            else
            {
                timeParts.Add(timeSpan.Hours + " hour");
            }
        }
        else if (timeSpan.Hours > 1 && timeSpan.Hours < 5)
        {
            if (lang == LangsDt.cs)
            {
                timeParts.Add(timeSpan.Hours + " hodiny");
            }
            else
            {
                timeParts.Add(timeSpan.Hours + " hours");
            }
        }
        else if (timeSpan.Hours > 4)
        {
            if (lang == LangsDt.cs)
            {
                timeParts.Add(timeSpan.Hours + " hodin");
            }
            else
            {
                timeParts.Add(timeSpan.Hours + " hours");
            }
        }
        else
        {
            // Hodin je méně než 1
            if (timeSpan.Minutes == 1)
            {
                if (lang == LangsDt.cs)
                {
                    timeParts.Add(timeSpan.Minutes + " minutu");
                }
                else
                {
                    timeParts.Add(timeSpan.Minutes + " minute");
                }
            }
            else if (timeSpan.Minutes > 1 && timeSpan.Minutes < 5)
            {
                if (lang == LangsDt.cs)
                {
                    timeParts.Add(timeSpan.Minutes + " minuty");
                }
                else
                {
                    timeParts.Add(timeSpan.Minutes + " minutes");
                }
            }
            else if (timeSpan.Minutes > 4)
            {
                if (lang == LangsDt.cs)
                {
                    timeParts.Add(timeSpan.Minutes + " minut");
                }
                else
                {
                    timeParts.Add(timeSpan.Minutes + " minutes");
                }
            }
            else //if (tt.Minutes == 0)
            {
                if (timeSpan.Seconds == 1)
                {
                    if (lang == LangsDt.cs)
                    {
                        timeParts.Add(timeSpan.Seconds + " sekundu");
                    }
                    else
                    {
                        timeParts.Add(timeSpan.Seconds + " second");
                    }
                }
                else if (timeSpan.Seconds > 1 && timeSpan.Seconds < 5)
                {
                    if (lang == LangsDt.cs)
                    {
                        timeParts.Add(timeSpan.Seconds + " sekundy");
                    }
                    else
                    {
                        timeParts.Add(timeSpan.Seconds + " seconds");
                    }
                }
                else if (timeSpan.Seconds > 4)
                {
                    if (lang == LangsDt.cs)
                    {
                        timeParts.Add(timeSpan.Seconds + " sekund");
                    }
                    else
                    {
                        timeParts.Add(timeSpan.Seconds + " seconds");
                    }
                }
                else
                {
                    if (timeSpan.Milliseconds == 1)
                    {
                        if (lang == LangsDt.cs)
                        {
                            timeParts.Add(timeSpan.Milliseconds + " milisekundu");
                        }
                        else
                        {
                            timeParts.Add(timeSpan.Milliseconds + " millisecond");
                        }
                    }
                    else if (timeSpan.Milliseconds > 1 && timeSpan.Milliseconds < 5)
                    {
                        if (lang == LangsDt.cs)
                        {
                            timeParts.Add(timeSpan.Milliseconds + " milisekundy");
                        }
                        else
                        {
                            timeParts.Add(timeSpan.Milliseconds + " milliseconds");
                        }
                    }
                    else if (timeSpan.Milliseconds > 4)
                    {
                        if (lang == LangsDt.cs)
                        {
                            timeParts.Add(timeSpan.Milliseconds + " milisekund");
                        }
                        else
                        {
                            timeParts.Add(timeSpan.Milliseconds + " milliseconds");
                        }
                    }
                    else
                    {
                        if (lang == LangsDt.cs)
                        {
                            timeParts.Add(timeSpan.Milliseconds + " milisekund");
                        }
                        else
                        {
                            timeParts.Add(timeSpan.Milliseconds + " milliseconds");
                        }
                    }
                }
            }
        }

        string text = string.Join(" ", timeParts);
        return text;
    }

    public static string DateToStringOrSE(DateTime dateTime, LangsDt lang, DateTime dtMinVal)
    {
        if (dateTime == dtMinVal)
        {
            return "";
        }

        return DTHelperMulti.DateToString(dateTime, lang);
    }

    public static DateTime? ParseDateMonthDayYear(string dateText, out int? dayTo)
    {
        dayTo = -1;
        var text = SHSplit.SplitNone(dateText, new string[] { "/" });
        if (text.Count == 1)
        {
            text = SHSplit.SplitNone(dateText, new string[] { "." });
            text[0] = DayTo(text[0], out dayTo);
            DateTime parsedDate = DTHelperCs.ParseDateCzech(text[0] + "." + text[1] + "." + text[2]);
            if (parsedDate != DateTime.MinValue)
            {
                return parsedDate;
            }
        }
        else
        {
            text[1] = DayTo(text[1], out dayTo);
            DateTime parsedDate = DTHelperCs.ParseDateCzech(text[1] + "." + text[0] + "." + text[2]);
            if (parsedDate != DateTime.MinValue)
            {
                return parsedDate;
            }
        }

        return null;
    }

    private static string DayTo(string dayText, out int? dayTo)
    {
        if (dayText.Contains("-"))
        {
            var builder = dayText.Split('-')[0];
            dayTo = int.Parse(dayText);
            return builder;
        }

        dayTo = -1;
        return dayText;
    }

    static Type type = typeof(DTHelperMulti);

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
