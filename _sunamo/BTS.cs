namespace SunamoDateTime;

// Bud 


//namespace SunamoDateTime;
public static class BTS
{
    //    public static Func<string, int?, int?> ParseInt;
    //    public static Func<bool, bool, string> BoolToStringEn;
    //    public static Func<bool, string> BoolToString;

    public static int? ParseInt(string entry, int? _default)
    {
        int lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2))
        {
            return lastInt2;
        }
        return _default;
    }

    public static int TryParseInt(string entry, int def)
    {
        return TryParseInt(entry, def, false);
    }

    public static int TryParseInt(string entry, int def, bool throwEx)
    {
        int lastInt = 0;
        if (int.TryParse(entry, out lastInt))
        {
            return lastInt;
        }
        else
        {
            if (throwEx)
            {
                ThrowEx.NotInt(entry, null);
            }
        }
        return def;
    }
}
