namespace SunamoDateTime.ConvertersSimple;

public class DTOnlyNumber
{
    static Type type = typeof(DTOnlyNumber);

    public static string To(DateTime s)
    {
        var s2 = DTHelperGeneral.ShortYear(s.Year) + s.Month.ToString("D2") + s.Day.ToString("D2");
        return s2;
    }

    public static DateTime From(string s)
    {
        ThrowEx.NotImplementedMethod();
        return DateTime.MinValue;
    }


}
