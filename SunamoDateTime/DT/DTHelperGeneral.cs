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

    public static int WeekOfYearFromDate(DateTime dateTime)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            dateTime = dateTime.AddDays(3 - (int)day);
        }

        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
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
        var parts = text.Split(new Char[] { '-', '/' });
        foreach (var item in parts)
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

    public static DateTime SetMinute(DateTime dateTime, int minute)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, minute, dateTime.Second);
    }

    public static DateTime SetHour(DateTime dateTime, int hour)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, dateTime.Minute, dateTime.Second);
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
    /// <param name = "dateTime">DateTime to convert</param>
    /// <param name = "secondsInHour">Seconds in one hour</param>
    public static long DateTimeToSecondsOnlyTime(DateTime dateTime, long secondsInHour)
    {
        long result = dateTime.Hour * secondsInHour;
        result += dateTime.Minute * DTConstants.SecondsInMinute;
        result += dateTime.Second;
        result *= TimeSpan.TicksPerSecond;
        //result += SqlServerHelper.DateTimeMinVal
        return result;
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

    public static string LongYear(string yearText)
    {
        var year = int.Parse(yearText);
        if (year <= 79)
        {
            return "20" + year;
        }
        else
        {
            return "19" + year;
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
    /// <param name = "birthDate">Birth date</param>
    /// <param name = "dtMinVal">Minimum DateTime value</param>
    public static byte CalculateAge(DateTime birthDate, DateTime dtMinVal)
    {
        if (birthDate == dtMinVal)
        {
            return 255;
        }

        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age))
            age--;
        byte result = (byte)age;
        if (result == 255)
        {
            return 0;
        }

        return result;
    }

    public static long SecondsInMonth(DateTime dt)
    {
        return DTConstants.SecondsInDay * DateTime.DaysInMonth(dt.Year, dt.Month);
    }

    public static long SecondsInYear(int year)
    {
        long daysInYear = 365;
        if (DateTime.IsLeapYear(year))
        {
            daysInYear = 366;
        }

        return daysInYear * DTConstants.SecondsInDay;
    }

    public static DateTimeOrShort ShortToday()
    {
        return DateTimeOrShort.FromShort(NormalizeDate.To(DateTime.Today));
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