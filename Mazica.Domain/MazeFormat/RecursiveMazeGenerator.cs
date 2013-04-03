using System;
using System.Collections.Generic;
using System.Linq;
using Mazica.Utility;

namespace Mazica.Domain
{
	public class RecursiveMazeGenerator
	{
		private readonly Random _rand = new Random();

		public MazeArray Generate(int lonSize, int latSize, int heiSize)
		{
			var maze = new MazeCellWalls[lonSize,latSize,heiSize];
			var area = new MazeArea(lonSize, latSize, heiSize);
			Process(maze, area);
			return new MazeArray(maze);
		}

		public void Process(MazeCellWalls[,,] maze, MazeArea area)
		{
			var processors = new List<Func<MazeCellWalls[, ,], MazeArea, IEnumerable<MazeArea>>>();
			if (area.ToLon - area.FromLon > 1) processors.Add(ProcessLon);
			if (area.ToLat - area.FromLat > 1) processors.Add(ProcessLat);
			if (area.ToHei - area.FromHei > 1) processors.Add(ProcessHei);
			if (processors.Any()) processors.Random()(maze, area);
		}

		private IEnumerable<MazeArea> ProcessLon(MazeCellWalls[,,] maze, MazeArea area)
		{
			var lon = _rand.Next(area.FromLon + 1, area.ToLon);
			var lat = _rand.Next(area.FromLat, area.ToLat);
			var hei = _rand.Next(area.FromHei, area.ToHei);
			maze[lon - 1, lat, hei] |= MazeCellWalls.East;
			maze[lon, lat, hei] |= MazeCellWalls.West;
			return area.DivideByLon(lon);
		}

		private IEnumerable<MazeArea> ProcessLat(MazeCellWalls[, ,] maze, MazeArea area)
		{
			var lat = _rand.Next(area.FromLat + 1, area.ToLat);
			var lon = _rand.Next(area.FromLon, area.ToLon);
			var hei = _rand.Next(area.FromHei, area.ToHei);
			maze[lon, lat - 1, hei] |= MazeCellWalls.North;
			maze[lon, lat, hei] |= MazeCellWalls.South;
			return area.DivideByLat(lat);
		}

		private IEnumerable<MazeArea> ProcessHei(MazeCellWalls[, ,] maze, MazeArea area)
		{
			var hei = _rand.Next(area.FromHei + 1, area.ToHei);
			var lat = _rand.Next(area.FromLat, area.ToLat);
			var lon = _rand.Next(area.FromLon, area.ToLon);
			maze[lon, lat, hei - 1] |= MazeCellWalls.Upper;
			maze[lon, lat, hei] |= MazeCellWalls.Lower;
			return area.DivideByHei(hei);
		}
	}
}