namespace MazeGen
{
    public class Maze
    {
        private readonly Wall[,,] _walls;

        public Maze(Wall[,,] walls)
        {
            _walls = walls;
        }

        public Wall this[Point p]
        {
            get { return _walls[p.X, p.Y, p.Z]; }
            set { _walls[p.X, p.Y, p.Z] = value; }
        }

        public int Width { get { return _walls.GetLength(0); } }
        public int Height { get { return _walls.GetLength(1); } }
        public int Depth { get { return _walls.GetLength(2); } }
    }
}