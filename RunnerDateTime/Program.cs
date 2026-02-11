// variables names: ok
using SunamoDateTime.DT;
using SunamoDateTime.Tests.DT;

namespace RunnerDateTime;

internal class Program
{
    static void Main()
    {
        //DTHelperGeneralTests t = new DTHelperGeneralTests();
        //t.WeekOfYearFromDateTest();

        //DTWeekGeneratorTests weekTests = new();

        //DTWeekGenerator t = new DTWeekGenerator();
        var r = DTWeekGenerator.GenerateWeekRangesForMonth(2026, 1);
        var r2 = DTWeekGenerator.GenerateWeekRangesForMonth(2026, 2);

        int i = 0;

        // 

        //weekTests.GenerateDaysGroupedByWeeks_January2026_FirstWeek();
        //weekTests.GenerateDaysGroupedByWeeks_January2026_SecondWeek();
        //weekTests.GenerateDaysGroupedByWeeks_December2025_SecondToLastWeek();
        //weekTests.GenerateDaysGroupedByWeeks_December2025_LastWeek();




        //weekTests.GenerateDaysGroupedByWeeks_January2025_FirstWeek();
        //weekTests.GenerateDaysGroupedByWeeks_January2027_FirstWeek();
        //weekTests.GenerateDaysGroupedByWeeks_January2023_FirstWeek();

        //weekTests.GenerateDaysGroupedByWeeks_December2027_LastWeek();
        //weekTests.GenerateDaysGroupedByWeeks_December2028_LastWeek();
        //weekTests.GenerateDaysGroupedByWeeks_January_AllDaysIncluded();
        //weekTests.GenerateDaysGroupedByWeeks_December_AllDaysIncluded();

        DTHelperCsTests t = new();
        t.CalculateAgeAndAddRightStringTest();
        t.ToTimeAgoTest();

        //Console.WriteLine("Finished");
        Console.ReadLine();
    }
}
