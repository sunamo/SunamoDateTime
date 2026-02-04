namespace SunamoDateTime.DT;

/// <summary>
/// Underscore
/// </summary>
public class DTHelperUs
{
    #region ToString
    /// <summary>
    /// yyyy_mm_dd
    /// </summary>
    /// <param name="dt"></param>
    public static string DateTimeToFileName(DateTime dt)
    {
        return DateTimeToFileName(dt, true);
    }

    /// <summary>
    /// yyyy_mm_dd
    /// With A2 append hh_mm
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="time"></param>
    public static string DateTimeToFileName(DateTime dt, bool time)
    {
        string dDate = "_";
        string dSpace = "_";
        string dTime = "_";
        string result = dt.Year + dDate + dt.Month.ToString("D2") + dDate + dt.Day.ToString("D2");
        if (time)
        {
            result += dSpace + dt.Hour.ToString("D2") + dTime + dt.Minute.ToString("D2");
        }
        return result;
    }
    #endregion

    #region Parse - FileNameToDateTime
    /// <summary>
    /// 1989_06_21_11_22 or 1989_06_21 if !A2
    /// Return null if A1 wont have right format
    /// </summary>
    /// <param name="filenameWithoutExtension"></param>
    public static DateTime? FileNameToDateTimePrefix(string filenameWithoutExtension, bool time, out string prefix)
    {
        List<string> parts = SHSplit.SplitToPartsFromEnd(filenameWithoutExtension, time ? 6 : 4, new Char[] { "_"[0] });
        if (time)
        {
            prefix = parts[0];
            var dd = CAToNumber.ToInt2(parts, 5, 1);
            if (dd == null)
            {
                return null;
            }
            return new DateTime(dd[0], dd[1], dd[2], dd[3], dd[4], 0);
        }
        else
        {
            prefix = parts[0];
            var dd = CAToNumber.ToInt2(parts, 3, 1);
            if (dd == null)
            {
                return null;
            }
            return new DateTime(dd[0], dd[1], dd[2]);
        }
    }

    /// <summary>
    /// Return null if wont have right format
    /// If A2, A1 must have format ????_??_??_??_??
    /// if !A2, A1 must have format ????_??_??
    /// In any case what is after A2 is not important
    /// </summary>
    public static DateTime? FileNameToDateTimePostfix(string filenameWithoutExtension, bool time, out string postfix)
    {
        var parts = SHSplit.SplitToParts(filenameWithoutExtension, time ? 6 : 4, "_");
        if (time)
        {
            if (parts.Count > 5)
            {
                postfix = parts[5];
            }
            else
            {
                postfix = "";
                return null;
            }

            var date = CAToNumber.ToInt2(parts, 3, 0);
            if (date == null)
            {
                return null;
            }

            var time2 = CAToNumber.ToInt2(parts, 2, 3);
            if (time2 == null)
            {
                return null;
            }

            return new DateTime(date[0], date[1], date[2], time2[0], time2[1], 0);
        }
        else
        {
            if (parts.Count > 3)
            {
                postfix = parts[3];
            }
            else
            {
                postfix = "";
                return null;
            }

            var dd = CAToNumber.ToInt2(parts, 3, 0);
            if (dd == null)
            {
                return null;
            }
            return new DateTime(dd[0], dd[1], dd[2]);
        }
    }

    /// <summary>
    /// Return null if wont have right format
    /// If A2, A1 must have format ????_??_??_S_?*
    ///
    /// </summary>
    public static DateTime? FileNameToDateWithSeriePostfix(string filenameWithoutExtension, out int? serie, out string postfix)
    {
        postfix = "";
        serie = null;

        var parts = SHSplit.SplitToParts(filenameWithoutExtension, 6, "_");

        if (parts.Count > 5)
        {
            postfix = parts[5];
        }
        else
        {
            postfix = "";
            return null;
        }

        var date = CAToNumber.ToInt2(parts, 3, 0);
        if (date == null)
        {
            return null;
        }
        if (parts[3] != "S")
        {
            return null;
        }
        serie = BTS.ParseInt(parts[4], null);


        return new DateTime(date[0], date[1], date[2]);
    }

    /// <summary>
    /// 1989_06_21_11_22
    /// Return null if wont have right format
    /// </summary>
    /// <param name="filenameWithoutExtension"></param>
    public static DateTime? FileNameToDateTime(string filenameWithoutExtension)
    {
        var parts = filenameWithoutExtension.Split(new String[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList(); //SHSplit.Split(filenameWithoutExtension, "_");
        // Tady jsem to rozděloval na 6 ale pak mi to vracelo null. Úprava na 5
        var dd = CAToNumber.ToInt1(parts, 5);
        if (dd == null)
        {
            return null;
        }
        return new DateTime(dd[0], dd[1], dd[2], dd[3], dd[4], 0);
    }


    #endregion
}