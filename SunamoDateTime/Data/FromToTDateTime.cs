namespace SunamoDateTime.Data;

/// <summary>
/// Represents the from to t date time t type.
/// </summary>
public class FromToTDateTime<T> : FromToTDt<T> where T : struct
{
    /// <summary>
    /// To string date time.
    /// </summary>
    /// <param name="lang">The lang.</param>
    /// <returns>The to string date time result.</returns>
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
