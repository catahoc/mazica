using MazeGen;
using Mazica.WebObjects;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mazica.Tests
{
	[TestFixture]
	public class JsonTests
	{
		[Test]
		public void TestMazeJsonEncoding()
		{
			var gen = new RecursiveMazeGenerator(3, 3, 3);
			var maze = gen.Generate();
			var jsonMaze = new JsonMaze(maze);
			var jsonData = JsonConvert.SerializeObject(jsonMaze);
			Assert.NotNull(jsonData);
		}
	}
}