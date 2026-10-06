namespace SunamoDateTime._sunamo.SunamoBts;

internal static class BTS
{
    internal static int? ParseInt(string text, int? defaultValue)
    {
        if (int.TryParse(text, out var parsedValue))
        {
            return parsedValue;
        }
        return defaultValue;
    }

    internal static int TryParseInt(string text, int defaultValue)
    {
        return TryParseInt(text, defaultValue, false);
    }

    internal static int TryParseInt(string text, int defaultValue, bool throwException)
    {
        if (int.TryParse(text, out var parsedValue))
        {
            return parsedValue;
        }
        else
        {
            if (throwException)
            {
                ThrowEx.NotInt(text, null);
            }
        }
        return defaultValue;
    }
}
