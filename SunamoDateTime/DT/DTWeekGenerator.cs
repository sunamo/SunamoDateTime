namespace SunamoDateTime.DT;

/// <summary>
/// Represents the DT week generator type.
/// </summary>
public class DTWeekGenerator
{
    /// <summary>
    /// Generate week ranges for month.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <returns>The generate week ranges for month result.</returns>
    public static string GenerateWeekRangesForMonth(int year, int month)
    {
        StringBuilder sb = new StringBuilder();
        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        DateTime lastDayOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        DateTime currentDate = firstDayOfMonth;

        while (currentDate <= lastDayOfMonth)
        {
            DateTime weekStart = currentDate;
            while (weekStart.DayOfWeek != DayOfWeek.Monday)
            {
                weekStart = weekStart.AddDays(-1);
            }

            DateTime weekEnd = weekStart.AddDays(6);

            if (weekStart < firstDayOfMonth)
            {
                currentDate = weekEnd.AddDays(1);
                continue;
            }

            int weekNumber = DTHelperGeneral.WeekOfYearFromDate(weekStart);

            sb.AppendLine($"{weekNumber} {weekStart.Day}.{weekStart.Month}.-{weekEnd.Day}.{weekEnd.Month}.");

            currentDate = weekEnd.AddDays(1);
        }

        return sb.ToString();
    }

    // Formats a single week range in format "weekNumber startDay.startMonth.-endDay.endMonth."
    // Example: FormatWeekRange(Monday 5.1.2026, 1) returns "1 5.1.-11.1."
    /// <summary>
    /// Format week range.
    /// </summary>
    /// <param name="monday">The monday.</param>
    /// <param name="weekNumber">The week number.</param>
    /// <returns>The format week range result.</returns>
    public static string FormatWeekRange(DateTime monday, int weekNumber)
    {
        DateTime sunday = monday.AddDays(6);
        return $"{weekNumber} {monday.Day}.{monday.Month}.-{sunday.Day}.{sunday.Month}.";
    }
}
