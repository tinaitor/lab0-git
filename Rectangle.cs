using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab0_git
{
    public class Rectangle
    {
        public Point2D Start { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(Point2D start, int width, int height)
        {
            Start = start;
            Width = width;
            Height = height;
        }
        public void AddX(int x)
        {
            Start.AddX(x);
        }

        public void AddY(int y)
        {
            Start.AddY(y);
        }
    }
}
