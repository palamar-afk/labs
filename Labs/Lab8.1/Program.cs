using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8
{
    class Garage
    {
        static List<Car> cars = new List<Car>();

        public static void AddCar(Car car) => cars.Add(car);
        public static void RemoveCar(Car car) => cars.RemoveAll(x => x.Year == car.Year && x.Name == car.Name && x.Color == car.Color && x.Speed == car.Speed);
        public static List<Car> SequenceCar(Car car)
        {
            int n = 0;
            Console.Write("Enter 1 for all criterias finding, 2 - for some:");
            int.TryParse(Console.ReadLine(), out n);
            List<Car> sequence = new List<Car>();
            switch (n)
            {
                case 1:
                    {
                        foreach (var x_car in cars)
                        {
                            if (x_car.Year != car.Year)
                                continue;
                            else if (x_car.Color != car.Color)
                                continue;
                            else if (x_car.Name != car.Name)
                                continue;
                            else if (x_car.Speed != car.Speed)
                                continue;
                            sequence.Add(x_car);
                        }
                    }
                    break;
                case 2:
                    {
                        foreach (var x_car in cars)
                        {
                            if (x_car.Year == car.Year)
                            {
                                sequence.Add(x_car);
                                continue;
                            }
                            else if (x_car.Color == car.Color)
                            {
                                sequence.Add(x_car);
                                continue;
                            }
                            else if (x_car.Name == car.Name)
                            {
                                sequence.Add(x_car);
                                continue;
                            }
                            else if (x_car.Speed == car.Speed)
                            {
                                sequence.Add(x_car);
                                continue;
                            }
                        }
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Try next time! Bye!!!");
                    }
                    break;
            }
            return sequence;
        }
        public static void ShowGarage()
        {
            foreach (var car in cars)
                Console.WriteLine($"\nYear: {car.Year} \nName: {car.Name} \nColor: {car.Color} \nSpeed: {car.Speed} \n==========================");
        }
        public static void ShowFindCars(List<Car> sequence)
        {
            if(sequence.Count == 0)
                Console.WriteLine("No cars was found");
            foreach (var item in sequence)
            {
                Console.WriteLine($"\nYear: {item.Year} \nName: {item.Name} \nColor: {item.Color} \nSpeed: {item.Speed} \n==========================");
            }
        }
    }
    class Car
    {
        public int Year { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double Speed { get; set; }
        public Car(int year, string name, string color, double speed)
        {
            Name = name;
            Year = year;
            Color = color;
            Speed = speed;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = 0;
                Console.Write("Enter the option(Add - 1, Remove - 2, Find - 3, Show the garage - 4:");
                int tempYear = 0;
                double tempSpeed = 0;
                string tempName, tempColor;
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    switch (n)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter the options(for adding):");
                                Console.Write("\tName:");
                                tempName = Console.ReadLine();
                                Console.Write("\tSpeed:");
                                double.TryParse(Console.ReadLine(), out tempSpeed);
                                Console.Write("\tColor:");
                                tempColor = Console.ReadLine();
                                Console.Write("\tYear:");
                                int.TryParse(Console.ReadLine(), out tempYear);
                                Car car = new Car(tempYear, tempName, tempColor, tempSpeed);
                                Garage.AddCar(car);
                                Console.WriteLine("Car was added");
                            }
                            break;
                        case 2:
                            {
                                Console.WriteLine("Enter the options(for removing):");
                                Console.Write("\tName:");
                                tempName = Console.ReadLine();
                                Console.Write("\tSpeed:");
                                double.TryParse(Console.ReadLine(), out tempSpeed);
                                Console.Write("\tColor:");
                                tempColor = Console.ReadLine();
                                Console.Write("\tYear:");
                                int.TryParse(Console.ReadLine(), out tempYear);
                                Car car = new Car(tempYear, tempName, tempColor, tempSpeed);
                                Garage.RemoveCar(car);
                                Console.WriteLine("Car was removed if had been found");
                            }
                            break;
                        case 3:
                            {
                                Console.WriteLine("Enter the options(for finding):");
                                Console.Write("\tName:");
                                tempName = Console.ReadLine();
                                Console.Write("\tSpeed:");
                                double.TryParse(Console.ReadLine(), out tempSpeed);
                                Console.Write("\tColor:");
                                tempColor = Console.ReadLine();
                                Console.Write("\tYear:");
                                int.TryParse(Console.ReadLine(), out tempYear);
                                Car car = new Car(tempYear, tempName, tempColor, tempSpeed);
                                Garage.ShowFindCars(Garage.SequenceCar(car));
                            }
                            break;
                        case 4:
                            {
                                Garage.ShowGarage();
                            }
                            break;
                        default: Console.WriteLine("Incorrect value"); break;
                    }
                }
                else
                    continue;
            }
        }
    }
}
