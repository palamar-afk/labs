namespace Extensions
{
    public static class IntExtension
    {
        // 1.1(обычная реализация)
        public static int usualReverse(this int number)
        {
            if (number == 0)
            {
                return number;
            }
            int remainder = 0;
            int reversedNumber = 0;
            do
            {
                remainder = number % 10;
                reversedNumber = reversedNumber * 10 + remainder;
                number /= 10;
            } while (number % 10 != 0);
            return reversedNumber;
        }
        // 1.2 + рекурсія + перевантаження
        public static int RecursiveReverse(this int number, int reversedNumber = 0)
        {
            if (number == 0)
            {
                return reversedNumber;
            }
            reversedNumber = (reversedNumber * 10) + (number % 10);
            return RecursiveReverse(number / 10, reversedNumber);
        }
    }
}