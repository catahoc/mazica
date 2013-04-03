using System;
using System.Collections.Generic;
using System.Linq;
using Mazica.Utility;

namespace Mazica.Domain
{
	public class RecursiveMazeGenerator
	{
		private readonly Random _rand = new Random();

		public MazeCellWalls[, ,] Generate(int lonSize, int latSize, int heiSize)
		{
			var maze = new MazeCellWalls[lonSize,latSize,heiSize];
			var area = new MazeArea(lonSize, latSize, heiSize);
			Process(maze, area);
			return maze;
		}

		public void Process(MazeCellWalls[,,] maze, MazeArea area)
		{
			var processors = new List<Func<MazeCellWalls[, ,], MazeArea, IEnumerable<MazeArea>>>();
			if (area.ToLon - area.FromLon > 1) processors.Add(ProcessLon);
			if (area.ToLat - area.FromLat > 1) processors.Add(ProcessLat);
			if (area.ToHei - area.FromHei > 1) processors.Add(ProcessHei);
			if (processors.Any())
			{
				var processor = processors.Random();
				var subareas = processor(maze, area);
				foreach (var subArea in subareas)
				{
					Process(maze, subArea);
				}
			}
		}

		private IEnumerable<MazeArea> ProcessLon(MazeCellWalls[,,] maze, MazeArea area)
		{
			var lon = _rand.Next(area.FromLon + 1, area.ToLon);
			var lat = _rand.Next(area.FromLat, area.ToLat);
			var hei = _rand.Next(area.FromHei, area.ToHei);
			for (var lati = area.FromLat; lati < area.ToLat; lati++)
			{
				for (var heii = area.FromHei; heii < area.ToHei; heii++)
				{
					if (heii != hei || lati != lat)
					{
						maze[lon - 1, lati, heii] |= MazeCellWalls.East;
						maze[lon, lati, heii] |= MazeCellWalls.West;
					}
				}
			}
			return area.DivideByLon(lon);
		}

		private IEnumerable<MazeArea> ProcessLat(MazeCellWalls[, ,] maze, MazeArea area)
		{
			var lat = _rand.Next(area.FromLat + 1, area.ToLat);
			var lon = _rand.Next(area.FromLon, area.ToLon);
			var hei = _rand.Next(area.FromHei, area.ToHei);
			for (var loni = area.FromLon; loni < area.ToLon; loni++)
			{
				for (var heii = area.FromHei; heii < area.ToHei; heii++)
				{
					if (heii != hei || loni != lon)
					{
						maze[loni, lat - 1, heii] |= MazeCellWalls.North;
						maze[loni, lat, heii] |= MazeCellWalls.South;
					}
				}
			}
			return area.DivideByLat(lat);
		}

		private IEnumerable<MazeArea> ProcessHei(MazeCellWalls[, ,] maze, MazeArea area)
		{
			var hei = _rand.Next(area.FromHei + 1, area.ToHei);
			var lat = _rand.Next(area.FromLat, area.ToLat);
			var lon = _rand.Next(area.FromLon, area.ToLon);
			for (var loni = area.FromLon; loni < area.ToLon; loni++)
			{
				for (var lati = area.FromLat; lati < area.ToLat; lati++)
				{
					if (lati != lat || loni != lon)
					{
						maze[loni, lati, hei - 1] |= MazeCellWalls.Upper;
						maze[loni, lati, hei] |= MazeCellWalls.Lower;
					}
				}
			}
			return area.DivideByHei(hei);
		}
	}
}