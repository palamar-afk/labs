namespace Extensions
{
    public static class DoubleExtension
    {
        public static double usualReverse(this double number)
        {
            char separator = '.';
            string str = number.ToString();
            int counter = str.IndexOf(separator);
            string strReversed = string.Empty;
            for (int i = counter - 1; i >= 0; i--)
            {
                strReversed += str[i];
            }
            if (strReversed == "") return number;
            strReversed += separator;
            for (int i = str.Length - 1; i > counter; i--)
            {
                strReversed += str[i];
            }
            return double.Parse(strReversed);
        }
        public static double RecursiveReverse(this double number, char separator = '.')
        {

            string reversedNumber = number.ToString().RecursiveReverse(separator);
            return double.Parse(reversedNumber);
        }
    }
}