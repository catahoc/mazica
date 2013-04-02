namespace Mazica.Domain.MazeFormat
{
	internal class Direction
	{
		public static readonly Direction North;
		public static readonly Direction South;
		public static readonly Direction East;
		public static readonly Direction West;
		public static readonly Direction[] values;

		public readonly int bit;
		public readonly int dx;
		public readonly int dy;
		public Direction opposite;

		// use the static initializer to resolve forward references
		static Direction()
		{
			North = new Direction(1, 0, -1);
			South = new Direction(2, 0, 1);
			East = new Direction(4, 1, 0);
			West = new Direction(8, -1, 0);

			North.opposite = South;
			South.opposite = North;
			East.opposite = West;
			West.opposite = East;
			values = new[] { North, South, East, West };
		}

		private Direction(int bit, int dx, int dy)
		{
			this.bit = bit;
			this.dx = dx;
			this.dy = dy;
		}
	};
}