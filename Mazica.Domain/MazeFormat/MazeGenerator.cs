using System.Collections.Generic;
using Mazica.Utility;

namespace Mazica.Domain
{
	public class MazeGenerator
	{
		private readonly int _lon;
		private readonly int _lat;
		private readonly int _hei;
		private readonly MazeCellWalls[, ,] _maze;

		private MazeGenerator(int lon, int lat, int hei)
		{
			_lon = lon;
			_lat = lat;
			_hei = hei;
			_maze = new MazeCellWalls[_lon, _lat, _hei];
			GenerateMaze(0, 0, 0);
		}

		private void GenerateMaze(int clon, int clat, int chei)
		{
			var directions = Direction.Values;
			directions.Shuffle();
			foreach (var dir in directions)
			{
				var nlon = clon + dir.DeltaLon;
				var nlat = clat + dir.DeltaLat;
				var nhei = chei + dir.DeltaHei;
				if (Between(nlon, _lon) && Between(nlat, _lat) && Between(nhei, _hei) && (_maze[nlon, nlat, nhei] == 0))
				{
					_maze[clon, clat, nhei] |= dir.Bit;
					_maze[nlon, nlat, nhei] |= dir.Opposite.Bit;
					GenerateMaze(nlon, nlat, nhei);
				}
			}
		}

		private static bool Between(int v, int upper)
		{
			return (v >= 0) && (v < upper);
		}

		public static MazeArray Generate(int lonSize, int latSize, int heiSize)
		{
			var gen = new MazeGenerator(lonSize, latSize, heiSize);
			var maze = gen._maze;
			for (int lon = 0; lon < lonSize; lon++)
			{
				for (int lat = 0; lat < latSize; lat++)
				{
					for (int hei = 0; hei < heiSize; hei++)
					{
						if (lon == 0)
							maze[lon, lat, hei] |= MazeCellWalls.West;
						else
						{
							if(maze[lon - 1, lat, hei].HasFlag(MazeCellWalls.East))
								maze[lon, lat, hei] |= MazeCellWalls.West;
							if(maze[lon, lat, hei].HasFlag(MazeCellWalls.West))
								maze[lon - 1, lat, hei] |= MazeCellWalls.East;
						}
						if (lon == lonSize-1) 
							maze[lon, lat, hei] |= MazeCellWalls.East;

						if (lat == 0) 
							maze[lon, lat, hei] |= MazeCellWalls.South;
						else
						{
							if (maze[lon, lat - 1, hei].HasFlag(MazeCellWalls.North))
								maze[lon, lat, hei] |= MazeCellWalls.South;
							if (maze[lon, lat, hei].HasFlag(MazeCellWalls.South))
								maze[lon, lat - 1, hei] |= MazeCellWalls.North;
						}
						if (lat == latSize - 1) 
							maze[lon, lat, hei] |= MazeCellWalls.North;

						if (hei == 0) 
							maze[lon, lat, hei] |= MazeCellWalls.Lower;
						else
						{
							if (maze[lon, lat, hei - 1].HasFlag(MazeCellWalls.Upper))
								maze[lon, lat, hei] |= MazeCellWalls.Lower;
							if (maze[lon, lat, hei].HasFlag(MazeCellWalls.Lower))
								maze[lon, lat, hei - 1] |= MazeCellWalls.Upper;
						}
						if (hei == heiSize - 1) 
							maze[lon, lat, hei] |= MazeCellWalls.Upper;
					}
				}
			}
			return new MazeArray(maze);
		}
	}
}