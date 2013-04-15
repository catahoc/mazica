using System.Collections.Generic;
using System.Diagnostics;

namespace MazeGen
{
    internal class Area
    {
        public Point Lower { get; set; }
        public Point Higher { get; set; }
        public int Width {get { return Higher.X - Lower.X; }}
        public int Height {get { return Higher.Y - Lower.Y; }}
        public int Depth {get { return Higher.Z - Lower.Z; }}

        public int Size(Direction d)
        {
            return Higher[d] - Lower[d];
        }

        public Area(Point lower, Point higher)
        {
            Lower = lower;
            Higher = higher;
        }

        public Area(MazeMatrix mazeMatrix)
        {
            Lower = new Point();
            Higher = new Point(mazeMatrix.Width, mazeMatrix.Height, mazeMatrix.Depth);
        }
        public IEnumerable<Area> Split(Direction d, int where)
        {
            var higherClone = Higher.Clone();
            higherClone[d] = @where;
            yield return new Area(Lower, higherClone);

            var lowerClone = Lower.Clone();
            lowerClone[d] = @where;
            yield return new Area(lowerClone, Higher);
        }

        public override string ToString()
        {
            return string.Format("[{0} to {1}]", Lower, Higher);
        }
    }
}