// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoDateTime._sunamo.SunamoBts;

// Bud 


//namespace SunamoDateTime;
internal static class BTS
{
    //    internal static Func<string, int?, int?> ParseInt;
    //    internal static Func<bool, bool, string> BoolToStringEn;
    //    internal static Func<bool, string> BoolToString;

    internal static int? ParseInt(string entry, int? _default)
    {
        int lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2))
        {
            return lastInt2;
        }
        return _default;
    }

    internal static int TryParseInt(string entry, int def)
    {
        return TryParseInt(entry, def, false);
    }

    internal static int TryParseInt(string entry, int def, bool throwEx)
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
