using System;
using Phone;

namespace Lab8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = "0501234567",
            secondNumber = "19562954305",
            receiverNumber = "0996455352";
            Console.WriteLine("\n\n===============Dial Phone===============\n\n");
            DialPhone dial_phone = new DialPhone(number);
            dial_phone.MakeCall();
            dial_phone.TakeCall(receiverNumber);
            Console.WriteLine($"your number is {dial_phone.Number}");

            Console.WriteLine("\n\n===============Push Button Phone===============\n\n");

            PushButtonTelephone pb_phone = new PushButtonTelephone(number);
            pb_phone.MakeCall();
            pb_phone.TakeCall(receiverNumber);
            Console.WriteLine($"your number is {pb_phone.Number}");

            Console.WriteLine("\n\n===============Black White Mobile===============\n\n");

            BlackWhiteMobile bw_phone = new BlackWhiteMobile(number, 1000, 500, 6.5, "green");
            bw_phone.MakeCall();
            bw_phone.TakeCall(receiverNumber);
            bw_phone.SendSMS();
            bw_phone.ReceiveSMS(receiverNumber);
            Console.WriteLine($"=========\nyour number is {bw_phone.Number}");
            Console.WriteLine($"width is {bw_phone.Width}");
            Console.WriteLine($"height is {bw_phone.Height}");
            Console.WriteLine($"size is {bw_phone.Size}");
            Console.WriteLine($"color is {bw_phone.Color}");

            Console.WriteLine("\n\n===============Color Screen Phone===============\n\n");

            ColorScreenPhone cs_phone = new ColorScreenPhone(number, 800, 600, 7.3, "blue", 1000000, secondNumber);
            cs_phone.MakeCall();
            cs_phone.TakeCall(receiverNumber);
            cs_phone.SendSMS();
            cs_phone.ReceiveSMS(receiverNumber);
            cs_phone.SendMMS();
            cs_phone.ReceiveMMS(receiverNumber);
            Console.WriteLine($"=========\nyour number is {cs_phone.Number}");
            Console.WriteLine($"width is {cs_phone.Width}");
            Console.WriteLine($"height is {cs_phone.Height}");
            Console.WriteLine($"size is {cs_phone.Size}");
            Console.WriteLine($"color is {cs_phone.Color}");
            Console.WriteLine($"colors' count is {cs_phone.CountColors}");
            Console.WriteLine($"second number is {cs_phone.SecondNumber}");

            Console.WriteLine("\n\n===============Smartphone===============\n\n");
            Smartphone smart_phone = new Smartphone(number, 800, 600, 7.3, "blue", 1000000, secondNumber, true, 10, 3);
            smart_phone.MakeCall();
            smart_phone.TakeCall(receiverNumber);
            smart_phone.SendSMS();
            smart_phone.ReceiveSMS(receiverNumber);
            smart_phone.SendMMS();
            smart_phone.ReceiveMMS(receiverNumber);
            smart_phone.MakePhoto();
            smart_phone.RecordVideo();
            Console.WriteLine($"=========\nyour number is {smart_phone.Number}");
            Console.WriteLine($"width is {smart_phone.Width}");
            Console.WriteLine($"height is {smart_phone.Height}");
            Console.WriteLine($"size is {smart_phone.Size}");
            Console.WriteLine($"color is {smart_phone.Color}");
            Console.WriteLine($"colors' count is {smart_phone.CountColors}");
            Console.WriteLine($"second number is {smart_phone.SecondNumber}");
            Console.WriteLine($"Censor control is {smart_phone.IsCensorControl}");
            Console.WriteLine($"Max touches is {smart_phone.MaxCountTouches}");
            Console.WriteLine($"cameras' count is {smart_phone.CountCameras}");
        }
    }
}