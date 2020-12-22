namespace Figure
{
    static class Painter
    {
        public static void Draw(IDraw itemForDrawing)
        {
            itemForDrawing.Draw();
        }
    }
}