namespace SunamoDateTime.Data;

public class DateTimeOrShort
{
    public short ShortValue { get; set; }

    public DateTime DateTimeValue { get; set; }

    private bool useDateTime = false;

    public object Value
    {
        get
        {
            if (!useDateTime)
            {
                return ShortValue;
            }
            else
            {
                return DateTimeValue;
            }
        }
    }

    public static DateTimeOrShort FromShort(DateTime dateTIme)
    {
        return FromShort(NormalizeDate.To(dateTIme));
    }

    public static DateTimeOrShort FromShort(short value)
    {
        DateTimeOrShort result = new();
        result.ShortValue = value;
        return result;
    }

    public static DateTimeOrShort FromDateTime(DateTime dateTime)
    {
        DateTimeOrShort result = new();
        result.useDateTime = true;
        result.DateTimeValue = dateTime;
        return result;
    }
}
