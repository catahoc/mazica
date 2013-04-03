using System.Collections.Generic;
using System.Linq;

namespace Mazica.Domain
{
	public struct MazeArea
	{
		public int FromLon;
		public int ToLon;
		public int FromLat;
		public int ToLat;
		public int FromHei;
		public int ToHei;

		public MazeArea(int toLon, int toLat, int toHei):this(0, toLon, 0, toLat, 0, toHei)
		{
		}
		public MazeArea(int fromLon, int toLon, int fromLat, int toLat, int fromHei, int toHei)
		{
			FromLon = fromLon;
			ToLon = toLon;
			FromLat = fromLat;
			ToLat = toLat;
			ToHei = toHei;
			FromHei = fromHei;
		}

		public bool IsAtomic
		{
			get { throw new System.NotImplementedException(); }
		}

		public IEnumerable<MazeArea> DivideByLon(int value)
		{
			var copy1 = this;
			copy1.ToLon = value;
			yield return copy1;

			var copy2 = this;
			copy2.FromLon = value;
			yield return copy2;
		}

		public IEnumerable<MazeArea> DivideByLat(int value)
		{
			var copy1 = this;
			copy1.ToLat = value;
			yield return copy1;

			var copy2 = this;
			copy2.FromLat = value;
			yield return copy2;
		}

		public IEnumerable<MazeArea> DivideByHei(int value)
		{
			var copy1 = this;
			copy1.ToHei = value;
			yield return copy1;

			var copy2 = this;
			copy2.FromHei = value;
			yield return copy2;
		}

		public IEnumerable<MazeArea> Divide(int lon, int lat, int hei)
		{
			return DivideByLon(lon).Concat(DivideByLat(lat)).Concat(DivideByHei(hei));
		}
	}
}