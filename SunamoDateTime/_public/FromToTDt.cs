namespace SunamoDateTime._public;

// Contains methods that were earlier in FromToT class.
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

    // After calling this method, IsFilledWithData can be used to verify the data.
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

        // Normalize start time: "0" becomes "00:01"
        if (parts[0] == "0")
        {
            parts[0] = "00:01";
        }

        // Normalize end time: "24" becomes "23:59"
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

    // Returns true if To value is valid (>= 0 and != 0).
    public bool IsFilledWithData()
    {
        // from != 0 check removed - cannot be used because if "0-24" is entered it would fail
        return toLong >= 0 && toLong != 0;
    }

    // Use DTHelperCs.ToShortTimeFromSeconds to convert back.
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
