using System;
using Figure;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Picture picture = new Picture(5);

            picture.addFigure(new Triangle("trian1"));
            picture.addFigure(new Circle("circle1", 34.6, 6));

            picture.addFigure(new Square("square1", 13));
            picture.addFigure(new Triangle("trian2"));

            picture.addFigure(new Circle("circle2"));

            picture.Draw();
            Console.WriteLine(new string('=', 40));
            picture[3].Draw();

            Console.WriteLine(new string('=', 40));

            Painter.Draw(picture[1]);

            Console.WriteLine(new string('=', 40));

            picture.removeFigure("circle1", "Circle", 6);
            Painter.Draw(picture[1]);
        }
    }
}