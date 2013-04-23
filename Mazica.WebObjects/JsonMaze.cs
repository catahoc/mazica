using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGen;

namespace Mazica.WebObjects
{
    public class JsonMaze
    {
		public Wall[, ,] Matrix { get; set; }

		public long Width { get; set; }

		public long Height { get; set; }

		public long Depth { get; set; }


		public JsonMaze(MazeMatrix maze)
		{
			Matrix = maze.Raw;
			Width = maze.Width;
			Height = maze.Height;
			Depth = maze.Depth;
		}
    }
}
