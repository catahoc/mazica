using System;
using Mazica.Domain;

namespace Mazica.Tests.Cmd
{
	public class SimpleMazeGame
	{
		private const int SIZE = 4;
		private const int CELL_W = 4;
		private const int CELL_H = 2;
		private const char WALL_CHAR = '#';
		private const char CAN_UP_CHAR = '↑';
		private const char CAN_DOWN_CHAR = '↓';
		private const char CAN_BOTH_CHAR = '↕';
		private const char CANNOT_CHAR = ' ';
		private const char ME_CHAR = 'O';

		private int _lon = 0;
		private int _lat = 0;
		private int _hei = 0;

		private char[,] _chars = new char[SIZE * (CELL_W + 1) + 1, SIZE * (CELL_H + 1) + 1];

		public void Play()
		{
			var maze = MazeGenerator.Generate(SIZE, SIZE, SIZE);
			ConsoleKey key;
			do
			{
				Console.Clear();
				Console.ReadKey();
				Console.WriteLine("{1}:{2}, level {0}:", _hei, _lon, _lat);
				for (var lon = 0; lon < SIZE; lon++)
				{
					for (var lat = 0; lat < SIZE; lat++)
					{
						var cell = maze[lon, lat, _hei];
						var lonPixel = lon * (CELL_W + 1);
						var latPixel = (SIZE - lat - 1) * (CELL_H + 1);
						if (cell.HasFlag(MazeCellWalls.North))
						{
							for (var dlon = 0; dlon < CELL_W + 2; dlon++)
							{
								_chars[lonPixel + dlon, latPixel] = WALL_CHAR;
							}
						}
						if (cell.HasFlag(MazeCellWalls.South))
						{
							for (var dlon = 0; dlon < CELL_W + 2; dlon++)
							{
								_chars[lonPixel + dlon, latPixel + CELL_H + 1] = WALL_CHAR;
							}
						}
						if (cell.HasFlag(MazeCellWalls.West))
						{
							for (var dlat = 0; dlat < CELL_H + 2; dlat++)
							{
								_chars[lonPixel, latPixel + dlat] = WALL_CHAR;
							}
						}
						if (cell.HasFlag(MazeCellWalls.East))
						{
							for (var dlat = 0; dlat < CELL_H + 2; dlat++)
							{
								_chars[lonPixel + CELL_W + 1, latPixel + dlat] = WALL_CHAR;
							}
						}
						var canup = !cell.HasFlag(MazeCellWalls.Upper);
						var candown = !cell.HasFlag(MazeCellWalls.Lower);
						var canboth = canup && candown;
						char fillChar;
						if (canboth) fillChar = CAN_BOTH_CHAR;
						else if (candown) fillChar = CAN_DOWN_CHAR;
						else if (canup) fillChar = CAN_UP_CHAR;
						else fillChar = CANNOT_CHAR;
						for (var dlon = 0; dlon < CELL_W; dlon++)
						{
							for (int dlat = 0; dlat < CELL_H; dlat++)
							{
								_chars[lonPixel + dlon + 1, latPixel + dlat + 1] = fillChar;
							}
						}
						if (_lon == lon && _lat == lat)
						{
							_chars[lonPixel + 1, latPixel + 1] = ME_CHAR;
						}
					}
				}
				Print(_chars);
				key = Console.ReadKey().Key;
				switch (key)
				{
					case ConsoleKey.A:
						if((_lon > 0) && (!maze[_lon, _lat, _hei].HasFlag(MazeCellWalls.West)))
							_lon--;
						break;
					case ConsoleKey.D:
						if ((_lon < SIZE - 1) && (!maze[_lon, _lat, _hei].HasFlag(MazeCellWalls.East)))
							_lon++;
						break;

					case ConsoleKey.S:
						if ((_lat > 0) && (!maze[_lon, _lat, _hei].HasFlag(MazeCellWalls.South)))
							_lat--;
						break;
					case ConsoleKey.W:
						if ((_lat < SIZE - 1) && (!maze[_lon, _lat, _hei].HasFlag(MazeCellWalls.North)))
							_lat++;
						break;

					case ConsoleKey.DownArrow:
						if ((_hei > 0) && (!maze[_lon, _lat, _hei].HasFlag(MazeCellWalls.Lower)))
							_hei--;
						break;
					case ConsoleKey.UpArrow:
						if ((_hei < SIZE - 1) && (!maze[_lon, _lat, _hei].HasFlag(MazeCellWalls.Upper)))
							_hei++;
						break;
				}
			} while (key != ConsoleKey.Escape);
		}

		public void Print(char[,] array)
		{
			var lonLength = array.GetLength(0);
			var latLength = array.GetLength(1);
			for (var lat = 0; lat < latLength; lat++)
			{
				for (var lon = 0; lon < lonLength; lon++)
				{
					Console.Write(array[lon, lat]);
				}
				Console.WriteLine();
			}
		}
	}
}