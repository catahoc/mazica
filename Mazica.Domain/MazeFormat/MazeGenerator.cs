using System;
using System.Collections.Generic;

namespace Mazica.Domain.MazeFormat
{
	public class MazeGenerator
	{
		private readonly int _x;
		private readonly int _y;
		private readonly int[,] _maze;
		private static readonly Random RAND = new Random();

		public MazeGenerator(int x, int y) {
		this._x = x;
		this._y = y;
		_maze = new int[this._x,this._y];
		generateMaze(0, 0);
	}

		private void generateMaze(int cx, int cy)
		{
			Direction[] directions = Direction.values;
			Shuffle(directions);
			foreach (var dir in directions)
			{
				int nx = cx + dir.dx;
				int ny = cy + dir.dy;
				if (between(nx, _x) && between(ny, _y)
						&& (_maze[nx,ny] == 0))
				{
					_maze[cx,cy] |= dir.bit;
					_maze[nx,ny] |= dir.opposite.bit;
					generateMaze(nx, ny);
				}
			}
		}

		private static bool between(int v, int upper)
		{
			return (v >= 0) && (v < upper);
		}

		public static void Shuffle<T>(IList<T> list)
		{
			Random rng = new Random();
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}