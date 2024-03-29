﻿namespace MazeGen
{
    public class MazeMatrix
    {
        private readonly Wall[,,] _walls;

        public MazeMatrix(Wall[,,] walls)
        {
            _walls = walls;
        }

	    public MazeMatrix(int x, int y, int z)
	    {
		    _walls = new Wall[x,y,z];
	    }
		
	    public Wall[,,] Raw
	    {
		    get { return _walls; }
	    }

	    public Wall this[Point p]
        {
            get { return _walls[p.X, p.Y, p.Z]; }
            set { _walls[p.X, p.Y, p.Z] = value; }
        }
	    public Wall this[int x, int y, int z]
        {
            get { return _walls[x, y, z]; }
            set { _walls[x, y, z] = value; }
        }

        public int Width { get { return _walls.GetLength(0); } }
        public int Height { get { return _walls.GetLength(1); } }
        public int Depth { get { return _walls.GetLength(2); } }
    }
}