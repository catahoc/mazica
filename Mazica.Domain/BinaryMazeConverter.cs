using System;
using System.IO;
using MazeGen;

namespace Mazica.Domain
{
	public class BinaryMazeConverter
	{
		private const string FINGERPRINT = "maze-format-v0.1";

		public Maze FromByteArray(byte[] data)
		{
			var offset = 0;
			var width = BitConverter.ToInt32(data, offset);

			offset += 4;
			var height = BitConverter.ToInt32(data, offset);

			offset += 4;
			var depth = BitConverter.ToInt32(data, offset);

			offset += 4;
			var maze = new Maze(width, height, depth);
			for(var x = 0; x < width; x++)
			{
				for(var y = 0; y < height; y++)
				{
					for(var z = 0; z < depth; z++)
					{
						maze[x, y, z] = (Wall)data[offset++];
					}
				}
			}
			
			return maze;
		}

		public byte[] ToByteArray(Maze maze)
		{
			var destination = new byte[4 * 3 + maze.Depth * maze.Height * maze.Width];
			Array.Copy(BitConverter.GetBytes(maze.Width), 0, destination, 0, 4);
			Array.Copy(BitConverter.GetBytes(maze.Height), 0, destination, 4, 4);
			Array.Copy(BitConverter.GetBytes(maze.Depth), 0, destination, 8, 4);
			var i = 0;
			for(var x = 0; x < maze.Width; x++)
			{
				for(var y = 0; y < maze.Height; y++)
				{
					for(var z = 0; z < maze.Depth; z++)
					{
						destination[i++] = (byte)maze[x, y, z];
					}
				}
			}
			return destination;
		}
	}
}