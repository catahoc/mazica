using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeGen
{
    public static class DirectionExtensions
    {
        public static IEnumerable<Direction> Others(this Direction dir)
        {
            var all = new[] {Direction.X, Direction.Y, Direction.Z,};
            return all.Where(direction => direction != dir);
        }
        public static Wall LowerWall(this Direction dir)
        {
            switch (dir)
            {
                case Direction.X:
                    return Wall.Lx;
                case Direction.Y:
                    return Wall.Ly;
                case Direction.Z:
                    return Wall.Lz;
                default:
                    throw new ArgumentOutOfRangeException("dir");
            }
        }
        public static Wall HigherWall(this Direction dir)
        {
            switch (dir)
            {
                case Direction.X:
                    return Wall.Hx;
                case Direction.Y:
                    return Wall.Hy;
                case Direction.Z:
                    return Wall.Hz;
                default:
                    throw new ArgumentOutOfRangeException("dir");
            }
        }
    }
}