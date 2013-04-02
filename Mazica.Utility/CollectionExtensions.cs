using System;
using System.Collections.Generic;

namespace Mazica.Utility
{
    public static class CollectionExtensions
    {
		public static void Shuffle<T>(this IList<T> list)
		{
			var rnd = new Random();
			var n = list.Count;
			while (n > 1)
			{
				n--;
				var k = rnd.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
    }
}
