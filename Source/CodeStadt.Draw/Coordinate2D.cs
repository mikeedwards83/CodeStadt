using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStadt.Draw
{
    public class Coordinate2D
    {
        public Coordinate2D() { }
        public Coordinate2D(int x, int y) { X = x; Y = y; }
        
        public int X { get; set; }
        public int Y { get; set; }

        public static implicit operator Point(Coordinate2D coord)
        {
            return new Point(coord.X, coord.Y);
        }

    }
}
