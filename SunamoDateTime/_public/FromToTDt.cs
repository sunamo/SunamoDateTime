namespace SunamoDateTime._public;

// EN: Contains methods that were earlier in FromToT class.
// CZ: Obsahuje metody které byly dříve ve třídě FromToT.
public class FromToTDt<T> : FromToTSHDt<T> where T : struct
{
    public FromToTDt()
    {
        var type = typeof(T);
        if (type == typeof(int))
        {
            UseType = FromToUseDateTime.None;
        }
    }

    private FromToTDt(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    public FromToTDt(T from, T to, FromToUseDateTime useType = FromToUseDateTime.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.UseType = useType;
    }

    // EN: After calling this method, IsFilledWithData can be used to verify the data.
    // CZ: Po zavolání této metody lze použít IsFilledWithData k ověření dat.
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

    // EN: Returns true if To value is valid (>= 0 and != 0).
    // CZ: Vrací true pokud je hodnota To platná (>= 0 a != 0).
    public bool IsFilledWithData()
    {
        // EN: from != 0 check removed - cannot be used because if "0-24" is entered it would fail
        // CZ: kontrola from != 0 odstraněna - nelze použít protože pokud je zadáno "0-24" selže
        return toLong >= 0 && toLong != 0;
    }

    // EN: Use DTHelperCs.ToShortTimeFromSeconds to convert back.
    // CZ: Pro převod zpět použijte DTHelperCs.ToShortTimeFromSeconds.
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

    protected virtual string ToStringDateTime(LangsDt lang)
    {
        return "";
    }
}
