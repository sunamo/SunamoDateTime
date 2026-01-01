namespace SunamoDateTime;

public class NormalizeDate
{
    public static DateTime From(short shortDate)
    {
        var text = shortDate.ToString();
        text = text.Trim();

        if (text.StartsWith("-")) text = text.TrimStart('-');

        var yearValue = text.Substring(0, 2);
        var monthValue = text.Substring(2, 1);
        var dayValue = text.Substring(3, 2);

        var firstDigit = int.Parse(dayValue[0].ToString());
        if (firstDigit > 3)
        {
            monthValue = "1" + monthValue;
            var firstChar = (firstDigit - 4).ToString()[0];
            var secondChar = dayValue[1].ToString();
            dayValue = firstChar + secondChar;
        }
        else if (monthValue == "0")
        {
            monthValue = "10";
        }

        var longYear = DTHelperGeneral.LongYear(yearValue);

        var dateTime = new DateTime(int.Parse(longYear), int.Parse(monthValue), int.Parse(dayValue));
        return dateTime;
    }

    public static short To(DateTime dateTime)
    {
        var isNegative = false;
        var addFour = false;

        var yearValue = DTHelperGeneral.ShortYear(dateTime.Year);
        // months never start with zero
        var month = dateTime.Month;
        var monthString = month.ToString();

        if (month > 10)
        {
            var monthFormatted = month.ToString("D2");

            if (monthFormatted[0] == '1')
            {
                if (monthFormatted[0] == '2') isNegative = true;
                addFour = true;
                monthString = monthFormatted[1].ToString();
            }
        }
        else if (month == 10)
        {
            monthString = "0";
        }

        /*
        In first place can be 0,1,2,3
        november = 4,5,6,7
        december = -4,5,6,7
        */
        var dayValue = dateTime.Day.ToString("D2");
        var firstChar = dayValue[0];

        var stringBuilder = new StringBuilder();
        if (isNegative) stringBuilder.Append('-');

        var firstDigit = int.Parse(firstChar.ToString());
        if (addFour) firstDigit += 4;

        stringBuilder.Append(yearValue);
        stringBuilder.Append(monthString);
        stringBuilder.Append(firstDigit);
        stringBuilder.Append(dayValue[1].ToString());

        var result = stringBuilder.ToString();
        return short.Parse(result);
    }

    public static short AddMonths(short normalizedDate, int monthsToAdd)
    {
        var dateTime = From(normalizedDate);
        dateTime = dateTime.AddMonths(monthsToAdd);
        return To(dateTime);
    }
}