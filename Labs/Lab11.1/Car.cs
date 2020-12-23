using System;

namespace Lab11
{
    class Car
    {
        public bool IsCorrectWheelAngles
        {
            set;
            get;
        }
        public bool IsPainted
        {
            set;
            get;
        }
        public bool IsOilChanged
        {
            set;
            get;
        }
        public bool IsFullRevision
        {
            set;
            get;
        }
        public bool IsWheelReplaced
        {
            set;
            get;
        }
        public bool IsCarBodyRepaired
        {
            set;
            get;
        }

        public void show()
        {
            Console.WriteLine(
      $"IsCorrectWheelAngles -- {IsCorrectWheelAngles}\n" + 
      $"IsPainted -- {IsPainted}\n" + 
      $"IsOilChanged -- {IsOilChanged}\n" + 
      $"IsFullRevision -- {IsFullRevision}\n" + 
      $"IsWheelReplaced -- {IsWheelReplaced}\n" + 
      $"IsCarBodyRepaired -- {IsCarBodyRepaired}");
        }
    }
}