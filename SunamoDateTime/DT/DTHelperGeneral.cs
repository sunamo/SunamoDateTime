namespace SunamoDateTime.DT;

/// <summary>
/// Represents the DT helper general type.
/// </summary>
public partial class DTHelperGeneral
{
    /// <summary>
    /// Get dates between.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>The get dates between result.</returns>
    public static List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
    {
        List<DateTime> allDates = new List<DateTime>();
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            allDates.Add(date);
        return allDates;
    }

    /// <summary>
    /// Week of year from date.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The week of year from date result.</returns>
    public static int WeekOfYearFromDate(DateTime dateTime)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            dateTime = dateTime.AddDays(3 - (int)day);
        }

        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    // Gets the start of the week (Monday) for the specified date.
    // rolloverDayOfWeek: Optional day of week threshold. If the current day is >= this day, returns the start of NEXT week instead of current week.
    /// <summary>
    /// Start of week monday.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="rolloverDayOfWeek">The rollover day of week.</param>
    /// <returns>The start of week monday result.</returns>
    public static DateTime StartOfWeekMonday(DateTime dateTime, DayOfWeek? rolloverDayOfWeek)
    {
        DayOfWeek startOfWeek = DayOfWeek.Monday;
        if (dateTime.DayOfWeek == startOfWeek)
        {
            return dateTime;
        }

        var diff = (dateTime.DayOfWeek - startOfWeek);
        var part = (7 + diff);
        int diff2 = part % 7;
        var addedDays = dateTime.AddDays(-1 * diff2);
        if (rolloverDayOfWeek.HasValue)
        {
            if (dateTime.DayOfWeek > (rolloverDayOfWeek - 1))
            {
                addedDays = addedDays.AddDays(7);
            }
        }

        return addedDays.Date;
    }

    // Find four digit letter in any string
    /// <summary>
    /// Parse year.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse year result.</returns>
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

    /// <summary>
    /// Set minute.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="minute">The minute.</param>
    /// <returns>The set minute result.</returns>
    public static DateTime SetMinute(DateTime dateTime, int minute)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, minute, dateTime.Second);
    }

    /// <summary>
    /// Set hour.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="hour">The hour.</param>
    /// <returns>The set hour result.</returns>
    public static DateTime SetHour(DateTime dateTime, int hour)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, dateTime.Minute, dateTime.Second);
    }

    // Check also for MinValue and MaxValue
    /// <summary>
    /// Has nullable date time value.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The has nullable date time value result.</returns>
    public static bool HasNullableDateTimeValue(DateTime? dateTime)
    {
        if (dateTime.HasValue)
        {
            if (dateTime.Value != DateTime.MinValue && dateTime.Value != DateTime.MaxValue)
            {
                return true;
            }
        }

        return false;
    }

    // Is counting only time, return as non-normalized int
    /// <summary>
    /// Date time to seconds only time.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="secondsInHour">The seconds in hour.</param>
    /// <returns>The date time to seconds only time result.</returns>
    public static long DateTimeToSecondsOnlyTime(DateTime dateTime, long secondsInHour)
    {
        long result = dateTime.Hour * secondsInHour;
        result += dateTime.Minute * DTConstants.SecondsInMinute;
        result += dateTime.Second;
        result *= TimeSpan.TicksPerSecond;
        return result;
    }

    /// <summary>
    /// Add days.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="days">The days.</param>
    /// <returns>The add days result.</returns>
    public static DateTime AddDays(ref DateTime dateTime, double days)
    {
        dateTime = dateTime.AddDays(days);
        return dateTime;
    }

    // Subtract A2 from A1
    /// <summary>
    /// Substract.
    /// </summary>
    /// <param name="firstDateTime">The first date time.</param>
    /// <param name="secondDateTime">The second date time.</param>
    /// <returns>The substract result.</returns>
    public static TimeSpan Substract(DateTime firstDateTime, DateTime secondDateTime)
    {
        TimeSpan timeSpan = firstDateTime - secondDateTime;
        return timeSpan;
    }

    /// <summary>
    /// Set date to min value.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The set date to min value result.</returns>
    public static DateTime SetDateToMinValue(DateTime dateTime)
    {
        DateTime minVal = DateTime.MinValue;
        return new DateTime(minVal.Year, minVal.Month, minVal.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    }

    /// <summary>
    /// Set today.
    /// </summary>
    /// <param name="ugtFirstStep">The ugt first step.</param>
    /// <returns>The set today result.</returns>
    public static DateTime SetToday(DateTime ugtFirstStep)
    {
        DateTime today = DateTime.Today;
        return new DateTime(today.Year, today.Month, today.Day, ugtFirstStep.Hour, ugtFirstStep.Minute, ugtFirstStep.Second);
    }

    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    /// <returns>The create result.</returns>
    public static DateTime? Create(string year, string month, string day)
    {
        return Create(int.Parse(year), int.Parse(month), int.Parse(day));
    }

    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    /// <returns>The create result.</returns>
    public static DateTime? Create(int year, int month, int day)
    {
        try
        {
            return new DateTime(year, month, day);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // because can return null, wont throw excepiton there
            ThrowEx.Custom(ex);
            return null;
        }
    }

    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="day">The day.</param>
    /// <param name="month">The month.</param>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <returns>The create result.</returns>
    public static DateTime Create(string day, string month, string hour, string minute)
    {
        return new DateTime(1, int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), 0);
    }

    /// <summary>
    /// Create time.
    /// </summary>
    /// <param name="hour">The hour.</param>
    /// <param name="minutes">The minutes.</param>
    /// <returns>The create time result.</returns>
    public static DateTime CreateTime(string hour, string minutes)
    {
        DateTime today = DateTime.MinValue;
        today = today.AddHours(double.Parse(hour));
        today = today.AddMinutes(double.Parse(minutes));
        return today;
    }

    // Returns the last two digits of a year (e.g. 2024 becomes "24").
    /// <summary>
    /// Short year.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <returns>The short year result.</returns>
    public static string ShortYear(int year)
    {
        var text = year.ToString();
        text = text.Substring(2, 2);
        return text;
    }

    // Converts a two-digit year string to a four-digit year string. Years 0-79 map to 2000-2079, 80-99 map to 1980-1999.
    /// <summary>
    /// Long year.
    /// </summary>
    /// <param name="yearText">The year text.</param>
    /// <returns>The long year result.</returns>
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

    // Converts a byte value to a four-digit year by prepending "2" (e.g. 24 becomes 2024).
    /// <summary>
    /// Full year.
    /// </summary>
    /// <param name="yearByte">The year byte.</param>
    /// <returns>The full year result.</returns>
    public static int FullYear(byte yearByte)
    {
        var yearString = yearByte.ToString().PadLeft(3, '0');
        return int.Parse("2" + yearString);
    }

    /// <summary>
    /// Calculate age.
    /// </summary>
    /// <param name="birthDate">The birth date.</param>
    /// <param name="dtMinVal">The dt min val.</param>
    /// <returns>The calculate age result.</returns>
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

    /// <summary>
    /// Seconds in month.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The seconds in month result.</returns>
    public static long SecondsInMonth(DateTime dateTime)
    {
        return DTConstants.SecondsInDay * DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
    }

    /// <summary>
    /// Seconds in year.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <returns>The seconds in year result.</returns>
    public static long SecondsInYear(int year)
    {
        long daysInYear = 365;
        if (DateTime.IsLeapYear(year))
        {
            daysInYear = 366;
        }

        return daysInYear * DTConstants.SecondsInDay;
    }

    /// <summary>
    /// Short today.
    /// </summary>
    /// <returns>The short today result.</returns>
    public static DateTimeOrShort ShortToday()
    {
        return DateTimeOrShort.FromShort(NormalizeDate.To(DateTime.Today));
    }

    /// <summary>
    /// Without time.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The without time result.</returns>
    public static DateTime WithoutTime(DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
    }

    /// <summary>
    /// Without date.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The without date result.</returns>
    public static DateTime WithoutDate(DateTime dateTime)
    {
        return new DateTime(1, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second);
    }
}
