using System;
using System.Collections.Generic;
using System.Text;

namespace Phone
{
    class Smartphone : ColorScreenPhone
    {
        public bool IsCensorControl
        {
            get;
            set;
        }
        public int MaxCountTouches
        {
            get;
            set;
        }
        public int CountCameras
        {
            get;
            set;
        }

        public Smartphone(
        string PhoneNumber, int width, int height, double size, string color, int countColors, string secondNumber, bool isCencorControl, int maxCountTouches, int countCameras) : base(PhoneNumber, width, height, size, color, countColors, secondNumber)
        {
            IsCensorControl = isCencorControl;
            MaxCountTouches = maxCountTouches;
            CountCameras = countCameras;
        }
        public void MakePhoto()
        {
            Console.WriteLine("===================Photo==================");
            if (CountCameras > 1)
            {
                Console.Write("What camera do you want to use?(1,2,...): ");
                int indexOfCamera = 0;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out indexOfCamera))
                    {
                        if (indexOfCamera <= CountCameras && indexOfCamera > 0) break;
                        else Console.WriteLine("Try again:");
                    }
                    else Console.WriteLine("Try again:");
                }
                Console.WriteLine($"You took a photo from {indexOfCamera}th camera");
            }
            else if (CountCameras == 0) Console.WriteLine("You can't take a photo. No cameras on device");
            else
            {
                Console.WriteLine("You took a photo from only one camera");
            }
        }
        public void RecordVideo()
        {
            Console.WriteLine("===================Video Record==================");
            if (CountCameras > 1)
            {
                Console.Write("What camera do you want to use?(1,2,...): ");
                int indexOfCamera = 0;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out indexOfCamera))
                    {
                        if (indexOfCamera <= CountCameras && indexOfCamera > 0) break;
                        else Console.WriteLine("Try again:");
                    }
                    else Console.WriteLine("Try again:");
                }
                Console.WriteLine($"You recorded video from {indexOfCamera}th camera");
            }
            else if (CountCameras == 0) Console.WriteLine("You can't record video. No cameras on device");
            else
            {
                Console.WriteLine("You recorded video from only one camera");
            }
        }

    }
}