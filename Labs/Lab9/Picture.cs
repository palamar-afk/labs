using System.Collections.Generic;

namespace Figure
{
    class Picture : IDraw
    {
        private List<Shape> shapes;
        public int CountShapes => shapes.Count;
        public Picture()
        {
            shapes = new List<Shape>();
        }
        public Picture(int countShapes)
        {
            shapes = new List<Shape>(countShapes);
        }
        public void Draw()
        {
            foreach (var figure in shapes)
                figure.Draw();
        }
        public void addFigure(Shape figure) => shapes.Add(figure);
        public bool removeFigure(string name, string type, double square)
        {
            if (type.ToLower() == "square")
            {
                shapes.RemoveAll(x => x is Square && x.Name == name && x.SquareFind() > square);
                return true;
            }
            if (type.ToLower() == "circle")
            {
                shapes.RemoveAll(x => x is Circle && x.Name == name && x.SquareFind() > square);
                return true;
            }
            if (type.ToLower() == "triangle")
            {
                shapes.RemoveAll(x => x is Triangle && x.Name == name && x.SquareFind() > square);
                return true;
            }
            return false;
        }
        public Shape this[int index] => shapes[index];

    }
}