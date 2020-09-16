using System;
using System.Globalization;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter radius(separator ','): ");
            string radius_str = Console.ReadLine();
            double radius = Convert.ToDouble(radius_str);
            Console.Write("Enter height(separotor ','): ");
            string height_str = Console.ReadLine();
            double height = Convert.ToDouble(height_str);
            double result = Math.PI * radius * radius * height * 1 / 3;
            Console.WriteLine("Volume of conus is " + result);
        }
    }
}
