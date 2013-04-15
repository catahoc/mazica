using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazica.Domain;
using NUnit.Framework;

namespace Mazica.Tests
{
	[TestFixture]
    public class PathFinder
    {
		const int size = 10;
		public bool IsEnd(Position pos)
		{
			var items = new[] {pos.Lon, pos.Lat, pos.Hei};
			return items.All(t => t == size - 1);
		}

		public void TestManyGeneratedAlgorithms()
		{
			var generator = new RecursiveMazeGenerator();
			var maze = generator.Generate(size, size, size);
			var flags = new и[size,size,size];
			var position = new Position();
			while (!IsEnd(position))
			{
				
			}
		}
    }
}
