using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStadt.Draw.RayTracer.Environment
{
    public class Screen
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Screen(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
