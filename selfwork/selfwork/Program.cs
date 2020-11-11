using System;
using System.Collections.Generic;
using System.Dynamic;

namespace mainCSharp
{
    class Error
    {
        private string noColor = "There is not the car with this color",
        noPrice = "There is not the car with this price",
        noSpeed = "There is not the car with this speed",
        noYear = "There is not the car with this year";
        public string getError(int n)
        {
            switch (n)
            {
                case 1:
                    return this.noColor;
                case 2:
                    return this.noYear;
                case 3:
                    return this.noPrice;
                case 4:
                    return this.noSpeed;
                default:
                    return "Unknown error";
            }
        }
    }
    class Human
    {
        private string requiredColor = "";
        private int requiredYear;
        private int requiredPrice;
        private int requiredMaxSpeed;

        public Human()
        {
            this.requiredColor = "black";

            this.requiredYear = 2000;
            this.requiredPrice = 50000;
            this.requiredMaxSpeed = 280;
        }
        public Human(string color, int year, int price, int maxSpeed)
        {
            this.requiredColor = color;

            this.requiredYear = year;
            this.requiredPrice = price;
            this.requiredMaxSpeed = maxSpeed;
        }
        public string getRequiredColor()
        {
            return this.requiredColor;
        }
        public int getRequiredYear()
        {
            return this.requiredYear;
        }
        public int getrequiredPrice()
        {
            return this.requiredPrice;
        }
        public int getRequiredMaxSpeed()
        {
            return this.requiredMaxSpeed;
        }

    }
    class Cars
    {
        private List<string> colors = new List<string>() { }; //"red", "white", "blue", "yellow", "black" 
        private int year;
        private int price;
        private int maxSpeed;
        Error error = new Error();
        public Cars()
        {
            this.colors.Add("black");
            this.colors.Add("red");
            this.colors.Add("green");
            this.colors.Add("blue");
            this.colors.Add("yellow");

            this.year = 2000;
            this.price = 50000;
            this.maxSpeed = 280;
        }
        public Cars(string[] arrColor, int year, int price, int maxSpeed)
        {
            for (int i = 0; i < arrColor.Length; i++)
            {
                colors.Add(arrColor[i]);
            }
            this.year = year;
            this.price = price;
            this.maxSpeed = maxSpeed;
        }
        private bool isColor(Human require)
        {
            if (this.colors.Find(item => item == require.getRequiredColor()) == require.getRequiredColor())
            {
                return true;
            }
            Console.WriteLine("Type of error:\t" + error.getError(1));
            return false;
        }
        private bool isYear(Human require)
        {
            if (this.year == require.getRequiredYear())
            {
                return true;
            }
            Console.WriteLine("Type of error:\t" + error.getError(2));
            return false;
        }
        private bool isPrice(Human require)
        {
            if (this.price == require.getrequiredPrice())
            {
                return true;
            }
            Console.WriteLine("Type of error:\t" + error.getError(3));
            return false;
        }

        private bool isMaxSpeed(Human require)
        {
            if (this.maxSpeed == require.getRequiredMaxSpeed())
            {
                return true;
            }
            Console.WriteLine("Type of error:\t" + error.getError(4));
            return false;
        }

        public void getCar(Human require)
        {
            if (isColor(require) && isYear(require) && isPrice(require) && isMaxSpeed(require))
            {
                Console.WriteLine("=============\tYOUR CAR IS FOUND\t=============");
                Console.WriteLine("Color:\t" + this.colors.Find(item => item == require.getRequiredColor()));
                Console.WriteLine("Price:\t" + this.price);
                Console.WriteLine("Year:\t" + this.year);
                Console.WriteLine("Max speed:\t" + this.maxSpeed + "\n");
            }
            else
            {
                Console.WriteLine("\nThe car with such properties is absent\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Human requirements = new Human("red", 2000, 50000, 280); // string color, int year, int price, int maxSpeed

            Cars car = new Cars(new String[] { "pink", "yellow", "brown" }, 2005, 60000, 300); //string[] arrColor, int year, int price, int maxSpeed
            Cars car1 = new Cars(new String[] { "red", "orange", "black", "white", "blue" }, 2019, 55000, 230);
            Cars car2 = new Cars(new String[] { "grey", "white", "orange" }, 2001, 15000, 170);
            Cars car3 = new Cars();
            Cars car4 = new Cars(new String[] { "white", "pink", "orange", "black", "yellow", "brown" }, 2020, 90000, 460);

            Cars[] cars = { car, car1, car2, car3, car4 };

            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine($"-------------\t{i + 1} CAR SHOWROOM\t-------------");
                cars[i].getCar(requirements);
            }
        }
    }
}