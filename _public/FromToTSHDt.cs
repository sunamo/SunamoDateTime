namespace SunamoDateTime._public;


public class FromToTSHDt<T>
{

    public bool empty;
    protected long fromL;
    public FromToUseDateTime ftUse = FromToUseDateTime.DateTime;
    protected long toL;
    public FromToTSHDt()
    {
        var t = typeof(T);
        if (t == typeof(int)) ftUse = FromToUseDateTime.None;
    }
    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromToTSHDt(bool empty) : this()
    {
        this.empty = empty;
    }
    /// <summary>
    ///     A3 true = DateTime
    ///     A3 False = None
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="ftUse"></param>
    public FromToTSHDt(T from, T to, FromToUseDateTime ftUse = FromToUseDateTime.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
    public T from
    {
        get => (T)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }
    public T to
    {
        get => (T)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }
    public long FromL => fromL;
    public long ToL => toL;
}