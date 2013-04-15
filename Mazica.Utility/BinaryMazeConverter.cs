using System;
using System.IO;
using MazeGen;

namespace Mazica.Utility
{
	public class BinaryMazeConverter
	{
		private const string FINGERPRINT = "MazeMatrix-format-v0.1";

		public MazeMatrix FromByteArray(byte[] data)
		{
			var offset = 0;
			var width = BitConverter.ToInt32(data, offset);

			offset += 4;
			var height = BitConverter.ToInt32(data, offset);

			offset += 4;
			var depth = BitConverter.ToInt32(data, offset);

			offset += 4;
			var maze = new MazeMatrix(width, height, depth);
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

		public byte[] ToByteArray(MazeMatrix mazeMatrix)
		{
			var destination = new byte[4 * 3 + mazeMatrix.Depth * mazeMatrix.Height * mazeMatrix.Width];
			Array.Copy(BitConverter.GetBytes(mazeMatrix.Width), 0, destination, 0, 4);
			Array.Copy(BitConverter.GetBytes(mazeMatrix.Height), 0, destination, 4, 4);
			Array.Copy(BitConverter.GetBytes(mazeMatrix.Depth), 0, destination, 8, 4);
			var i = 0;
			for(var x = 0; x < mazeMatrix.Width; x++)
			{
				for(var y = 0; y < mazeMatrix.Height; y++)
				{
					for(var z = 0; z < mazeMatrix.Depth; z++)
					{
						destination[i++] = (byte)mazeMatrix[x, y, z];
					}
				}
			}
			return destination;
		}
	}
}