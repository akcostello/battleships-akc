using ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public class ShipLocations
    {
        public List<Coordinates> coordinates { get; set; } = new List<Coordinates>();
        public bool isSunk => coordinates.Where(x => x.isHit == true).ToList().Count == coordinates.Count;

        public bool isVertical { get; set; }

        public void TryHit(string guess)
       {
            var xcoord = guess.SplitFirstInt();
            var ycoord = guess.SplitLastInt();

            var hit = coordinates.Where(x => x.xCoord == xcoord && x.yCoord == ycoord).FirstOrDefault();

            if (hit != null) hit.isHit = true;
        }

        public void PopulateCoordinates(string coords)
        {
            var b = coords.Split(',');

            var startPt = b.First();
            var endPt = b.Last();

            int xstart = startPt.SplitFirstInt();   // split string on ';' and convert to int
            int ystart = startPt.SplitLastInt();
            int xend = endPt.SplitFirstInt();
            int yend = endPt.SplitLastInt();

            
            isVertical = xstart == xend;    // x coords all the same, only y coords change

            var max = isVertical ? yend - ystart : xend - xstart;
            SetCoordinates(xstart, ystart, max, isVertical);

        }


        private void SetCoordinates(int xstart, int ystart, int max, bool isVertical)
        {
            for (int i = 0; i <= max; i++)
            {
                if (isVertical)

                {
                    coordinates.Add(new Coordinates { xCoord = xstart, yCoord = ystart + i });
                }
                else
                {
                    coordinates.Add(new Coordinates { xCoord = xstart + i, yCoord = ystart });
                }
            }
        }
    }
}
