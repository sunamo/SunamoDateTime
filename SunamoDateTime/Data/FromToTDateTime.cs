// variables names: ok
namespace SunamoDateTime.Data;

/// <summary>
/// Represents a time range with DateTime formatting capabilities.
/// EN: Extends FromToTDt with DateTime string conversion methods.
/// CZ: Rozšiřuje FromToTDt o metody pro konverzi DateTime na string.
/// </summary>
/// <typeparam name="T">The type of the From and To values (must be a struct)</typeparam>
public class FromToTDateTime<T> : FromToTDt<T> where T : struct
{
    /// <summary>
    /// Converts the time range to DateTime string representation.
    /// EN: Formats the time range based on UseType (DateTime, Unix, or UnixJustTime).
    /// CZ: Formátuje časový rozsah podle UseType (DateTime, Unix, nebo UnixJustTime).
    /// </summary>
    /// <param name="lang">Language for formatting</param>
    /// <returns>Formatted DateTime string</returns>
    protected override string ToStringDateTime(LangsDt lang)
    {
        if (UseType == FromToUseDateTime.DateTime)
        {
            var fromTime = DTHelperCs.ToShortTimeFromSeconds(fromLong);
            if (toLong != 0)
            {
                return $"{fromTime}-{DTHelperCs.ToShortTimeFromSeconds(toLong)}";
            }
            return $"{fromTime}";
        }
        else if (UseType == FromToUseDateTime.Unix)
        {
            var fromDateTime = UnixDateConverter.From(fromLong);
            var fromFormatted = DTHelperMulti.DateTimeToString(fromDateTime, lang, DTConstants.UnixFsStart);
            if (toLong != 0)
            {
                return $"{fromFormatted}-{DTHelperMulti.DateTimeToString(UnixDateConverter.From(toLong), lang, DTConstants.UnixFsStart)}";
            }
            return $"{fromFormatted}";
        }
        else if (UseType == FromToUseDateTime.UnixJustTime)
        {
            var fromDateTime = UnixDateConverter.From(fromLong);
            var fromTime = DTHelperMulti.TimeToString(fromDateTime, lang, DTConstants.UnixFsStart);
            if (toLong != 0)
            {
                return $"{fromTime}-{DTHelperMulti.TimeToString(UnixDateConverter.From(toLong), lang, DTConstants.UnixFsStart)}";
            }
            return $"{fromTime}";
        }
        return string.Empty;
    }
}