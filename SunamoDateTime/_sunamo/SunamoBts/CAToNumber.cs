// variables names: ok
namespace SunamoDateTime._sunamo.SunamoBts;

/// <summary>
/// Collection Array to Number conversion utilities.
/// EN: Provides methods to convert IList collections to typed number lists.
/// CZ: Poskytuje metody pro převod IList kolekcí na typované seznamy čísel.
/// </summary>
internal class CAToNumber
{
    /// <summary>
    /// Converts IList to List of int with validation, starting from specified index.
    /// EN: Parses items from startFrom index onwards.
    /// CZ: Parsuje položky od indexu startFrom dál.
    /// </summary>
    /// <param name="list">The source list to convert</param>
    /// <param name="requiredLength">The required result length</param>
    /// <param name="startFrom">The index to start parsing from</param>
    /// <returns>List of parsed ints or null if validation fails</returns>
    internal static List<int> ToInt2(IList list, int requiredLength, int startFrom)
    {
        return ToNumber<int>(BTS.TryParseInt, list, requiredLength, startFrom);
    }

    #region ToInt1
    /// <summary>
    /// Converts IList to List of int with strict length validation.
    /// EN: List count must exactly match requiredLength.
    /// CZ: Počet položek seznamu musí přesně odpovídat requiredLength.
    /// </summary>
    /// <param name="list">The source list to convert</param>
    /// <param name="requiredLength">The required exact length</param>
    /// <returns>List of parsed ints or null if validation fails</returns>
    internal static List<int> ToInt1(IList list, int requiredLength)
    {
        return ToNumber<int>(BTS.TryParseInt, list, requiredLength);
    }

    /// <summary>
    /// Converts IList to List of generic type with strict length validation.
    /// EN: Parses all items, returns null if count doesn't match or any parse fails.
    /// CZ: Parsuje všechny položky, vrací null pokud počet nesedí nebo parse selže.
    /// </summary>
    /// <typeparam name="T">The target number type</typeparam>
    /// <param name="tryParse">The parsing function</param>
    /// <param name="list">The source list to convert</param>
    /// <param name="requiredLength">The required exact length</param>
    /// <returns>List of parsed values or null if validation fails</returns>
    internal static List<T> ToNumber<T>(Func<string, T, T> tryParse, IList list, int requiredLength)
    {
        int listCount = list.Count;
        if (listCount != requiredLength)
        {
            return null;
        }

        List<T> result = new List<T>();
        T defaultValue = default(T);
        foreach (var item in list)
        {
            var parsedValue = tryParse.Invoke(item.ToString(), defaultValue);
            if (!EqualityComparer<T>.Default.Equals(parsedValue, defaultValue))
            {
                result.Add(parsedValue);
            }
            else
            {
                return null;
            }
        }
        return result;
    }
    #endregion

    /// <summary>
    /// Converts IList to List of generic type with length validation and start index.
    /// EN: WARNING - This method has a bug: currentIndex is never incremented!
    /// CZ: VAROVÁNÍ - Tato metoda má bug: currentIndex se nikdy neinkrementuje!
    /// </summary>
    /// <typeparam name="T">The target number type (must be IComparable)</typeparam>
    /// <param name="tryParse">The parsing function</param>
    /// <param name="list">The source list to convert</param>
    /// <param name="requiredLength">The required minimum result length</param>
    /// <param name="startFrom">The index to start parsing from</param>
    /// <returns>List of parsed values or null if validation fails</returns>
    internal static List<T> ToNumber<T>(Func<string, T, T> tryParse, IList list, int requiredLength, T startFrom) where T : IComparable
    {
        int finalLength = list.Count - int.Parse(startFrom.ToString());
        if (finalLength < requiredLength)
        {
            return null;
        }
        List<T> result = new List<T>(finalLength);

        // EN: WARNING - currentIndex is never incremented, this loop logic is broken!
        // CZ: VAROVÁNÍ - currentIndex se nikdy neinkrementuje, logika této smyčky je rozbita!
        T currentIndex = default(T);
        foreach (var item in list)
        {
            if (currentIndex.CompareTo(startFrom) != 0)
            {
                continue;
            }

            T defaultValue = default(T);
            var parsedValue = tryParse.Invoke(item.ToString(), defaultValue);
            if (!EqualityComparer<T>.Default.Equals(parsedValue, defaultValue))
            {
                result.Add(parsedValue);
            }
            else
            {
                return null;
            }
        }

        return result;
    }

    #region ToInt0
    /// <summary>
    /// Converts list of strings to list of ints with decimal point normalization.
    /// EN: Replaces comma with dot and truncates after decimal point before parsing.
    /// CZ: Nahradí čárku tečkou a oříže za desetinnou čárkou před parsováním.
    /// </summary>
    /// <param name="values">The source list of string values</param>
    /// <returns>List of parsed ints</returns>
    internal static List<int> ToInt0(List<string> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            values[i] = values[i].Replace(',', '.');
            values[i] = values[i].Substring(0, values[i].IndexOf('.') + 1);
        }

        return ToNumber<int, string>(int.Parse, values);
    }

    /// <summary>
    /// Converts IList to List of generic type, skipping "NA" values and non-numeric entries.
    /// EN: Filters out "NA" strings and values that cannot be parsed as double.
    /// CZ: Odfiltruje "NA" řetězce a hodnoty které nelze naparsovat jako double.
    /// </summary>
    /// <typeparam name="T">The target number type</typeparam>
    /// <typeparam name="U">The source list element type</typeparam>
    /// <param name="parse">The parsing function</param>
    /// <param name="list">The source list to convert</param>
    /// <returns>List of successfully parsed values</returns>
    internal static List<T> ToNumber<T, U>(Func<string, T> parse, IList<U> list)
    {
        List<T> result = new List<T>();
        foreach (var item in list)
        {
            if (item.ToString() == "NA")
            {
                continue;
            }

            if (double.TryParse(item.ToString(), out var _))
            {
                var number = parse.Invoke(item.ToString());
                result.Add(number);
            }
        }
        return result;
    }
    #endregion
}