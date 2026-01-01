namespace SunamoDateTime._sunamo.SunamoParsing;

/// <summary>
/// Try-parse utilities for various types.
/// EN: Provides safe parsing with stored results.
/// CZ: Poskytuje bezpečné parsování s uloženými výsledky.
/// </summary>
internal class TryParse
{
    /// <summary>
    /// DateTime parsing utilities.
    /// EN: Moved to DTHelperMulti.cs.
    /// CZ: Přesunuto do DTHelperMulti.cs.
    /// </summary>
    internal class DateTime
    {
        // was moved to E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoDateTime\DT\DTHelperMulti.cs
    }

    /// <summary>
    /// Integer parsing utilities with result storage.
    /// EN: Provides TryParse with last result stored in LastInt property.
    /// CZ: Poskytuje TryParse s posledním výsledkem uloženým v LastInt property.
    /// </summary>
    internal class Integer
    {
        /// <summary>
        /// Singleton instance for Integer parsing.
        /// </summary>
        internal static Integer Instance { get; set; } = new Integer();

        /// <summary>
        /// Stores the last successfully parsed integer value.
        /// EN: Contains the result of the last TryParseInt call.
        /// CZ: Obsahuje výsledek posledního volání TryParseInt.
        /// </summary>
        internal int LastInt { get; set; } = -1;

        /// <summary>
        /// Tries to parse text to integer and stores result in LastInt.
        /// EN: Returns true if parsing succeeds, otherwise false. Result can be found in LastInt property.
        /// CZ: Vrátí true pokud se podaří vyparsovat, jinak false. Výsledek najdeš v LastInt property.
        /// </summary>
        /// <param name="text">Text to parse</param>
        /// <returns>True if parsing succeeds, false otherwise</returns>
        internal bool TryParseInt(string text)
        {
            if (int.TryParse(text, out var parsedValue))
            {
                LastInt = parsedValue;
                return true;
            }
            return false;
        }
    }
}