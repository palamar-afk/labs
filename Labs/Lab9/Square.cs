using System;

namespace Figure
{
    class Square : Shape
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
        public override int CountVertexes => 4;
        public double SideLength
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
            Console.WriteLine($"Length of side: \t\"{SideLength}\"");
            Console.WriteLine($"Square: \t\t\"{SquareFind()}\"");
            Console.WriteLine($"Perimeter: \t\t\"{PerimeterFind()}\"");
            Console.ResetColor();
            Console.WriteLine(new string('=', 40));
        }
        public Square(string name)
        {
            Random rand = new Random();
            Name = name;
            Color = (ConsoleColor)rand.Next(16);
            SideLength = rand.Next(10, 30);
        }
        public Square(string name, double size)
        {
            Random rand = new Random();
            Name = name;
            Color = (ConsoleColor)rand.Next(16);
            SideLength = size;
        }
        public Square(string name, double size, int numberColor)
        {
            Random rand = new Random();
            Name = name;
            Color = (ConsoleColor)numberColor;
            SideLength = size;
        }
        public override double SquareFind() => SideLength * SideLength;
        public override double PerimeterFind() => 4 * SideLength;
    }
}