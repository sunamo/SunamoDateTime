namespace SunamoDateTime._public;

public class FromToTSHDt<T>
{
    public bool IsEmpty { get; set; }
    protected long fromLong;
    public FromToUseDateTime UseType { get; set; } = FromToUseDateTime.DateTime;
    protected long toLong;

    public FromToTSHDt()
    {
        var type = typeof(T);
        if (type == typeof(int)) UseType = FromToUseDateTime.None;
    }

    private FromToTSHDt(bool isEmpty) : this()
    {
        this.IsEmpty = isEmpty;
    }

    public FromToTSHDt(T from, T to, FromToUseDateTime useType = FromToUseDateTime.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.UseType = useType;
    }

    public T From
    {
        get => (T)(dynamic)fromLong!;
        set => fromLong = (long)(dynamic)value!;
    }

    public T To
    {
        get => (T)(dynamic)toLong!;
        set => toLong = (long)(dynamic)value!;
    }

    public long FromL => fromLong;

    public long ToL => toLong;
}
