using SunamoDateTime.DT;
using SunamoDateTime.Tests.DT;

namespace RunnerDateTime;

internal class Program
{
    static void Main()
    {


        var r = DTWeekGenerator.GenerateWeekRangesForMonth(2026, 1);
        var r2 = DTWeekGenerator.GenerateWeekRangesForMonth(2026, 2);







        DTHelperCsTests t = new();
        t.CalculateAgeAndAddRightStringTest();
        t.ToTimeAgoTest();

        Console.ReadLine();
    }
}
