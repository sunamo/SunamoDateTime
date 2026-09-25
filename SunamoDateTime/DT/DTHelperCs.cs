namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// Provides Czech-localized DateTime formatting, parsing and age calculation methods.
/// </summary>
public partial class DTHelperCs
{
    static Type type = typeof(DTHelperCs);
    /// <summary>
    /// Středa, 21.6.1989
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string DateToStringWithDayOfWeekCS(DateTime dateTime)
    {
        return DayOfWeek2DenVTydnu(dateTime.DayOfWeek) + ", " + dateTime.Day + "." + dateTime.Month + "." + dateTime.Year;
    }

    /// <summary>
    /// 11:22 dont fill up with zero
    /// </summary>
    /// <param name = "from"></param>
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
    /// <param name = "dateTime"></param>
    /// <param name = "fillUpByZeros"></param>
    public static string ToShortTimeWithSecond(DateTime dateTime, bool fillUpByZeros = false)
    {
        // Must be array due to params []
        var parts = new int[]
        {
            dateTime.Hour,
            dateTime.Minute,
            dateTime.Second
        };
        return ToShortTimeWorker(parts, fillUpByZeros);
    }

    /// <summary>
    /// Must be int[] due to params[]
    /// </summary>
    /// <param name = "parts"></param>
    /// <param name = "fillUpByZeros"></param>
    static string ToShortTimeWorker(int[] parts, bool fillUpByZeros)
    {
        if (fillUpByZeros)
        {
            return string.Join(":", parts);
        }

        return string.Join(":", parts);
    }

    /// <summary>
    /// 11:22
    /// Without seconds
    /// </summary>
    /// <param name = "dateTime"></param>
    /// <param name = "fillUpByZeros"></param>
    public static string ToShortTime(DateTime dateTime, bool fillUpByZeros = false)
    {
        // Must be array due to params []
        var parts = new List<int>([dateTime.Hour, dateTime.Minute]).ToArray(); //CAG.ToArrayT();
        return ToShortTimeWorker(parts, fillUpByZeros);
    }

    /// <summary>
    /// hh:mm:ss
    /// If fail, return DT.MinValue
    /// Seconds can be omit
    /// </summary>
    /// <param name = "text"></param>
    public static DateTime ParseTimeCzech(string text)
    {
        var vr = DateTime.MinValue;
        var parts = text.Split(':').ToList(); //SHSplit.SplitChar(t, new char[] { ':' });
        if (parts.Count == 2)
        {
            text += ":00";
            parts = text.Split(':').ToList(); //SHSplit.SplitChar(t, new char[] { ':' });
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

    /// <summary>
    /// 21.6.1989. DateTime.MinValue when cannot be parsed
    /// </summary>
    /// <param name = "text"></param>
    public static DateTime ParseDateCzech(string text)
    {
        DateTime vr = DateTime.MinValue;
        var parts = text.Split('.').ToList(); //SHSplit.SplitChar(input, new char[] { '.' });
        var day = -1;
        var month = -1;
        var year = -1;
        var dt = DateTime.Today;
        TryParse.Integer tpi = new TryParse.Integer();
        if (tpi.TryParseInt(parts[0]))
        {
            day = tpi.LastInt;
            if (parts.Count > 1)
            {
                if (tpi.TryParseInt(parts[1]))
                {
                    month = tpi.LastInt;
                    if (parts.Count > 2)
                    {
                        if (tpi.TryParseInt(parts[2]))
                        {
                            year = tpi.LastInt;
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
}