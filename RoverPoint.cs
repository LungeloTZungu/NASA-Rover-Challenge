using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_Rover_challenge
{
   
        public class RoverPoint
        {
            public int X { get; set; }
            public int Y { get; set; }

            public RoverPoint(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                if (obj is RoverPoint other)
                    return X == other.X && Y == other.Y;
                return false;
            }

            public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);

        }
    }
}
