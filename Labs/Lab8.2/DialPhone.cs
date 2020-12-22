using System;
using System.Collections.Generic;
using System.Text;

namespace Phone
{
    class DialPhone
    {
        private List<char> symbols = new List<char>() {
      '0',
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9'
    };
        public string Number
        {
            get;
            set;
        }
        public DialPhone(string number)
        {
            while (true)
            {
                bool isOk = true;
                foreach (var item in number)
                {
                    if (!symbols.Contains(item))
                    {
                        Console.WriteLine("Incorrect number(only 0123456789)");
                        isOk = false;
                        break;
                    }
                }
                if (isOk) break;
            }
            Number = number;
        }
        public virtual List<char> Symbols
        {
            get
            {
                return symbols;
            }
            set
            {
                Symbols = symbols;
            }
        }
        protected string EnterNumber()
        {
            while (true)
            {
                Console.WriteLine("Enter an abonent's number:");
                string number = Console.ReadLine();
                bool IsCorrect = true;
                foreach (char item in number)
                {
                    if (Symbols.Contains(item)) { }
                    else
                    {
                        Console.WriteLine("Try to enter the number again");
                        IsCorrect = false;
                        break;
                    }
                }
                if (IsCorrect)
                {
                    return number;
                }
            }

        }
        public virtual void MakeCall()
        {
            Console.WriteLine($"OUT: You are calling {EnterNumber()}");
        }

        public virtual void TakeCall(string PhoneNumber)
        {
            Console.WriteLine("IN: Call for you");
        }
    }
}