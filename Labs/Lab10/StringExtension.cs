namespace Extensions
{
    public static class StringExtension
    {
        //методы расширения для строк без разделителя(условно)
        public static string usualReverse(this string str)
        {
            string reversedStr = string.Empty;
            for (int i = str.Length; i > 0; i--)
            {
                reversedStr += str[i - 1];
            }
            return reversedStr;
        }
        public static string RecursiveReverse(this string str, string reversedStr = "", int counter = 1)
        {
            if (str.Length == counter - 1) return reversedStr;
            reversedStr += str[str.Length - counter];
            return RecursiveReverse(str, reversedStr, ++counter);
        }

        //методы расширения для строк с разделителем(условно)
        public static string usualReverse(this string str, string separator)
        {
            string reversedStr = string.Empty;
            var str_arr = str.Split(separator);

            reversedStr += usualReverse(str_arr[0]) + separator + usualReverse(str_arr[1]);
            return reversedStr;
        }
        //4.2 + рекурсія + перевантаження
        public static string RecursiveReverse(this string str, char separator)
        {
            string reversedStr = string.Empty;
            var str_arr = str.Split(separator);
            reversedStr += RecursiveReverse(str_arr[0]) + separator + RecursiveReverse(str_arr[1]);
            return reversedStr;
        }
    }
}