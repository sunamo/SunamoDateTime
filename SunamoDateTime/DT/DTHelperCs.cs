namespace SunamoDateTime.DT;

/// <summary>
/// Represents the DT helper cs type.
/// </summary>
public partial class DTHelperCs
{
    static Type type = typeof(DTHelperCs);

    // Wednesday, 21.6.1989
    /// <summary>
    /// Date to string with day of week CS.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The date to string with day of week CS result.</returns>
    public static string DateToStringWithDayOfWeekCS(DateTime dateTime)
    {
        return DayOfWeek2DayOfWeek(dateTime.DayOfWeek) + ", " + dateTime.Day + "." + dateTime.Month + "." + dateTime.Year;
    }

    // 11:22 dont fill up with zero
    /// <summary>
    /// To short time from seconds.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <returns>The to short time from seconds result.</returns>
    public static string ToShortTimeFromSeconds(long from)
    {
        var dt = DateTime.MinValue;
        dt = dt.AddSeconds(from);
        return ToShortTime(dt, true);
    }

    // With seconds
    // 11:22:00 (depends on A2)
    /// <summary>
    /// To short time with second.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="fillUpByZeros">The fill up by zeros.</param>
    /// <returns>The to short time with second result.</returns>
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

    // Must be int[] due to params[]
    static string ToShortTimeWorker(int[] parts, bool fillUpByZeros)
    {
        if (fillUpByZeros)
        {
            return string.Join(":", parts);
        }

        return string.Join(":", parts);
    }

    // 11:22
    // Without seconds
    /// <summary>
    /// To short time.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="fillUpByZeros">The fill up by zeros.</param>
    /// <returns>The to short time result.</returns>
    public static string ToShortTime(DateTime dateTime, bool fillUpByZeros = false)
    {
        // Must be array due to params []
        var parts = new List<int>([dateTime.Hour, dateTime.Minute]).ToArray(); //CAG.ToArrayT();
        return ToShortTimeWorker(parts, fillUpByZeros);
    }

    // hh:mm:ss
    // If fail, return DT.MinValue
    // Seconds can be omit
    /// <summary>
    /// Parse time czech.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse time czech result.</returns>
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

    // 21.6.1989. DateTime.MinValue when cannot be parsed
    /// <summary>
    /// Parse date czech.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse date czech result.</returns>
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
