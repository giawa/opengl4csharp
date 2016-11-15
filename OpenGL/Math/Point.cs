using System;

namespace OpenGL
{
    public struct Point
    {
        #region Variables
        public int x, y;
        #endregion

        #region Constructor
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Operators
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return x + "," + y;
        }

        public static Point Min(Point a, Point b)
        {
            return new Point((a.x > b.x) ? b.x : a.x, (a.y > b.y) ? b.y : a.y);
        }

        public static Point Max(Point a, Point b)
        {
            return new Point((a.x < b.x) ? b.x : a.x, (a.y < b.y) ? b.y : a.y);
        }

        public bool IsWithin(Point Position, Point Size)
        {
            return !(x < Position.x || y < Position.y || x > Position.x + Size.x || y > Position.y + Size.y);
        }
        #endregion
    }
}
