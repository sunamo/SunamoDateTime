namespace SunamoDateTime._sunamo.SunamoBts;

/// <summary>
/// Base Type System parsing utilities.
/// EN: Provides safe parsing methods for basic types with default values.
/// CZ: Poskytuje bezpečné parsovací metody pro základní typy s výchozími hodnotami.
/// </summary>
internal static class BTS
{
    /// <summary>
    /// Parses a string to nullable int with default value fallback.
    /// EN: Returns parsed int or default value if parsing fails.
    /// CZ: Vrací naparsovaný int nebo výchozí hodnotu pokud parsing selže.
    /// </summary>
    /// <param name="text">The text to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>Parsed int or default value</returns>
    internal static int? ParseInt(string text, int? defaultValue)
    {
        int parsedValue = 0;
        if (int.TryParse(text, out parsedValue))
        {
            return parsedValue;
        }
        return defaultValue;
    }

    /// <summary>
    /// Tries to parse a string to int with default value fallback.
    /// EN: Returns parsed int or default value if parsing fails, without throwing exception.
    /// CZ: Vrací naparsovaný int nebo výchozí hodnotu pokud parsing selže, bez vyhození výjimky.
    /// </summary>
    /// <param name="text">The text to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>Parsed int or default value</returns>
    internal static int TryParseInt(string text, int defaultValue)
    {
        return TryParseInt(text, defaultValue, false);
    }

    /// <summary>
    /// Tries to parse a string to int with optional exception throwing.
    /// EN: Returns parsed int or default value. Optionally throws exception on parse failure.
    /// CZ: Vrací naparsovaný int nebo výchozí hodnotu. Volitelně vyhodí výjimku při selhání parsingu.
    /// </summary>
    /// <param name="text">The text to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <param name="throwException">True to throw exception on parse failure</param>
    /// <returns>Parsed int or default value</returns>
    internal static int TryParseInt(string text, int defaultValue, bool throwException)
    {
        int parsedValue = 0;
        if (int.TryParse(text, out parsedValue))
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