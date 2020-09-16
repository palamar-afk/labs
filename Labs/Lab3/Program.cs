using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.Write("Enter 1st number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter 2nd number: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter 3rd number: ");
            c = Convert.ToInt32(Console.ReadLine());
            if(a==b || a==c || b==c)
            {
                Console.WriteLine("There is at least a pair of the same numbers");
            }
            else
            {
                Console.WriteLine("There is not the same numbers");
            }


        }
    }
}
