namespace Extensions
{
    public static class IntArrayExtension
    {
        public static void ReverseArray(this int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }
        }
        public static void ReverseArrayOut(this int[] arr, out int[] newArr)
        {
            newArr = arr;
            for (int i = 0; i < newArr.Length / 2; i++)
            {
                int temp = newArr[i];
                newArr[i] = newArr[newArr.Length - i - 1];
                newArr[newArr.Length - i - 1] = temp;
            }
        }
        public static void RandomArray(this int[] arr, int count)
        {
            System.Random random = new System.Random();
            for (int i = 0; i < count; i++)
            {
                arr[i] = random.Next(10, 100);
            }
        }
        public static void ShowArray(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write(arr[i] + " ");
            }
            System.Console.WriteLine();
        }
    }
}