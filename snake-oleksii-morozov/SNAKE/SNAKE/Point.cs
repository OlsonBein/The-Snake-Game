using System;

namespace GameSnake
{
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Point point = (Point)obj;
            if (point == null)
                return false;
            else
                return Equals(point);
        }

        public bool Equals(Point other) => this.X == other.X && this.Y == other.Y;

        public override int GetHashCode()
        {
            return X * Y;
        }
    }
}