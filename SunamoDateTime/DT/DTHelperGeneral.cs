namespace SunamoDateTime.DT;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// Provides general-purpose DateTime utility methods for date manipulation, creation, and conversion.
/// </summary>
public partial class DTHelperGeneral
{
    /// <summary>
    /// Returns a list of all dates between the start and end dates, inclusive.
    /// </summary>
    /// <param name="startDate">The start date (inclusive)</param>
    /// <param name="endDate">The end date (inclusive)</param>
    /// <returns>List of all dates in the range</returns>
    public static List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
    {
        List<DateTime> allDates = new List<DateTime>();
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            allDates.Add(date);
        return allDates;
    }

    /// <summary>
    /// Calculates the ISO 8601 week number for the specified date.
    /// </summary>
    /// <param name="dateTime">The date to get the week number for</param>
    /// <returns>ISO 8601 week number (1-53)</returns>
    public static int WeekOfYearFromDate(DateTime dateTime)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            dateTime = dateTime.AddDays(3 - (int)day);
        }

        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    /// <summary>
    /// EN: Gets the start of the week (Monday) for the specified date.
    /// CZ: Získá začátek týdne (pondělí) pro zadané datum.
    /// </summary>
    /// <param name="dateTime">
    /// EN: The date to get the start of the week for.
    /// CZ: Datum pro které se má získat začátek týdne.
    /// </param>
    /// <param name="rolloverDayOfWeek">
    /// EN: Optional day of week threshold. If the current day is >= this day, returns the start of NEXT week instead of current week.
    /// CZ: Volitelný den v týdnu jako práh. Pokud je aktuální den >= tento den, vrátí začátek PŘÍŠTÍHO týdne místo aktuálního týdne.
    /// </param>
    /// <returns>
    /// EN: The Monday of the week (current or next based on threshold).
    /// CZ: Pondělí daného týdne (aktuálního nebo příštího podle prahu).
    /// </returns>
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

    /// <summary>
    /// Returns a new DateTime with the minute component replaced by the specified value.
    /// </summary>
    /// <param name="dateTime">The original DateTime</param>
    /// <param name="minute">The new minute value</param>
    /// <returns>DateTime with the minute replaced</returns>
    public static DateTime SetMinute(DateTime dateTime, int minute)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, minute, dateTime.Second);
    }

    /// <summary>
    /// Returns a new DateTime with the hour component replaced by the specified value.
    /// </summary>
    /// <param name="dateTime">The original DateTime</param>
    /// <param name="hour">The new hour value</param>
    /// <returns>DateTime with the hour replaced</returns>
    public static DateTime SetHour(DateTime dateTime, int hour)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, dateTime.Minute, dateTime.Second);
    }

    /// <summary>
    /// Check also for MinValue and MaxValue
    /// </summary>
    /// <param name = "dateTime"></param>
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

    /// <summary>
    /// Adds the specified number of days to the DateTime reference and returns the result.
    /// </summary>
    /// <param name="dateTime">The DateTime to modify (passed by reference)</param>
    /// <param name="days">The number of days to add (can be negative)</param>
    /// <returns>The modified DateTime</returns>
    public static DateTime AddDays(ref DateTime dateTime, double days)
    {
        dateTime = dateTime.AddDays(days);
        return dateTime;
    }

    /// <summary>
    /// Subtract A2 from A1
    /// </summary>
    /// <param name = "firstDateTime"></param>
    /// <param name = "secondDateTime"></param>
    public static TimeSpan Substract(DateTime firstDateTime, DateTime secondDateTime)
    {
        TimeSpan timeSpan = firstDateTime - secondDateTime;
        return timeSpan;
    }

    /// <summary>
    /// Returns a new DateTime preserving the time component but setting the date to DateTime.MinValue.
    /// </summary>
    /// <param name="dateTime">The DateTime whose time to preserve</param>
    /// <returns>DateTime with MinValue date and original time</returns>
    public static DateTime SetDateToMinValue(DateTime dateTime)
    {
        DateTime minVal = DateTime.MinValue;
        return new DateTime(minVal.Year, minVal.Month, minVal.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    }

    /// <summary>
    /// Returns a new DateTime with today's date and the time from the specified DateTime.
    /// </summary>
    /// <param name="ugtFirstStep">The DateTime whose time component to use</param>
    /// <returns>Today's date with the specified time</returns>
    public static DateTime SetToday(DateTime ugtFirstStep)
    {
        DateTime today = DateTime.Today;
        return new DateTime(today.Year, today.Month, today.Day, ugtFirstStep.Hour, ugtFirstStep.Minute, ugtFirstStep.Second);
    }

    /// <summary>
    /// Creates a DateTime from year, month and day strings. Returns null if creation fails.
    /// </summary>
    /// <param name="year">The year as string</param>
    /// <param name="month">The month as string</param>
    /// <param name="day">The day as string</param>
    /// <returns>Created DateTime or null if arguments are out of range</returns>
    public static DateTime? Create(string year, string month, string day)
    {
        return Create(int.Parse(year), int.Parse(month), int.Parse(day));
    }

    /// <summary>
    /// Creates a DateTime from year, month and day integers. Returns null if creation fails.
    /// </summary>
    /// <param name="year">The year</param>
    /// <param name="month">The month (1-12)</param>
    /// <param name="day">The day (1-31)</param>
    /// <returns>Created DateTime or null if arguments are out of range</returns>
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
    /// Creates a DateTime with year 1 from day, month, hour and minute strings.
    /// </summary>
    /// <param name="day">The day as string</param>
    /// <param name="month">The month as string</param>
    /// <param name="hour">The hour as string</param>
    /// <param name="minute">The minute as string</param>
    /// <returns>Created DateTime with year 1</returns>
    public static DateTime Create(string day, string month, string hour, string minute)
    {
        return new DateTime(1, int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), 0);
    }

    /// <summary>
    /// Creates a DateTime at MinValue date with the specified hour and minutes.
    /// </summary>
    /// <param name="hour">The hour as string</param>
    /// <param name="minutes">The minutes as string</param>
    /// <returns>DateTime.MinValue with added hours and minutes</returns>
    public static DateTime CreateTime(string hour, string minutes)
    {
        DateTime today = DateTime.MinValue;
        today = today.AddHours(double.Parse(hour));
        today = today.AddMinutes(double.Parse(minutes));
        return today;
    }

    /// <summary>
    /// Returns the last two digits of a year (e.g. 2024 becomes "24").
    /// </summary>
    /// <param name="year">The four-digit year</param>
    /// <returns>Two-digit year string</returns>
    public static string ShortYear(int year)
    {
        var text = year.ToString();
        text = text.Substring(2, 2);
        return text;
    }

    /// <summary>
    /// Converts a two-digit year string to a four-digit year string. Years 0-79 map to 2000-2079, 80-99 map to 1980-1999.
    /// </summary>
    /// <param name="yearText">The two-digit year string</param>
    /// <returns>Four-digit year string</returns>
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

    /// <summary>
    /// Converts a byte value to a four-digit year by prepending "2" (e.g. 24 becomes 2024).
    /// </summary>
    /// <param name="yearByte">The year as a byte value</param>
    /// <returns>Four-digit year as integer</returns>
    public static int FullYear(byte yearByte)
    {
        var yearString = yearByte.ToString().PadLeft(3, '0');
        return int.Parse("2" + yearString);
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

    /// <summary>
    /// Calculates the total number of seconds in the month of the specified DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime whose month to calculate seconds for</param>
    /// <returns>Total seconds in the month</returns>
    public static long SecondsInMonth(DateTime dateTime)
    {
        return DTConstants.SecondsInDay * DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
    }

    /// <summary>
    /// Calculates the total number of seconds in the specified year, accounting for leap years.
    /// </summary>
    /// <param name="year">The year to calculate seconds for</param>
    /// <returns>Total seconds in the year</returns>
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
    /// Returns today's date as a DateTimeOrShort using the compact short representation.
    /// </summary>
    /// <returns>Today's date as DateTimeOrShort</returns>
    public static DateTimeOrShort ShortToday()
    {
        return DateTimeOrShort.FromShort(NormalizeDate.To(DateTime.Today));
    }

    /// <summary>
    /// Returns a new DateTime with only the date component, zeroing the time part.
    /// </summary>
    /// <param name="dateTime">The DateTime to strip time from</param>
    /// <returns>DateTime with time set to 00:00:00</returns>
    public static DateTime WithoutTime(DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
    }

    /// <summary>
    /// Returns a new DateTime with only the time component, setting the date to year 1, January 1.
    /// </summary>
    /// <param name="dateTime">The DateTime to strip date from</param>
    /// <returns>DateTime with date set to 0001-01-01</returns>
    public static DateTime WithoutDate(DateTime dateTime)
    {
        return new DateTime(1, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second);
    }
}