// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoDateTime.DT;
public partial class DTHelperMulti
{
    public System.DateTime lastDateTime = System.DateTime.Today;
    /// <summary>
    /// Vrátí True pokud se podaří vyparsovat, jinak false.
    /// Výsledek najdeš v proměnné lastDateTime
    /// </summary>
    /// <param name = "p"></param>
    public bool TryParseDateTime(string r)
    {
        bool isValid = false;
        lastDateTime = DTHelper.IsValidDateTimeText(r);
        isValid = lastDateTime != System.DateTime.MinValue;
        //}
        if (!isValid)
        {
            lastDateTime = DTHelper.IsValidDateText(r);
            isValid = lastDateTime != System.DateTime.MinValue;
        }

        if (!isValid)
        {
            lastDateTime = DTHelper.IsValidTimeText(r);
            isValid = lastDateTime != System.DateTime.MinValue;
        }

        return lastDateTime != System.DateTime.MinValue;
    }
}