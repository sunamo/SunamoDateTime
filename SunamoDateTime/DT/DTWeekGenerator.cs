namespace SunamoDateTime.DT;

/// <summary>
/// Provides methods for generating days grouped by weeks for calendar/reporting purposes.
/// </summary>
public class DTWeekGenerator
{
    /// <summary>
    /// Generates week ranges for a month in format "weekNumber startDate-endDate" (e.g., "2 5.1.-11.1.").
    /// </summary>
    /// <param name="year">The year to generate week ranges for.</param>
    /// <param name="month">The month to generate week ranges for (1-12).</param>
    /// <returns>Formatted string with week numbers and date ranges, one per line.</returns>
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
}
