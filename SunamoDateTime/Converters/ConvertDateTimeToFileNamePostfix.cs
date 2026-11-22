namespace SunamoDateTime.Converters;

/// <summary>
/// Represents the convert date time to file name postfix type.
/// </summary>
public class ConvertDateTimeToFileNamePostfix
{
    private static char s_delimiter = '_';

    /// <summary>
    /// To convention.
    /// </summary>
    /// <param name="postfix">The postfix.</param>
    /// <param name="dateTime">The date time.</param>
    /// <param name="includeTime">The include time.</param>
    /// <returns>The to convention result.</returns>
    public static string ToConvention(string postfix, DateTime dateTime, bool includeTime)
    {
        return DTHelper.DateTimeToFileName(dateTime, includeTime) + s_delimiter + postfix;
    }

    /// <summary>
    /// From convention.
    /// </summary>
    /// <param name="fileNameWithoutExtension">The file name without extension.</param>
    /// <param name="includeTime">The include time.</param>
    /// <returns>The from convention result.</returns>
    public static DateTime? FromConvention(string fileNameWithoutExtension, bool includeTime)
    {
        string postfix = "";
        return DTHelper.FileNameToDateTimePostfix(fileNameWithoutExtension, includeTime, out postfix);
    }
}
