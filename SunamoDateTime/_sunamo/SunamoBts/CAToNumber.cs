// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoDateTime._sunamo.SunamoBts;

internal class CAToNumber
{
    internal static List<int> ToInt2(IList altitudes, int requiredLength, int startFrom)
    {
        return ToNumber<int>(BTS.TryParseInt, altitudes, requiredLength, startFrom);
    }

    #region ToInt1
    internal static List<int> ToInt1(IList enumerable, int requiredLength)
    {
        return ToNumber<int>(BTS.TryParseInt, enumerable, requiredLength);
    }
    internal static List<T> ToNumber<T>(Func<string, T, T> tryParse, IList enumerable, int requiredLength)
    {
        int enumerableCount = enumerable.Count;
        if (enumerableCount != requiredLength)
        {
            return null;
        }

        List<T> result = new List<T>();
        T y = default(T);
        foreach (var item in enumerable)
        {
            var yy = tryParse.Invoke(item.ToString(), y);
            if (!EqualityComparer<T>.Default.Equals(yy, y))
            {
                result.Add(yy);
            }
            else
            {
                return null;
            }
        }
        return result;
    }
    #endregion

    internal static List<T> ToNumber<T>(Func<string, T, T> tryParse, IList altitudes, int requiredLength, T startFrom) where T : IComparable
    {
        int finalLength = altitudes.Count - int.Parse(startFrom.ToString());
        if (finalLength < requiredLength)
        {
            return null;
        }
        List<T> vr = new List<T>(finalLength);

        T i = default(T);
        foreach (var item in altitudes)
        {
            if (i.CompareTo(startFrom) != 0)
            {
                continue;
            }

            T y = default(T);
            var yy = tryParse.Invoke(item.ToString(), y);
            if (!EqualityComparer<T>.Default.Equals(yy, y))
            {
                vr.Add(yy);
            }
            else
            {
                return null;
            }
        }

        return vr;
    }

    #region ToInt0
    internal static List<int> ToInt0(List<string> ts)
    {
        //var ts = CA.ToListStringIEnumerable2(enumerable);

        for (int i = 0; i < ts.Count; i++)
        {
            ts[i] = ts[i].Replace(',', '.');
            ts[i] = ts[i].Substring(0, ts[i].IndexOf('.') + 1);
        }

        //CAChangeContent.ChangeContent0(null, ts, d => d.Replace(',', '.'));
        //CAChangeContent.ChangeContent0(null, ts, d => d.Substring(0, d.IndexOf('.') + 1));

        return ToNumber<int, string>(int.Parse, ts);
    }

    internal static List<T> ToNumber<T, U>(Func<string, T> parse, IList<U> enumerable)
    {
        List<T> result = new List<T>();
        foreach (var item in enumerable)
        {
            if (item.ToString() == "NA")
            {
                continue;
            }

            if (double.TryParse(item.ToString(), out var _) /*SH.IsNumber(item.ToString(), new Char[] { ',', '.', '-' })*/)
            {
                var number = parse.Invoke(item.ToString());

                result.Add(number);
            }
        }
        return result;
    }
    #endregion
}
