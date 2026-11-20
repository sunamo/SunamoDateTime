namespace SunamoDateTime._sunamo.SunamoValues.Constants;

internal class DTConstants
{
    internal const long SecondsInMinute = 60;

    internal const long SecondsInHour = SecondsInMinute * 60;

    internal const long SecondsInDay = SecondsInHour * 24;

    internal static readonly List<string> DaysInWeekENShortcut = new List<string>(["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"]);

    internal static readonly List<string> DaysInWeekEN = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    internal static readonly List<string> MonthsInYearEN = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    internal const int YearStartUnixDate = 1970;

    internal static readonly DateTime UnixFsStart = new DateTime(YearStartUnixDate, 1, 1);

    internal static readonly List<string> DaysInWeekCS = new List<string> { MondayCs, TuesdayCs, WednesdayCs, ThursdayCs, FridayCs, SaturdayCs, SundayCs };

    internal static DateTime UnixTimeStartEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    internal static DateTime WinTimeStartEpoch = new DateTime(1601, 1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    #region Czech Day Names
    /// <summary>Monday in Czech</summary>
    internal const string MondayCs = "Pondělí";

    /// <summary>Tuesday in Czech</summary>
    internal const string TuesdayCs = "Úterý";

    /// <summary>Wednesday in Czech</summary>
    internal const string WednesdayCs = "Středa";

    /// <summary>Thursday in Czech</summary>
    internal const string ThursdayCs = "Čtvrtek";

    /// <summary>Friday in Czech</summary>
    internal const string FridayCs = "Pátek";

    internal const string SaturdayCs = "Sobota";

    /// <summary>Sunday in Czech</summary>
    internal const string SundayCs = "Neděle";
    #endregion

    #region Czech Month Names
    internal const string JanuaryCs = "Leden";

    /// <summary>February in Czech</summary>
    internal const string FebruaryCs = "Únor";

    /// <summary>March in Czech</summary>
    internal const string MarchCs = "Březen";

    internal const string AprilCs = "Duben";

    /// <summary>May in Czech</summary>
    internal const string MayCs = "Květen";

    /// <summary>June in Czech</summary>
    internal const string JuneCs = "Červen";

    /// <summary>July in Czech</summary>
    internal const string JulyCs = "Červenec";

    internal const string AugustCs = "Srpen";

    /// <summary>September in Czech</summary>
    internal const string SeptemberCs = "Září";

    /// <summary>October in Czech</summary>
    internal const string OctoberCs = "Říjen";

    internal const string NovemberCs = "Listopad";

    internal const string DecemberCs = "Prosinec";
    #endregion

    internal static readonly List<string> MonthsInYearCZ = new List<string> { JanuaryCs, FebruaryCs, MarchCs, AprilCs, MayCs, JuneCs, JulyCs, AugustCs, SeptemberCs, OctoberCs, NovemberCs, DecemberCs };
}
