namespace SunamoDateTime._sunamo.SunamoValues.Constants;

/// <summary>
/// DateTime constants for time calculations and localization.
/// EN: Contains time conversion constants and localized day/month names.
/// CZ: Obsahuje konstanty pro převod času a lokalizované názvy dnů/měsíců.
/// </summary>
internal class DTConstants
{
    /// <summary>Number of seconds in one minute (60)</summary>
    internal const long SecondsInMinute = 60;

    /// <summary>Number of seconds in one hour (3600)</summary>
    internal const long SecondsInHour = SecondsInMinute * 60;

    /// <summary>Number of seconds in one day (86400)</summary>
    internal const long SecondsInDay = SecondsInHour * 24;

    /// <summary>Abbreviated English day names (Mon, Tue, Wed, etc.)</summary>
    internal static readonly List<string> DaysInWeekENShortcut = new List<string>(["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"]);

    /// <summary>Full English day names (Monday, Tuesday, Wednesday, etc.)</summary>
    internal static readonly List<string> DaysInWeekEN = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    /// <summary>Full English month names (January, February, March, etc.)</summary>
    internal static readonly List<string> MonthsInYearEN = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    /// <summary>Unix epoch start year (1970)</summary>
    internal const int YearStartUnixDate = 1970;

    /// <summary>Unix epoch start datetime (1970-01-01)</summary>
    internal static readonly DateTime UnixFsStart = new DateTime(YearStartUnixDate, 1, 1);

    /// <summary>Full Czech day names (Pondělí, Úterý, Středa, etc.)</summary>
    internal static readonly List<string> DaysInWeekCS = new List<string> { Pondeli, Utery, Streda, Ctvrtek, Patek, Sobota, Nedele };

    /// <summary>Unix time epoch start (1970-01-01 00:00:00 UTC)</summary>
    internal static DateTime UnixTimeStartEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>Windows time epoch start (1601-01-01 01:00:00 UTC)</summary>
    internal static DateTime WinTimeStartEpoch = new DateTime(1601, 1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    #region Czech Day Names
    /// <summary>Monday in Czech</summary>
    internal const string Pondeli = "Pond\u011Bl\u00ED";

    /// <summary>Tuesday in Czech</summary>
    internal const string Utery = "\u00DAter\u00FD";

    /// <summary>Wednesday in Czech</summary>
    internal const string Streda = "St\u0159eda";

    /// <summary>Thursday in Czech</summary>
    internal const string Ctvrtek = "\u010Ctvrtek";

    /// <summary>Friday in Czech</summary>
    internal const string Patek = "P\u00E1tek";

    /// <summary>Saturday in Czech</summary>
    internal const string Sobota = "Sobota";

    /// <summary>Sunday in Czech</summary>
    internal const string Nedele = "Ned\u011Ble";
    #endregion

    #region Czech Month Names
    /// <summary>January in Czech</summary>
    internal const string Leden = "Leden";

    /// <summary>February in Czech</summary>
    internal const string Unor = "\u00DAnor";

    /// <summary>March in Czech</summary>
    internal const string Brezen = "B\u0159ezen";

    /// <summary>April in Czech</summary>
    internal const string Duben = "Duben";

    /// <summary>May in Czech</summary>
    internal const string Kveten = "Kv\u011Bten";

    /// <summary>June in Czech</summary>
    internal const string Cerven = "\u010Cerven";

    /// <summary>July in Czech</summary>
    internal const string Cervenec = "\u010Cervenec";

    /// <summary>August in Czech</summary>
    internal const string Srpen = "Srpen";

    /// <summary>September in Czech</summary>
    internal const string Zari = "Z\u00E1\u0159\u00ED";

    /// <summary>October in Czech</summary>
    internal const string Rijen = "\u0158\u00EDjen";

    /// <summary>November in Czech</summary>
    internal const string Listopad = "Listopad";

    /// <summary>December in Czech</summary>
    internal const string Prosinec = "Prosinec";
    #endregion

    /// <summary>Full Czech month names (Leden, Únor, Březen, etc.)</summary>
    internal static readonly List<string> MonthsInYearCZ = new List<string> { Leden, Unor, Brezen, Duben, Kveten, Cerven, Cervenec, Srpen, Zari, Rijen, Listopad, Prosinec };
}