namespace SunamoDateTime._sunamo.SunamoData.Data;


internal class FromToTSHDt<T>
{
    
    internal bool empty;
    protected long fromL;
    internal FromToUseDateTime ftUse = FromToUseDateTime.DateTime;
    protected long toL;
    internal FromToTSHDt()
    {
        var t = typeof(T);
        if (t == Types.tInt) ftUse = FromToUseDateTime.None;
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
    internal FromToTSHDt(T from, T to, FromToUseDateTime ftUse = FromToUseDateTime.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
    internal T from
    {
        get => (T)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }
    internal T to
    {
        get => (T)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }
    internal long FromL => fromL;
    internal long ToL => toL;
}