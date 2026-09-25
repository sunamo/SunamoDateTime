namespace SunamoDateTime._public;

/// <summary>
/// Generic time range class with parsing and formatting capabilities.
/// EN: Contains methods that were earlier in FromToT class.
/// CZ: Obsahuje metody které byly dříve ve třídě FromToT.
/// </summary>
/// <typeparam name="T">The type of the From and To values (must be a struct)</typeparam>
public class FromToTDt<T> : FromToTSHDt<T> where T : struct
{
    /// <summary>
    /// Initializes a new instance of the FromToTDt class.
    /// EN: Sets UseType to None for int type.
    /// CZ: Nastaví UseType na None pro typ int.
    /// </summary>
    public FromToTDt()
    {
        var type = typeof(T);
        if (type == typeof(int))
        {
            UseType = FromToUseDateTime.None;
        }
    }

    /// <summary>
    /// Initializes an empty time range.
    /// EN: Use Empty constant outside of class instead of calling this constructor.
    /// CZ: Použijte konstantu Empty mimo třídu místo volání tohoto konstruktoru.
    /// </summary>
    /// <param name="isEmpty">True to create an empty time range</param>
    private FromToTDt(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    /// <summary>
    /// Initializes a time range with specified From and To values.
    /// EN: Creates a time range with the given start and end values.
    /// CZ: Vytvoří časový rozsah se zadanými počáteční a koncovou hodnotou.
    /// </summary>
    /// <param name="from">The start value of the time range</param>
    /// <param name="to">The end value of the time range</param>
    /// <param name="useType">The type of time range usage (DateTime, Unix, None, etc.)</param>
    public FromToTDt(T from, T to, FromToUseDateTime useType = FromToUseDateTime.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.UseType = useType;
    }

    /// <summary>
    /// Parses a time range string and populates From and To values.
    /// EN: After calling this method, IsFilledWithData can be used to verify the data.
    /// CZ: Po zavolání této metody lze použít IsFilledWithData k ověření dat.
    /// </summary>
    /// <param name="text">Time range string (e.g. "12:30-14:00" or "12-14")</param>
    public void Parse(string text)
    {
        List<string> parts;
        if (text.Contains("-"))
        {
            parts = text.Split('-').ToList();
        }
        else
        {
            parts = new List<string>(new string[] { text });
        }

        // EN: Normalize start time: "0" becomes "00:01"
        // CZ: Normalizuje počáteční čas: "0" se stane "00:01"
        if (parts[0] == "0")
        {
            parts[0] = "00:01";
        }

        // EN: Normalize end time: "24" becomes "23:59"
        // CZ: Normalizuje koncový čas: "24" se stane "23:59"
        if (parts.Count > 1 && parts[1] == "24")
        {
            parts[1] = "23:59";
        }

        var fromSeconds = (long)ConvertTimeFormatToSeconds(parts[0]);
        fromLong = fromSeconds;

        if (parts.Count > 1)
        {
            var toSeconds = (long)ConvertTimeFormatToSeconds(parts[1]);
            toLong = toSeconds;
        }
    }

    /// <summary>
    /// Checks if the time range has been filled with data.
    /// EN: Returns true if To value is valid (>= 0 and != 0).
    /// CZ: Vrací true pokud je hodnota To platná (>= 0 a != 0).
    /// </summary>
    /// <returns>True if data is filled, false otherwise</returns>
    public bool IsFilledWithData()
    {
        // EN: from != 0 check removed - cannot be used because if "0-24" is entered it would fail
        // CZ: kontrola from != 0 odstraněna - nelze použít protože pokud je zadáno "0-24" selže
        return toLong >= 0 && toLong != 0;
    }

    /// <summary>
    /// Converts time format string to seconds.
    /// EN: Use DTHelperCs.ToShortTimeFromSeconds to convert back.
    /// CZ: Pro převod zpět použijte DTHelperCs.ToShortTimeFromSeconds.
    /// </summary>
    /// <param name="timeFormat">Time format string (e.g. "12:30" or "12")</param>
    /// <returns>Number of seconds</returns>
    private int ConvertTimeFormatToSeconds(string timeFormat)
    {
        int result = 0;
        if (timeFormat.Contains(":"))
        {
            var parts = timeFormat.Split(':').ToList().ConvertAll(part => int.Parse(part));
            result += parts[0] * (int)DTConstants.SecondsInHour;
            if (parts.Count > 1)
            {
                result += parts[1] * (int)DTConstants.SecondsInMinute;
            }
        }
        else
        {
            if (int.TryParse(timeFormat, out var _))
            {
                result += int.Parse(timeFormat) * (int)DTConstants.SecondsInHour;
            }
        }
        return result;
    }

    /// <summary>
    /// Converts the time range to a string representation.
    /// EN: Returns formatted time range based on UseType.
    /// CZ: Vrací formátovaný časový rozsah podle UseType.
    /// </summary>
    /// <param name="lang">Language for formatting</param>
    /// <returns>String representation of the time range</returns>
    public string ToString(LangsDt lang)
    {
        if (IsEmpty)
        {
            return string.Empty;
        }
        else
        {
            if (new List<FromToUseDateTime>([FromToUseDateTime.DateTime, FromToUseDateTime.Unix, FromToUseDateTime.UnixJustTime]).Any(useType => useType == UseType))
            {
                return ToStringDateTime(lang);
            }
            else if (UseType == FromToUseDateTime.None)
            {
                return From + "-" + To;
            }
            else
            {
                ThrowEx.NotImplementedCase(UseType);
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Converts the time range to DateTime string representation.
    /// EN: Virtual method to be overridden by derived classes.
    /// CZ: Virtuální metoda k přepsání v odvozených třídách.
    /// </summary>
    /// <param name="lang">Language for formatting</param>
    /// <returns>DateTime string representation</returns>
    protected virtual string ToStringDateTime(LangsDt lang)
    {
        return "";
    }
}