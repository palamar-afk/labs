using System;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number(reverse): ");
            Console.WriteLine(usualReverse(int.Parse(Console.ReadLine())));

            Console.Write("Enter integer number(recursive reverse): ");
            Console.WriteLine(RecursiveReverse(int.Parse(Console.ReadLine())));

            Console.Write("Enter string(reverse): ");
            Console.WriteLine(usualReverse(Console.ReadLine()));

            Console.Write("Enter string(recursive reverse): ");
            Console.WriteLine(RecursiveReverse(Console.ReadLine()));

            Console.Write("Enter double(reverse, separator (',')): ");
            Console.WriteLine(usualReverse(double.Parse(Console.ReadLine())));

            Console.Write("Enter double(recursive reverse, separator (',')): ");
            Console.WriteLine(RecursiveReverse(double.Parse(Console.ReadLine())));

            string separator = "";
            Console.WriteLine("Enter magic separator: ");
            separator = Console.ReadLine();

            Console.Write($"Enter 1st part of string(reverse, separator ({separator})): ");
            string str_1 = Console.ReadLine();
            Console.Write($"Enter 2nd part of string(reverse, separator ({separator})): ");
            Console.WriteLine(usualReverse(str_1 + separator + Console.ReadLine(), separator));

            Console.WriteLine("Enter magic separator: ");
            separator = Console.ReadLine();

            Console.Write($"Enter 1st part of string(recursive reverse, separator ({separator})): ");
            str_1 = Console.ReadLine();
            Console.Write($"Enter 2nd part of string(recursive reverse, separator ({separator})): ");
            Console.WriteLine(RecursiveReverse(str_1 + separator + Console.ReadLine(), separator));

            Console.WriteLine("Enter count of elements for array: ");
            int count = int.Parse(Console.ReadLine());
            int[] arr = new int[count];

            RandomArray(ref arr, count);

            Console.WriteLine("Array: \n");
            ShowArray(ref arr);

            Console.WriteLine("Reverse Array: \n");
            ReverseArray(ref arr);

            ShowArray(ref arr);
            ReverseArray(ref arr);

            Console.WriteLine("Reverse ArrayOut: \n");
            int[] newArr;
            ReverseArrayOut(arr, out newArr);
            ShowArray(ref newArr);
        }
        // 1.1(обычная реализация)
        static int usualReverse(int number)
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
        static int RecursiveReverse(int number, int reversedNumber = 0)
        {
            if (number == 0)
            {
                return reversedNumber;
            }

            reversedNumber = (reversedNumber * 10) + (number % 10);
            return RecursiveReverse(number / 10, reversedNumber);
        }
        // 2.1
        static string usualReverse(string str)
        {
            string reversedStr = string.Empty;
            for (int i = str.Length; i > 0; i--)
            {
                reversedStr += str[i - 1];
            }
            return reversedStr;
        }
        // 2.2  + рекурсія + перевантаження
        static string RecursiveReverse(string str, string reversedStr = "", int counter = 1)
        {
            if (str.Length == counter - 1) return reversedStr;
            reversedStr += str[str.Length - counter];
            return RecursiveReverse(str, reversedStr, ++counter);
        }
        // 3.1
        static double usualReverse(double number)
        {
            char separator = ',';
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
        //3.2 + рекурсія + перевантаження
        static double RecursiveReverse(double number, char separator = ',')
        {
            string strNumber = number.ToString();
            string reversedNumber = string.Empty;
            var str_arr = strNumber.Split(separator);

            reversedNumber += RecursiveReverse(str_arr[0]);
            if (str_arr.Length > 1)
            {
                reversedNumber += separator;
                reversedNumber += RecursiveReverse(str_arr[1]);
            }
            return double.Parse(reversedNumber);
        }
        //4.1
        static string usualReverse(string str, string separator)
        {
            string reversedStr = string.Empty;
            var str_arr = str.Split(separator);

            reversedStr += usualReverse(str_arr[0]) + '-' + separator + '-' + usualReverse(str_arr[1]);
            return reversedStr;
        }
        //4.2 + рекурсія + перевантаження
        static string RecursiveReverse(string str, string separator)
        {
            string reversedStr = string.Empty;
            var str_arr = str.Split(separator);

            reversedStr += RecursiveReverse(str_arr[0]) + '-' + separator + '-' + RecursiveReverse(str_arr[1]);
            return reversedStr;
        }

        //7 + 8
        static void ReverseArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }
        }
        static void ReverseArrayOut(int[] arr, out int[] newArr)
        {
            newArr = arr;
            for (int i = 0; i < newArr.Length / 2; i++)
            {
                int temp = newArr[i];
                newArr[i] = newArr[newArr.Length - i - 1];
                newArr[newArr.Length - i - 1] = temp;
            }
        }
        static void RandomArray(ref int[] arr, int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                arr[i] = random.Next(10, 100);
            }
        }
        static void ShowArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }
    }
}