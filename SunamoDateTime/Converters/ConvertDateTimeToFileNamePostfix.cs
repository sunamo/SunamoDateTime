namespace SunamoDateTime.Converters;

/// <summary>
/// Converts DateTime to filename with postfix.
/// EN: Formats DateTime as filename with custom postfix appended.
/// CZ: Formátuje DateTime jako název souboru s připojeným vlastním postfixem.
/// </summary>
public class ConvertDateTimeToFileNamePostfix
{
    private static char s_delimiter = '_';

    /// <summary>
    /// Converts DateTime to filename format with postfix.
    /// EN: Creates filename in format: [DateTime]_[postfix]. If postfix contains delimiter (_), it won't be replaced.
    /// CZ: Vytvoří název souboru ve formátu: [DateTime]_[postfix]. Pokud postfix obsahuje delimiter (_), nebude nahrazen.
    /// </summary>
    /// <param name="postfix">The postfix to append after DateTime</param>
    /// <param name="dateTime">The DateTime to convert</param>
    /// <param name="includeTime">True to include time component in filename</param>
    /// <returns>Formatted filename string</returns>
    public static string ToConvention(string postfix, DateTime dateTime, bool includeTime)
    {
        return DTHelper.DateTimeToFileName(dateTime, includeTime) + s_delimiter + postfix;
    }

    /// <summary>
    /// Parses DateTime from filename, ignoring the postfix.
    /// EN: Use DTHelper.FileNameToDateTimePostfix if you need to extract the postfix too.
    /// CZ: Použijte DTHelper.FileNameToDateTimePostfix pokud potřebujete také extrahovat postfix.
    /// </summary>
    /// <param name="fileNameWithoutExtension">Filename without extension to parse</param>
    /// <param name="includeTime">True if filename includes time component</param>
    /// <returns>Parsed DateTime or null if parsing fails</returns>
    public static DateTime? FromConvention(string fileNameWithoutExtension, bool includeTime)
    {
        string postfix = "";
        return DTHelper.FileNameToDateTimePostfix(fileNameWithoutExtension, includeTime, out postfix);
    }
}