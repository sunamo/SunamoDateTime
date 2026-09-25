namespace SunamoDateTime._sunamo.SunamoBts;

internal class CAToNumber
{
    internal static List<int>? ToInt2(IList list, int requiredLength, int startFrom)
    {
        return ToNumber<int>(BTS.TryParseInt, list, requiredLength, startFrom);
    }

    #region ToInt1
    internal static List<int>? ToInt1(IList list, int requiredLength)
    {
        return ToNumber<int>(BTS.TryParseInt, list, requiredLength);
    }

    internal static List<T>? ToNumber<T>(Func<string, T, T> tryParse, IList list, int requiredLength)
    {
        int listCount = list.Count;
        if (listCount != requiredLength)
        {
            return null;
        }

        var result = new List<T>();
        T defaultValue = default(T)!;
        foreach (var item in list)
        {
            var parsedValue = tryParse.Invoke(item!.ToString()!, defaultValue);
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

    // EN: WARNING - currentIndex is never incremented, this loop logic is broken!
    // CZ: VAROVANI - currentIndex se nikdy neinkrementuje, logika teto smycky je rozbita!
    internal static List<T>? ToNumber<T>(Func<string, T, T> tryParse, IList list, int requiredLength, T startFrom) where T : IComparable
    {
        int finalLength = list.Count - int.Parse(startFrom!.ToString()!);
        if (finalLength < requiredLength)
        {
            return null;
        }
        var result = new List<T>(finalLength);

        T currentIndex = default(T)!;
        foreach (var item in list)
        {
            if (currentIndex!.CompareTo(startFrom) != 0)
            {
                continue;
            }

            T defaultValue = default(T)!;
            var parsedValue = tryParse.Invoke(item!.ToString()!, defaultValue);
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
    internal static List<int> ToInt0(List<string> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            values[i] = values[i].Replace(',', '.');
            values[i] = values[i].Substring(0, values[i].IndexOf('.') + 1);
        }

        return ToNumber<int, string>(int.Parse, values);
    }

    internal static List<T> ToNumber<T, U>(Func<string, T> parse, IList<U> list)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            if (item!.ToString() == "NA")
            {
                continue;
            }

            if (double.TryParse(item.ToString(), out _))
            {
                var number = parse.Invoke(item.ToString()!);
                result.Add(number);
            }
        }
        return result;
    }
    #endregion
}
