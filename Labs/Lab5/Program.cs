using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            do
            {
                Console.Write("Enter n: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 1)
                {
                    Console.WriteLine("Invalid index n. Try again");
                }
            } while (n < 1);

            do
            {
                Console.Write("Enter m: ");
                m = Convert.ToInt32(Console.ReadLine());
                if (m < 1)
                {
                    Console.WriteLine("Invalid index m. Try again");
                }
            } while (m < 1);

            int[,] arr = new int[n, m];
            Random random = new Random();

            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < m; j++) 
                {
                    arr[i, j] = random.Next(100);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i,j]+"\t");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("==========================");

            int min = arr[0, 0],
                max = min,
                maxIndex = 0,
                minIndex = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if(min>arr[i,j])
                    {
                        min = arr[i, j];
                        minIndex = i; 
                        //minIndex = j; -- for columns
                    }
                    else if(max<arr[i,j])
                    {
                        max = arr[i, j];
                        maxIndex = i;
                        //maxIndex = j;  -- for columns
                    }
                }
            }

            Console.WriteLine("min=" + min);
            Console.WriteLine("max=" + max);
            for (int j = 0; j < m; j++)
            {
                int temp = arr[maxIndex, j];
                arr[maxIndex, j] = arr[minIndex, j];
                arr[minIndex, j] = temp;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
