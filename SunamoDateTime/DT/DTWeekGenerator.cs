namespace SunamoDateTime.DT;

public class DTWeekGenerator
{
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

    // EN: Formats a single week range in format "weekNumber startDay.startMonth.-endDay.endMonth."
    // CZ: Formátuje jeden týdenní rozsah ve formátu "weekNumber startDay.startMonth.-endDay.endMonth."
    // Example: FormatWeekRange(Monday 5.1.2026, 1) returns "1 5.1.-11.1."
    public static string FormatWeekRange(DateTime monday, int weekNumber)
    {
        DateTime sunday = monday.AddDays(6);
        return $"{weekNumber} {monday.Day}.{monday.Month}.-{sunday.Day}.{sunday.Month}.";
    }
}
