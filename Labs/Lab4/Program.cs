using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for(int i=0; i<size; i++)
            {
                Console.Write("Enter " + (i + 1) + " element: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            bool corrupt=false;
            int indexOfCorrupt = 0;
            for (int i = 0; i < size; i++)
            {
               if(arr[i]<1 || arr[i] > size)
               {
                    corrupt = true;
                    indexOfCorrupt = i+1;
                    break;
               }
            }
            if(corrupt)
                Console.WriteLine(indexOfCorrupt + "th element is corrupted");
            else
                Console.WriteLine(0);
        }
    }
}
