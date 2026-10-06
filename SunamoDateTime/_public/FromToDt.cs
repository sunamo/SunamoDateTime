namespace SunamoDateTime._public;

// EN: Must have both from and to values entered. No event can have unlimited time.
// CZ: Musí mít zadané obě hodnoty from a to. Žádná událost nemůže mít neomezený čas.
public class FromToDt : FromToTSHDt<long>
{
    public static FromToDt Empty = new(true);

    public FromToDt()
    {
    }

    private FromToDt(bool isEmpty)
    {
        this.IsEmpty = isEmpty;
    }

    public FromToDt(long from, long to, FromToUseDateTime useType = FromToUseDateTime.DateTime)
    {
        this.From = from;
        this.To = to;
        this.UseType = useType;
    }
}
