namespace SunamoDateTime;

public class NormalizeDate
{
    public static DateTime From(short sh)
    {
        var s = sh.ToString();
        s = s.Trim();

        if (s.StartsWith("-")) s = s.TrimStart('-');

        var y = s.Substring(0, 2);
        var m = s.Substring(2, 1);
        var d = s.Substring(3, 2);

        var firstLetter = int.Parse(d[0].ToString());
        if (firstLetter > 3)
        {
            m = "1" + m;
            var f = (firstLetter - 4).ToString()[0];
            var s2 = d[1].ToString();
            d = f + s2;
        }
        else if (m == "0")
        {
            m = "10";
        }

        var longYear = DTHelperGeneral.LongYear(y);

        var dt = new DateTime(int.Parse(longYear), int.Parse(m), int.Parse(d));
        return dt;
    }

    public static short To(DateTime dt)
    {
        var timesMinus1 = false;
        var addFour = false;

        var y = DTHelperGeneral.ShortYear(dt.Year);
        // months never start with zero
        var m = dt.Month;
        var ms2 = m.ToString();

        if (m > 10)
        {
            var ms = m.ToString("D2");

            if (ms[0] == '1')
            {
                if (ms[0] == '2') timesMinus1 = true;
                addFour = true;
                ms2 = ms[1].ToString();
            }
        }
        else if (m == 10)
        {
            ms2 = "0";
        }

        /*
        In first place can be 0,1,2,3
        november = 4,5,6,7
        december = -4,5,6,7
        */
        var d = dt.Day.ToString("D2");
        var firstChar = d[0];

        var sb = new StringBuilder();
        if (timesMinus1) sb.Append('-');

        var firstChar2 = int.Parse(firstChar.ToString());
        if (addFour) firstChar2 += 4;

        sb.Append(y);
        sb.Append(ms2);
        sb.Append(firstChar2);
        sb.Append(d[1].ToString());

        var result = sb.ToString();
        return short.Parse(result);
    }

    public static short AddMonths(short ntda, int v)
    {
        var dt = From(ntda);
        dt = dt.AddMonths(v);
        return To(dt);
    }
}