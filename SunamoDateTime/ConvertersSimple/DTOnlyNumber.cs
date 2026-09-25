namespace SunamoDateTime.ConvertersSimple;

public class DTOnlyNumber
{
    public static string To(DateTime dateTime)
    {
        var result = DTHelperGeneral.ShortYear(dateTime.Year) + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2");
        return result;
    }
}
