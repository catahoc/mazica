namespace Mazica.Domain.MazeFormat
{
	internal class Direction
	{
		public static Direction[] Values { get; private set; }

		public static Direction North { get; private set; }
		public static Direction South { get; private set; }
		public static Direction East { get; private set; }
		public static Direction West { get; private set; }
		public static Direction Upper { get; private set; }
		public static Direction Lower { get; private set; }

		public MazeCellWalls Bit { get; private set; }
		public int Dx { get; private set; }
		public int Dy { get; private set; }
		public int Dz { get; private set; }
		public Direction Opposite { get; private set; }

		// use the static initializer to resolve forward references
		static Direction()
		{
			North = new Direction(MazeCellWalls.North, 0, -1, 0);
			South = new Direction(MazeCellWalls.South, 0, 1, 0);
			East = new Direction(MazeCellWalls.East, 1, 0, 0);
			West = new Direction(MazeCellWalls.West, -1, 0, 0);
			Upper = new Direction(MazeCellWalls.Upper, 0, 0, -1);
			Lower = new Direction(MazeCellWalls.Lower, 0, 0, 1);

			North.Opposite = South;
			South.Opposite = North;
			East.Opposite = West;
			West.Opposite = East;
			Upper.Opposite = Lower;
			Lower.Opposite = Upper;

			Values = new[] { North, South, East, West, Upper, Lower };
		}

		private Direction(MazeCellWalls bit, int dx, int dy, int dz)
		{
			Bit = bit;
			Dx = dx;
			Dy = dy;
			Dz = dz;
		}
	};
}