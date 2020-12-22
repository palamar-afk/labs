using System;

namespace Figure
{
    class Circle : Shape
    {
        public override string Name
        {
            get;
        }
        public override ConsoleColor Color
        {
            get;
            set;
        }
        public override int CountVertexes => 0;
        public double Radius
        {
            get;
            set;
        }
        public override void Draw()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Name: \t\t\t\"{Name}\"");
            Console.WriteLine($"Color: \t\t\t\"{Color}\"");
            Console.WriteLine($"Count of vertexes: \t\"{CountVertexes}\"");
            Console.WriteLine($"Length of radius: \t\"{Radius}\"");
            Console.WriteLine($"Square: \t\t\"{SquareFind()}\"");
            Console.WriteLine($"Perimeter: \t\t\"{PerimeterFind()}\"");
            Console.ResetColor();
            Console.WriteLine(new string('=', 40));
        }
        public Circle(string name)
        {
            Random rand = new Random();
            Name = name;
            Color = (ConsoleColor)rand.Next(16);
            Radius = rand.Next(10, 30);
        }
        public Circle(string name, double radius)
        {
            Random rand = new Random();
            Name = name;
            Color = (ConsoleColor)rand.Next(16);
            Radius = radius;
        }
        public Circle(string name, double radius, int numberColor)
        {
            Random rand = new Random();
            Name = name;
            Color = (ConsoleColor)numberColor;
            Radius = radius;
        }
        public override double SquareFind() => Math.PI * (Math.Pow(Radius, 2));
        public override double PerimeterFind() => 2 * Math.PI * Radius;
    }
}