using System;
using System.Collections.Generic;
using System.Linq;
namespace mainCSharp
{
    class Program
    {
        public static List<int> numbers = new List<int>();

        public static void findDistinctElements(List<int> list)
        {
            int[] arr = new int[10];
            foreach (int value in numbers.Distinct())
            {
                arr[value] = numbers.Where(x => x == value).Count();
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("["+i+"]" + "th = " + arr[i]);
            }
        }
        public static void enterNumbers()
        {
            Console.WriteLine("Enter numbers in list(between 0 and 9) letter or higher or lower number(except first number) for stopping:\n");
            int currentNumber = 0;
            int i = 0;
            while (true)
            {
                if (i == 0)
                {
                    Console.WriteLine(i + 1 + "th: ");
                    if (int.TryParse(Console.ReadLine(), out currentNumber) && currentNumber > 0 && currentNumber < 10)
                        numbers.Add(currentNumber);
                    else
                    {
                        Console.WriteLine("Incorrect!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(i + 1 + "th: ");
                    if (int.TryParse(Console.ReadLine(), out currentNumber) && currentNumber > 0 && currentNumber < 10)
                        numbers.Add(currentNumber);
                    else
                        break;
                }
                i++;
            }
        }
        public static void Main()
        {
            enterNumbers();
            findDistinctElements(numbers);
        }
    };
}