namespace SunamoDateTime.Converters;

/// <summary>
/// Converts DateTime to filename with prefix.
/// EN: Formats DateTime as filename with custom prefix prepended. Sister class to ConvertDateTimeToFileNamePostfix.
/// CZ: Formátuje DateTime jako název souboru s připojeným vlastním prefixem. Sesterská třída k ConvertDateTimeToFileNamePostfix.
/// </summary>
public class ConvertDateTimeToFileNamePrefix
{
    private static char s_delimiter = '_';

    /// <summary>
    /// Converts DateTime to filename format with prefix.
    /// EN: Creates filename in format: [prefix]_[DateTime]. If prefix contains delimiter (_), it won't be replaced.
    /// CZ: Vytvoří název souboru ve formátu: [prefix]_[DateTime]. Pokud prefix obsahuje delimiter (_), nebude nahrazen.
    /// </summary>
    /// <param name="prefix">The prefix to prepend before DateTime</param>
    /// <param name="dateTime">The DateTime to convert</param>
    /// <param name="includeTime">True to include time component in filename</param>
    /// <returns>Formatted filename string</returns>
    public static string ToConvention(string prefix, DateTime dateTime, bool includeTime)
    {
        return prefix + s_delimiter + DTHelper.DateTimeToFileName(dateTime, includeTime);
    }

    /// <summary>
    /// Parses DateTime from filename, ignoring the prefix.
    /// EN: Use DTHelper.FileNameToDateTimePrefix if you need to extract the prefix too.
    /// CZ: Použijte DTHelper.FileNameToDateTimePrefix pokud potřebujete také extrahovat prefix.
    /// </summary>
    /// <param name="fileNameWithoutExtension">Filename without extension to parse</param>
    /// <param name="includeTime">True if filename includes time component</param>
    /// <returns>Parsed DateTime or null if parsing fails</returns>
    public static DateTime? FromConvention(string fileNameWithoutExtension, bool includeTime)
    {
        string prefix = "";
        return DTHelper.FileNameToDateTimePrefix(fileNameWithoutExtension, includeTime, out prefix);
    }
}