using System;
using System.Collections.Generic;
using System.Text;

namespace Phone

{
    class BlackWhiteMobile : PushButtonTelephone
    {
        public override List<char> Symbols
        {
            get
            {
                return new List<char>() {
          '0',
          '1',
          '2',
          '3',
          '4',
          '5',
          '6',
          '7',
          '8',
          '9',
          '*',
          '#',
          'a',
          'b',
          'c',
          'd',
          'e',
          'f',
          'g',
          'h',
          'i',
          'j',
          'k',
          'l',
          'm',
          'n',
          'o',
          'p',
          'q',
          'r',
          's',
          't',
          'u',
          'v',
          'w',
          'x',
          'y',
          'z',
          '+'
        };
            }
        }
        public int Height
        {
            set;
            get;
        }
        public int Width
        {
            set;
            get;
        }
        public double Size
        {
            set;
            get;
        }
        public string Color
        {
            set;
            get;
        }
        public BlackWhiteMobile(string PhoneNumber, int width, int height, double size, string color) : base(PhoneNumber)
        {
            Height = height;
            Width = width;
            Color = color;
            Size = size;
        }
        public virtual void SendSMS()
        {
            Console.WriteLine("==============SMS=============");
            Console.WriteLine($"SMS has beeb sent to {EnterNumber()}");
        }
        public virtual void ReceiveSMS(string PhoneNumber)
        {
            Console.WriteLine($"You have received the SMS from {PhoneNumber}");
        }
    }
}