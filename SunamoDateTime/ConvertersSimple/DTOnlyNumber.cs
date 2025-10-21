// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoDateTime.ConvertersSimple;

public class DTOnlyNumber
{
    static Type type = typeof(DTOnlyNumber);

    public static string To(DateTime s)
    {
        var s2 = DTHelperGeneral.ShortYear(s.Year) + s.Month.ToString("D2") + s.Day.ToString("D2");
        return s2;
    }


}
