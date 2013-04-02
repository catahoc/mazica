namespace Mazica.Domain
{
	public class MazeArray
	{
		private readonly MazeCellWalls[,,] _source;

		public MazeArray(MazeCellWalls[,,] source)
		{
			_source = source;
		}

		public MazeCellWalls this[int lon, int lat, int hei]
		{
			get { return _source[lon, lat, hei]; }
		}
	}
}