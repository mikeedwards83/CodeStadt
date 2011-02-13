using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStadt.Draw
{
    public class AdvancedDrawer
    {

        public static void DrawLine(Graphics img, Coordinate3D start, Coordinate3D end, Coordinate3D viewPoint, int screenZ)
        {

            Coordinate2D start2d = ConvertTo2DCoords(start,viewPoint, screenZ);
            Coordinate2D end2d = ConvertTo2DCoords(end, viewPoint, screenZ);

            img.DrawLine(new Pen(Color.Red, 2), start2d, end2d);

        }

        public static void DrawSquare(Graphics img, Coordinate3D topLeft, Coordinate3D topRight, Coordinate3D bottomLeft, Coordinate3D bottomRight, Coordinate3D viewPoint, int screenZ)
        {
            Coordinate2D tl2d = ConvertTo2DCoords(topLeft, viewPoint, screenZ);
            Coordinate2D tr2d = ConvertTo2DCoords(topRight, viewPoint, screenZ);
            Coordinate2D bl2d = ConvertTo2DCoords(bottomLeft, viewPoint, screenZ);
            Coordinate2D br2d = ConvertTo2DCoords(bottomRight, viewPoint, screenZ);

            img.FillPolygon(Brushes.RoyalBlue, new Point[] { tl2d, tr2d, bl2d, br2d });



        }

        private static Coordinate2D ConvertTo2DCoords(Coordinate3D point, Coordinate3D viewPoint, int screenZ)
        {
            Coordinate2D coord2D = new Coordinate2D();
            coord2D.X = CalculateScreenX(point, viewPoint, screenZ);
            coord2D.Y = CalculateScreenY(point, viewPoint, screenZ);

            return coord2D;
        }


        private static int CalculateScreenX(Coordinate3D point, Coordinate3D viewPoint, int screenZ)
        {
            return (((point.X - viewPoint.X) * (screenZ - viewPoint.Z)) / (point.Z * viewPoint.Z)) + viewPoint.X;
        }

        private static int CalculateScreenY(Coordinate3D point, Coordinate3D viewPoint, int screenZ)
        {
            return (((point.Y - viewPoint.Y) * (screenZ - viewPoint.Z)) / (point.Z * viewPoint.Z))  +viewPoint.Y;
        }


        

    }
}
