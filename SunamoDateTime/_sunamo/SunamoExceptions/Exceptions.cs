namespace SunamoDateTime._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.
internal sealed partial class Exceptions
{
    #region Other
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    internal static string TextOfExceptions(Exception ex, bool alsoInner = true)
    {
        if (ex == null) return string.Empty;
        StringBuilder stringBuilder = new();
        stringBuilder.Append("Exception:");
        stringBuilder.AppendLine(ex.Message);
        if (alsoInner)
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                stringBuilder.AppendLine(ex.Message);
            }
        var result = stringBuilder.ToString();
        return result;
    }

    internal static Tuple<string, string, string> PlaceOfException(
bool fillAlsoFirstTwo = true)
    {
        StackTrace st = new();
        var value = st.ToString();
        var lines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var i = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; i < lines.Count; i++)
        {
            var item = lines[i];
            if (fillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }
            if (item.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }
    /// <summary>
    /// Parses type and method name from stack trace line.
    /// EN: Extracts type name and method name from stack trace line format.
    /// CZ: Extrahuje název typu a metody z formátu řádku stack trace.
    /// </summary>
    /// <param name="stackTraceLine">Stack trace line (e.g. "at Namespace.Class.Method(params)")</param>
    /// <param name="type">Output: extracted type name</param>
    /// <param name="methodName">Output: extracted method name</param>
    internal static void TypeAndMethodName(string stackTraceLine, out string type, out string methodName)
    {
        var afterAt = stackTraceLine.Split("at ")[1].Trim();
        var text = afterAt.Split("(")[0];
        var parts = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        type = string.Join(".", parts);
    }
    /// <summary>
    /// Gets the calling method name from the stack trace.
    /// EN: Returns method name at specified stack frame depth.
    /// CZ: Vrací název metody na zadané hloubce zásobníku volání.
    /// </summary>
    /// <param name="stackFrameDepth">Stack frame depth (1 = immediate caller)</param>
    /// <returns>Method name or error message</returns>
    internal static string CallingMethod(int stackFrameDepth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(stackFrameDepth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }
    #endregion

    #region IsNullOrWhitespace
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();
    #endregion

    #region OnlyReturnString 
    internal static string? Custom(string before, string message)
    {
        return CheckBefore(before) + message;
    }
    internal static string? CannotCreateDateTime(string before, int year, int month, int day, int hour, int minute, int seconds,
Exception ex)
    {
        return CheckBefore(before) +
        $"Cannot create DateTime with: year: {year} month: {month} day: {day} hour: {hour} minute: {minute} seconds: {seconds} " +
        TextOfExceptions(ex);
    }
    internal static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }
    #endregion
    internal static string? NotInt(string before, string what, int? value)
    {
        return !value.HasValue ? CheckBefore(before) + what + " is not with value " + value + " valid integer number" : null;
    }
    internal static string? NotImplementedCase(string before, object notImplementedName)
    {
        var fr = string.Empty;
        if (notImplementedName != null)
        {
            fr = " for ";
            if (notImplementedName.GetType() == typeof(Type))
                fr += ((Type)notImplementedName).FullName;
            else
                fr += notImplementedName.ToString();
        }
        return CheckBefore(before) + "Not implemented case" + fr + " . internal program error. Please contact developer" +
        ".";
    }
}