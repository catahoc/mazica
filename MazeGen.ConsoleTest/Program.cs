using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 10;
            var sizez = 1;
            var gen = new RecursiveMazeGenerator(size, size, sizez);
            var maze = gen.Generate();
            for (int z = 0; z < sizez; z++)
            {
                Console.WriteLine("z = {0}", z);
                var chars = new char[size * 3, size * 3];
                for (int x = 0; x < size; x++)
                {
                    var cx = x * 3 + 1;
                    for (int y = 0; y < size; y++)
                    {
                        var cy = y * 3 + 1;
                        chars[cx - 1, cy - 1] = '=';
                        chars[cx + 1, cy - 1] = '=';
                        chars[cx - 1, cy + 1] = '=';
                        chars[cx + 1, cy + 1] = '=';
                        var p = new Point(x, y, z);
                        if (maze[p].HasFlag(Wall.Hx))
                            chars[cx + 1, cy] = '=';
                        if (maze[p].HasFlag(Wall.Lx))
                            chars[cx - 1, cy] = '=';
                        if (maze[p].HasFlag(Wall.Hy))
                            chars[cx, cy + 1] = '=';
                        if (maze[p].HasFlag(Wall.Ly))
                            chars[cx, cy - 1] = '=';
                        if ((maze[p] & Wall.BothZ) == 0) chars[cx, cy] = '↕';
                        else if ((maze[p] & Wall.Hz) == 0) chars[cx, cy] = '↑';
                        else if ((maze[p] & Wall.Lz) == 0) chars[cx, cy] = '↓';
                        else chars[cx, cy] = ' ';
                    }
                }
                for (int cy = size*3-1; cy >= 0; cy--)
                {
                    for (int cx = 0; cx < size * 3; cx++)
                    {
                        Console.Write(chars[cx, cy]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
