namespace SunamoDateTime;

public class NormalizeDate
{
    public static DateTime From(short sh)
    {
        var text = sh.ToString();
        text = text.Trim();

        if (text.StartsWith("-")) text = text.TrimStart('-');

        var yValue = text.Substring(0, 2);
        var message = text.Substring(2, 1);
        var data = text.Substring(3, 2);

        var firstLetter = int.Parse(data[0].ToString());
        if (firstLetter > 3)
        {
            message = "1" + message;
            var f = (firstLetter - 4).ToString()[0];
            var s2 = data[1].ToString();
            data = f + s2;
        }
        else if (message == "0")
        {
            message = "10";
        }

        var longYear = DTHelperGeneral.LongYear(yValue);

        var dt = new DateTime(int.Parse(longYear), int.Parse(message), int.Parse(data));
        return dt;
    }

    public static short To(DateTime dt)
    {
        var timesMinus1 = false;
        var addFour = false;

        var yValue = DTHelperGeneral.ShortYear(dt.Year);
        // months never start with zero
        var message = dt.Month;
        var ms2 = message.ToString();

        if (message > 10)
        {
            var ms = message.ToString("D2");

            if (ms[0] == '1')
            {
                if (ms[0] == '2') timesMinus1 = true;
                addFour = true;
                ms2 = ms[1].ToString();
            }
        }
        else if (message == 10)
        {
            ms2 = "0";
        }

        /*
        In first place can be 0,1,2,3
        november = 4,5,6,7
        december = -4,5,6,7
        */
        var data = dt.Day.ToString("D2");
        var firstChar = data[0];

        var stringBuilder = new StringBuilder();
        if (timesMinus1) stringBuilder.Append('-');

        var firstChar2 = int.Parse(firstChar.ToString());
        if (addFour) firstChar2 += 4;

        stringBuilder.Append(yValue);
        stringBuilder.Append(ms2);
        stringBuilder.Append(firstChar2);
        stringBuilder.Append(data[1].ToString());

        var result = stringBuilder.ToString();
        return short.Parse(result);
    }

    public static short AddMonths(short ntda, int v)
    {
        var dt = From(ntda);
        dt = dt.AddMonths(v);
        return To(dt);
    }
}