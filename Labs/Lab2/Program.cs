using System;
using System.Globalization;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            int finish_index;
            int start_index;
            Console.Write("Enter start index(integer): ");
            string start_index_str = Console.ReadLine();
            start_index = Convert.ToInt32(start_index_str);
            Console.Write("Enter finish index(integer): ");
            string finish_index_str = Console.ReadLine();
            finish_index = Convert.ToInt32(finish_index_str);
            double summ = 0;
            if (start_index <= finish_index && start_index >= 0)
            {
                for (int i = start_index; i < finish_index; i++)
                {
                    summ *= (i * i + Math.Pow(-1, i - 1) * 2 * i - 1) / (i * i + 8);
                }
                Console.WriteLine("Summ of row: " + summ);
            }
            else
            {
                Console.WriteLine("Invalid indexes. Restart and try again");
            }

        }
    }
}
