using System;

namespace Figure
{
    abstract class Shape : IDraw
    {
        public abstract ConsoleColor Color
        {
            get;
            set;
        }
        public abstract int CountVertexes
        {
            get;
        }
        public abstract string Name
        {
            get;
        }
        public abstract double SquareFind();
        public abstract double PerimeterFind();
        public abstract void Draw();
    }
}