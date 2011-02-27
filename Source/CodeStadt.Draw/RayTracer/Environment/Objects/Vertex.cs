using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStadt.Draw.RayTracer.Environment.Objects
{
    [System.Diagnostics.DebuggerDisplay("X = {X}, Y = {Y}")]
    public class Vertex
    {
        public double X;
        public double Y;

        public Vertex()
        {
        }

        public Vertex(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
