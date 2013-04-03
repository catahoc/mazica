namespace Mazica.Domain
{
	public class MazeUtils
	{
		public static void FillBorderWalls(MazeCellWalls[,,] maze, int lonSize, int latSize, int heiSize)
		{
			for (int lon = 0; lon < lonSize; lon++)
			{
				for (int lat = 0; lat < latSize; lat++)
				{
					for (int hei = 0; hei < heiSize; hei++)
					{
						if (lon == 0)
							maze[lon, lat, hei] |= MazeCellWalls.West;
						if (lon == lonSize - 1)
							maze[lon, lat, hei] |= MazeCellWalls.East;

						if (lat == 0)
							maze[lon, lat, hei] |= MazeCellWalls.South;
						if (lat == latSize - 1)
							maze[lon, lat, hei] |= MazeCellWalls.North;

						if (hei == 0)
							maze[lon, lat, hei] |= MazeCellWalls.Lower;
						if (hei == heiSize - 1)
							maze[lon, lat, hei] |= MazeCellWalls.Upper;
					}
				}
			}
		}
	}
}