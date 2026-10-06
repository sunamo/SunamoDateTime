namespace SunamoDateTime._sunamo.SunamoParsing;

internal class TryParse
{
    internal class DateTime
    {
        // was moved to E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoDateTime\DT\DTHelperMulti.cs
    }

    internal class Integer
    {
        internal static Integer Instance { get; set; } = new Integer();

        internal int LastInt { get; set; } = -1;

        internal bool TryParseInt(string text)
        {
            if (int.TryParse(text, out var parsedValue))
            {
                LastInt = parsedValue;
                return true;
            }
            return false;
        }
    }
}
