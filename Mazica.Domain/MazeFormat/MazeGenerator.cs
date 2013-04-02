using System.Collections.Generic;
using Mazica.Utility;

namespace Mazica.Domain.MazeFormat
{
	public class MazeGenerator
	{
		private readonly int _x;
		private readonly int _y;
		private readonly int _z;
		private readonly MazeCellWalls[, ,] _maze;

		private MazeGenerator(int x, int y, int z)
		{
			_x = x;
			_y = y;
			_z = z;
			_maze = new MazeCellWalls[_x, _y, _z];
			GenerateMaze(0, 0, 0);
		}

		private void GenerateMaze(int cx, int cy, int cz)
		{
			var directions = Direction.Values;
			directions.Shuffle();
			foreach (var dir in directions)
			{
				var nx = cx + dir.Dx;
				var ny = cy + dir.Dy;
				var nz = cz + dir.Dz;
				if (Between(nx, _x) && Between(ny, _y) && Between(nz, _z) && (_maze[nx, ny, nz] == 0))
				{
					_maze[cx, cy, nz] |= dir.Bit;
					_maze[nx, ny, nz] |= dir.Opposite.Bit;
					GenerateMaze(nx, ny, nz);
				}
			}
		}

		private static bool Between(int v, int upper)
		{
			return (v >= 0) && (v < upper);
		}

		public static MazeCellWalls[,,] Generate(int x, int y, int z)
		{
			var gen = new MazeGenerator(x, y, z);
			return gen._maze;
		}
	}
}