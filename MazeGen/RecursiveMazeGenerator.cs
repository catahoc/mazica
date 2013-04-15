using System;

namespace MazeGen
{
    public class RecursiveMazeGenerator: MazeGeneratorBase
    {
        public RecursiveMazeGenerator(int width, int height, int depth)
            :base(width, height, depth)
        {
        }

        public override MazeMatrix Generate()
        {
            var result = GetFull();
            var area = new Area(result);
            Visit(result, area);
            return result;
        }

        private void Visit(MazeMatrix result, Area area)
        {
            var w = area.Width - 1;
            var h = area.Height - 1;
            var d = area.Depth - 1;
            if (w + h + d != 0)
            {
                var rand = Rand.Next(w + h + d);

                if (rand < w)
                    Divide(result, area, Direction.X);
                else if (rand < h + w)
                    Divide(result, area, Direction.Y);
                else
                    Divide(result, area, Direction.Z);
            }
        }

        private void Divide(MazeMatrix result, Area area, Direction d)
        {
            var whereMakeHole = new Point();
            var dx = NominalRand(area.Size(d) - 1) + area.Lower[d] + 1;
            whereMakeHole[d] = dx;
            foreach (var od in d.Others())
            {
                whereMakeHole[od] = Rand.Next(area.Lower[od], area.Higher[od]);
            }
            result[whereMakeHole] ^= d.LowerWall();
            result[whereMakeHole.Prev(d)] ^= d.HigherWall();
            foreach (var subarea in area.Split(d, dx))
            {
                Visit(result, subarea);
            }
        }

        private int PossibilitySum(int count)
        {
            if (count%2 == 1)
            {
                var tosqr = (count + 1)/2;
                return tosqr * tosqr;
            }
            else
            {
                var tosqr = count/2;
                return tosqr*(tosqr + 1);
            }
        }

        private int NominalRand(int max)
        {
            var maxrand = PossibilitySum(max);
            var allsum = maxrand;
            var array = new int[max];
            var i = 0;
            while (true)
            {
                var toadd = ++i;
                array[i-1] = toadd;
                allsum -= toadd;
                if (allsum == 0) break;
                array[max - i] = toadd;
                allsum -= toadd;
                if (allsum == 0) break;
            }
            var rand = Rand.Next(maxrand);
            var j = 0;
            while (rand >= array[j])
            {
                rand -= array[j++];
            }
            return j;
        }
    }
}