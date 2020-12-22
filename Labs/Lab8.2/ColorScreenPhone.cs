using System;
using System.Collections.Generic;
using System.Text;

namespace Phone
{
    class ColorScreenPhone : BlackWhiteMobile
    {
        public int CountColors
        {
            set;
            get;
        }
        public bool TwoSIMCards
        {
            get;
            set;
        }
        public string SecondNumber
        {
            get;
            set;
        }

        public ColorScreenPhone(string PhoneNumber, int width, int height, double size, string color, int countColors, string secondNumber = null) : base(PhoneNumber, width, height, size, color)
        {
            CountColors = countColors;
            SecondNumber = secondNumber;
            if (secondNumber != null) TwoSIMCards = true;
        }
        public override void MakeCall()
        {
            if (!TwoSIMCards) base.MakeCall();
            else
            {
                while (true)
                {
                    Console.Write("Enter a sim(1 - first sim, 2 - second sim):");
                    int numberSim = 0;
                    if (int.TryParse(Console.ReadLine(), out numberSim) && (numberSim == 1 || numberSim == 2))
                    {
                        Console.WriteLine($"You are calling from {(numberSim == 1 ? Number : SecondNumber)} to {EnterNumber()}");
                        break;
                    }
                    else Console.WriteLine("Invalid input. Try again");
                }
            }

        }
        public override void SendSMS()
        {
            Console.WriteLine("==============SMS=============");
            if (!TwoSIMCards) base.SendSMS();
            else
            {
                while (true)
                {
                    Console.Write("Enter a sim(1 - first sim, 2 - second sim):");
                    int numberSim = 0;
                    if (int.TryParse(Console.ReadLine(), out numberSim) && (numberSim == 1 || numberSim == 2))
                    {
                        Console.WriteLine($"You are sending SMS from {(numberSim == 1 ? Number : SecondNumber)} to {EnterNumber()}");
                        break;
                    }
                    else Console.WriteLine("Invalid input. Try again");
                }
            }

        }
        public void SendMMS()
        {
            Console.WriteLine("================MMS===============");
            while (true)
            {
                Console.Write("Enter a sim(1 - first sim, 2 - second sim):");
                int numberSim = 0;
                if (int.TryParse(Console.ReadLine(), out numberSim) && (numberSim == 1 || numberSim == 2))
                {
                    Console.WriteLine($"You are sending MMS from {(numberSim == 1 ? Number : SecondNumber)} to {EnterNumber()}");
                    break;
                }
                else Console.WriteLine("Invalid input. Try again");
            }
        }
        public override void TakeCall(string PhoneNumber)
        {
            base.TakeCall(PhoneNumber);
        }
        public override void ReceiveSMS(string PhoneNumber)
        {
            base.ReceiveSMS(PhoneNumber);
        }
        public void ReceiveMMS(string PhoneNumber)
        {
            Console.WriteLine($"You have received MMS from {PhoneNumber}");
        }

    }
}