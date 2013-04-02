using System;

namespace Mazica.Domain
{
	[Flags]
	public enum MazeCellWalls
	{
		North = 1,
		South = 2,
		East = 4,
		West = 8,
		Upper = 16,
		Lower = 32
	}
}