using System;

namespace MazeGen
{
    public abstract class MazeGeneratorBase: IMazeGenerator
    {
        protected readonly int Width;
        protected readonly int Height;
        protected readonly int Depth;
        protected readonly Random Rand;

        protected MazeGeneratorBase(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;

            Rand = new Random();
        }

        public abstract MazeMatrix Generate();

        protected MazeMatrix GetEmpty()
        {
            var result = new Wall[Width,Height,Depth];
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    result[x, y, 0] |= Wall.Lz;
                    result[x, y, Depth-1] |= Wall.Hz;
                }
                for (var z = 0; z < Depth; z++)
                {
                    result[x, 0, z] |= Wall.Ly;
                    result[x, Height - 1, z] |= Wall.Hy;
                }
            }
            for (var z = 0; z < Depth; z++)
            {
                for (var y = 0; y < Height; y++)
                {
                    result[0, y, z] |= Wall.Lx;
                    result[Width-1, y, z] |= Wall.Hx;
                }
            }
            return new MazeMatrix(result);
        }

        protected MazeMatrix GetFull()
        {
            var result = new Wall[Width, Height, Depth];
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    for (var z = 0; z < Depth; z++)
                    {
                        result[x, y, z] = Wall.All;
                    }
                }
            }
            return new MazeMatrix(result);
        }
    }
}