using System;
using Extensions;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            int usualInt = 12345;
            Console.ForegroundColor = (ConsoleColor)9;
            Console.WriteLine($"Usual int: \t\t{usualInt}");
            Console.ResetColor();
            Console.WriteLine($"Usual INT reverse: \t{usualInt.usualReverse()}");
            Console.WriteLine($"Recursive INT reverse: \t{usualInt.RecursiveReverse()}");
            Console.WriteLine(new string('=', 40));

            //строка без разделителя
            string usualString = "abcdefghjiklmnoprst";
            Console.ForegroundColor = (ConsoleColor)9;
            Console.WriteLine($"Usual string: \t\t\t{usualString}");
            Console.ResetColor();
            Console.WriteLine($"Usual STRING reverse: \t\t{usualString.usualReverse()}");
            Console.WriteLine($"Recursive STRING reverse: \t{usualString.RecursiveReverse()}");
            Console.WriteLine(new string('=', 40));

            //строка с разделителем
            string usualSeparatorString = "abcdefghj|iklmnoprst";
            Console.ForegroundColor = (ConsoleColor)9;
            Console.WriteLine($"Usual separator string: \t{usualSeparatorString}");
            Console.ResetColor();
            Console.WriteLine($"Usual sepSTRING reverse: \t{usualSeparatorString.usualReverse("|")}");
            Console.WriteLine($"Recursive sepSTRING reverse: \t{usualSeparatorString.RecursiveReverse('|')}");
            Console.WriteLine(new string('=', 40));

            double usualDouble = 123.456;
            Console.ForegroundColor = (ConsoleColor)9;
            Console.WriteLine($"Usual double: \t\t\t{usualDouble}");
            Console.ResetColor();
            Console.WriteLine($"Usual DOUBLE reverse: \t\t{usualDouble.usualReverse()}");
            Console.WriteLine($"Recursive DOUBLE reverse: \t{usualDouble.RecursiveReverse()}");
            Console.WriteLine(new string('=', 80));

            int[] intArray = new int[10];
            intArray.RandomArray(10);

            Console.ForegroundColor = (ConsoleColor)12;
            Console.Write($"Usual int array: \t\t\t\t");
            intArray.ShowArray();
            Console.ResetColor();

            Console.Write("Usual reverse int array: \t\t\t");
            intArray.ReverseArray();
            intArray.ShowArray();

            intArray.ReverseArray(); //чтобы снова вернуть массив в первоначальное состояние для следующего реверса с ключевым словом "out"

            Console.Write("Usual reverse(with \"out\" keyword) int array:\t");
            int[] reversedIntArray = new int[10];
            intArray.ReverseArrayOut(out reversedIntArray);
            reversedIntArray.ShowArray();

            Console.WriteLine(new string('=', 80));
        }
    }
}