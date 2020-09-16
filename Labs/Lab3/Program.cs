using System;
using System.Collections.Concurrent;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.Write("Enter 1st coeff: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter 2nd coeff: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter 3rd coeff: ");
            c = Convert.ToInt32(Console.ReadLine());
            int diskr = b * b - 4 * a * c;
            if(diskr>=0)
            {
                Console.WriteLine("Equation has real roots");
            }
            else
            {
                Console.WriteLine("Equation has not real roots");
            }
        }
    }
}
