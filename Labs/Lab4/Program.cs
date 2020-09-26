using System;
/* Скидан Павло ПД-21 Вариант 22 */
namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter " + (i + 1) + " element: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            bool corrupt = false;
            int sumOfSize = 0;
            int sumOfArray = 0;
            Array.Sort(arr, 0, size, null);
            for (int i = 1; i <= size; i++)
            {
                sumOfSize += i;
                sumOfArray += arr[i - 1];
                if (sumOfArray != sumOfSize)
                {
                    Console.WriteLine(i + "th element is corrupted");
                    corrupt = true;
                    break;
                }
            }
            if (!corrupt)
            {
                Console.WriteLine(0);
            }
        }
    }
}
