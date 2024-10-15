namespace SunamoDateTime.Data;
using SunamoDateTime._public;

public class FromToTDateTime<T> : FromToTDt<T> where T : struct
{
    protected override string ToStringDateTime(LangsDt l)
    {
        if (ftUse == FromToUseDateTime.DateTime)
        {
            var from2 = DTHelperCs.ToShortTimeFromSeconds(fromL);
            if (toL != 0)
            {
                return $"{from2}-{DTHelperCs.ToShortTimeFromSeconds(toL)}";
            }
            return $"{from2}";
        }
        else if (ftUse == FromToUseDateTime.Unix)
        {

            var from2 = UnixDateConverter.From(fromL);
            var from3 = DTHelperMulti.DateTimeToString(from2, l, DTConstants.UnixFsStart);
            if (toL != 0)
            {
                return $"{from3}-{DTHelperMulti.DateTimeToString(UnixDateConverter.From(toL), l, DTConstants.UnixFsStart)}";
            }
            return $"{from3}";
        }
        else if (ftUse == FromToUseDateTime.UnixJustTime)
        {
            var from2 = UnixDateConverter.From(fromL);
            var from3 = DTHelperMulti.TimeToString(from2, l, DTConstants.UnixFsStart);
            if (toL != 0)
            {
                return $"{from3}-{DTHelperMulti.TimeToString(UnixDateConverter.From(toL), l, DTConstants.UnixFsStart)}";
            }
            return $"{from3}";
        }
        return string.Empty;
    }


}