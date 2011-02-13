using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStadt.Draw
{
    /// <summary>
    /// This is just a test class to prototype drawing
    /// </summary>
    public class SimpleDrawer
    {


        public static void DrawLine(Graphics img, Coordinate3D start, Coordinate3D end, int screenZ)
        {

            Coordinate2D start2d = ConvertTo2DCoords(start, screenZ);
            Coordinate2D end2d = ConvertTo2DCoords(end, screenZ);

            img.DrawLine(new Pen(Color.Red, 2), start2d, end2d);

        }

        private static  Coordinate2D ConvertTo2DCoords(Coordinate3D coord, int screenZ)
        {
            Coordinate2D coord2d = new Coordinate2D();
            coord2d.X = CalculateScreenX(screenZ, coord);
            coord2d.Y = CalculateScreenY(screenZ, coord);

            return coord2d;
        }

        private static int CalculateScreenX(int screenZ, Coordinate3D point)
        {
            if (point.Z == 0) return point.X;
            return (point.X * screenZ) / point.Z;
        }

        private static int CalculateScreenY(int screenZ, Coordinate3D point)
        {
            if (point.Z == 0) return point.Y;

            return (point.Y * screenZ) / point.Z;
        }

       
    }
}
