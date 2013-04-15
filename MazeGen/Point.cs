using System;
using System.Diagnostics;

namespace MazeGen
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point():this(0, 0, 0)
        {
        }

        public Point Clone()
        {
            return new Point(X, Y, Z);
        }

        public Point Next(Direction d)
        {
            return Next(d, 1);
        }

        public Point Prev(Direction d)
        {
            return Prev(d, 1);
        }
        public Point Next(Direction d, int inc)
        {
            var point = Clone();
            if (d == Direction.X) point.X+=inc;
            if (d == Direction.Y) point.Y+=inc;
            if (d == Direction.Z) point.Z+=inc;
            return point;
        }

        public Point Prev(Direction d, int dec)
        {
            var point = Clone();
            if (d == Direction.X) point.X-=dec;
            if (d == Direction.Y) point.Y-=dec;
            if (d == Direction.Z) point.Z-=dec;
            return point;
        }

        public int this[Direction d]
        {
            get
            {
                if (d == Direction.X) return X;
                if (d == Direction.Y) return Y;
                if (d == Direction.Z) return Z;
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (d == Direction.X) X = value;
                else if (d == Direction.Y) Y = value;
                else if (d == Direction.Z) Z = value;
            }
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }
}