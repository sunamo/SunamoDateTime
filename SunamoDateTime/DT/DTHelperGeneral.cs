namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class DTHelperGeneral
{
    public static List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
    {
        List<DateTime> allDates = new List<DateTime>();
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            allDates.Add(date);
        return allDates;
    }

    public static int WeekOfYearFromDate(DateTime datum)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(datum);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            datum = datum.AddDays(3 - (int)day);
        }

        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(datum, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public static DateTime StartOfWeekMonday(DateTime dt, DayOfWeek? aowWhenCalculateAsStartNextWeek)
    {
        DayOfWeek startOfWeek = DayOfWeek.Monday;
        if (dt.DayOfWeek == startOfWeek)
        {
            return dt;
        }

        var diff = (dt.DayOfWeek - startOfWeek);
        var part = (7 + diff);
        int diff2 = part % 7;
        var addedDays = dt.AddDays(-1 * diff2);
        if (aowWhenCalculateAsStartNextWeek.HasValue)
        {
            if (dt.DayOfWeek > (aowWhenCalculateAsStartNextWeek - 1))
            {
                addedDays = addedDays.AddDays(7);
            }
        }

        return addedDays.Date;
    }

    /// <summary>
    /// Find four digit letter in any string
    /// </summary>
    public static string ParseYear(string text)
    {
        var parameter = text.Split(new Char[] { '-', '/' });
        foreach (var item in parameter)
        {
            if (item.Length == 4)
            {
                if (double.TryParse(item, out var _))
                {
                    return item;
                }
            }
        }

        return string.Empty;
    }

    public static DateTime SetMinute(DateTime d, int v)
    {
        return new DateTime(d.Year, d.Month, d.Day, d.Hour, v, d.Second);
    }

    public static DateTime SetHour(DateTime d, int v)
    {
        return new DateTime(d.Year, d.Month, d.Day, v, d.Minute, d.Second);
    }

    /// <summary>
    /// Check also for MinValue and MaxValue
    /// </summary>
    /// <param name = "dt"></param>
    public static bool HasNullableDateTimeValue(DateTime? dt)
    {
        if (dt.HasValue)
        {
            if (dt.Value != DateTime.MinValue && dt.Value != DateTime.MaxValue)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is counting only time, return as non-normalized int
    /// </summary>
    /// <param name = "t"></param>
    public static long DateTimeToSecondsOnlyTime(DateTime t, long secondsInHour)
    {
        long vr = t.Hour * secondsInHour;
        vr += t.Minute * DTConstants.secondsInMinute;
        vr += t.Second;
        vr *= TimeSpan.TicksPerSecond;
        //vr += SqlServerHelper.DateTimeMinVal
        return vr;
    }

    public static DateTime AddDays(ref DateTime dt, double day)
    {
        dt = dt.AddDays(day);
        return dt;
    }

    /// <summary>
    /// Subtract A2 from A1
    /// </summary>
    /// <param name = "dt1"></param>
    /// <param name = "dt2"></param>
    public static TimeSpan Substract(DateTime dt1, DateTime dt2)
    {
        TimeSpan ts = dt1 - dt2;
        return ts;
    }

    public static DateTime SetDateToMinValue(DateTime dt)
    {
        DateTime minVal = DateTime.MinValue;
        return new DateTime(minVal.Year, minVal.Month, minVal.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
    }

    public static DateTime SetToday(DateTime ugtFirstStep)
    {
        DateTime t = DateTime.Today;
        return new DateTime(t.Year, t.Month, t.Day, ugtFirstStep.Hour, ugtFirstStep.Minute, ugtFirstStep.Second);
    }

    public static DateTime? Create(string y, string m, string d)
    {
        return Create(int.Parse(y), int.Parse(m), int.Parse(d));
    }

    public static DateTime? Create(int y, int m, int d)
    {
        try
        {
            return new DateTime(y, m, d);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // because can return null, wont throw excepiton there
            ThrowEx.Custom(ex);
            return null;
        }
    }

    public static DateTime Create(string day, string month, string hour, string minute)
    {
        return new DateTime(1, int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), 0);
    }

    public static DateTime CreateTime(string hour, string minutes)
    {
        DateTime today = DateTime.MinValue;
        today = today.AddHours(double.Parse(hour));
        today = today.AddMinutes(double.Parse(minutes));
        return today;
    }

    public static string ShortYear(int year)
    {
        var text = year.ToString();
        text = text.Substring(2, 2);
        return text;
    }

    public static string LongYear(string y)
    {
        var i = int.Parse(y);
        if (i <= 79)
        {
            return "20" + i;
        }
        else
        {
            return "19" + i;
        }
    }

    public static int FullYear(byte b)
    {
        var bs = b.ToString().PadLeft(3, '0');
        return int.Parse("2" + bs);
    }

    /// <summary>
    /// A2 = SqlServerHelper.DateTimeMinVal
    /// if A1 = A2, return 255
    /// </summary>
    /// <param name = "bday"></param>
    public static byte CalculateAge(DateTime bday, DateTime dtMinVal)
    {
        if (bday == dtMinVal)
        {
            return 255;
        }

        DateTime today = DateTime.Today;
        int age = today.Year - bday.Year;
        if (bday > today.AddYears(-age))
            age--;
        byte vr = (byte)age;
        if (vr == 255)
        {
            return 0;
        }

        return vr;
    }

    public static long SecondsInMonth(DateTime dt)
    {
        return DTConstants.secondsInDay * DateTime.DaysInMonth(dt.Year, dt.Month);
    }

    public static long SecondsInYear(int year)
    {
        long mal = 365;
        if (DateTime.IsLeapYear(year))
        {
            mal = 366;
        }

        return mal * DTConstants.secondsInDay;
    }

    public static DateTimeOrShort ShortToday()
    {
        return DateTimeOrShort.Sh(NormalizeDate.To(DateTime.Today));
    }

    public static DateTime WithoutTime(DateTime time)
    {
        return new DateTime(time.Year, time.Month, time.Day);
    }

    public static DateTime WithoutDate(DateTime dt)
    {
        return new DateTime(1, 1, 1, dt.Hour, dt.Minute, dt.Second);
    }
}