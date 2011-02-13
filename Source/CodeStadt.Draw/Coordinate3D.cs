using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStadt.Draw
{
    public class Coordinate3D
    {
        public Coordinate3D() { }
        public Coordinate3D(int x, int y, int z) { X = x; Y = y; Z = z; }


        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }


    }
}
