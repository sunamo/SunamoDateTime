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

    internal static readonly List<string> DaysInWeekCS = new List<string> { Pondeli, Utery, Streda, Ctvrtek, Patek, Sobota, Nedele };

    internal static DateTime UnixTimeStartEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    internal static DateTime WinTimeStartEpoch = new DateTime(1601, 1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    #region Czech Day Names
    /// <summary>Monday in Czech</summary>
    internal const string Pondeli = "Pondělí";

    /// <summary>Tuesday in Czech</summary>
    internal const string Utery = "Úterý";

    /// <summary>Wednesday in Czech</summary>
    internal const string Streda = "Středa";

    /// <summary>Thursday in Czech</summary>
    internal const string Ctvrtek = "Čtvrtek";

    /// <summary>Friday in Czech</summary>
    internal const string Patek = "Pátek";

    internal const string Sobota = "Sobota";

    /// <summary>Sunday in Czech</summary>
    internal const string Nedele = "Neděle";
    #endregion

    #region Czech Month Names
    internal const string Leden = "Leden";

    /// <summary>February in Czech</summary>
    internal const string Unor = "Únor";

    /// <summary>March in Czech</summary>
    internal const string Brezen = "Březen";

    internal const string Duben = "Duben";

    /// <summary>May in Czech</summary>
    internal const string Kveten = "Květen";

    /// <summary>June in Czech</summary>
    internal const string Cerven = "Červen";

    /// <summary>July in Czech</summary>
    internal const string Cervenec = "Červenec";

    internal const string Srpen = "Srpen";

    /// <summary>September in Czech</summary>
    internal const string Zari = "Září";

    /// <summary>October in Czech</summary>
    internal const string Rijen = "Říjen";

    internal const string Listopad = "Listopad";

    internal const string Prosinec = "Prosinec";
    #endregion

    internal static readonly List<string> MonthsInYearCZ = new List<string> { Leden, Unor, Brezen, Duben, Kveten, Cerven, Cervenec, Srpen, Zari, Rijen, Listopad, Prosinec };
}
