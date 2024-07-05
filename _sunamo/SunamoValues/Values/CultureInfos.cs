namespace SunamoDateTime._sunamo.SunamoValues.Values;


internal class CultureInfos
{
    internal static CultureInfo cz = null;
    internal static IFormatProvider neutral { get; set; }
    internal static void Init()
    {
        if (cz == null)
        {
            cz = CultureInfo.GetCultureInfo("cs");
            if (cz == null)
            {
                System.Diagnostics.Debugger.Break();
                // use cs-CZ
            }
        }
    }
}
