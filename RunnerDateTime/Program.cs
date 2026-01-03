// variables names: ok
using SunamoDateTime.Tests.DT;

namespace RunnerDateTime;

internal class Program
{
    static void Main()
    {
        //DTHelperGeneralTests t = new DTHelperGeneralTests();
        //t.WeekOfYearFromDateTest();

        DTHelperCsTests t = new();
        t.CalculateAgeAndAddRightStringTest();
        t.ToTimeAgoTest();

        //Console.WriteLine("Finished");
        Console.ReadLine();
    }
}
