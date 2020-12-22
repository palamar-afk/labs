using System;
using System.Collections.Generic;
using System.Text;
using Phone;
class PushButtonTelephone : DialPhone
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
        '#'
      };
        }
    }
    public PushButtonTelephone(string PhoneNumber) : base(PhoneNumber) { }
    public override void TakeCall(string PhoneNumber)
    {
        Console.WriteLine($"IN: Call for you from {PhoneNumber}");
    }
}