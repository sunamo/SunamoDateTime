namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperMulti
{
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
    /// <param name = "dateTime"></param>
    /// <param name = "l"></param>
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

    /// <summary>
    /// Return whether can be parse with DTHelperCs.ParseDateCzech or DTHelperEn.ParseDateUSA
    /// </summary>
    /// <param name = "r"></param>
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
    /// <param name = "datum"></param>
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

    /// <summary>
    /// 21.6.1989 / 6/21/1989
    /// </summary>
    /// <param name = "p"></param>
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