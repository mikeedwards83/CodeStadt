using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStadt.Draw
{
    public class AdvancedDrawer
    {
        int _screenZ;
        Coordinate3D _viewPoint;
        Graphics _img;

        public AdvancedDrawer(
            int screenZ,
            Coordinate3D viewPoint,
            Graphics img)
        {
            _screenZ = screenZ;
            _viewPoint = viewPoint;
            _img = img;
        }



        public void DrawLine(Coordinate3D start, Coordinate3D end)
        {

            Coordinate2D start2d = ConvertTo2DCoords(start,_viewPoint, _screenZ);
            Coordinate2D end2d = ConvertTo2DCoords(end, _viewPoint, _screenZ);

            _img.DrawLine(new Pen(Color.Red, 2), start2d, end2d);

        }

        

        public void DrawFilledPolygon(Brush brush, params Coordinate3D [] points)
        {
            List<Coordinate2D> coords = new List<Coordinate2D>();
            foreach (var point in points)
            {
                coords.Add(ConvertTo2DCoords(point, _viewPoint, _screenZ));
            }

            _img.FillPolygon(brush, coords.Select(x=> (Point) x).ToArray());

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
            //not sure if this is correct
            if (point.Z == 0 || viewPoint.Z == 0) return point.X;

            return (((point.X - viewPoint.X) * (screenZ - viewPoint.Z)) / (point.Z * viewPoint.Z)) + viewPoint.X;
        }

        private static int CalculateScreenY(Coordinate3D point, Coordinate3D viewPoint, int screenZ)
        {
            //not sure if this is correct
            if (point.Z == 0 || viewPoint.Z == 0) return point.Y;

            return (((point.Y - viewPoint.Y) * (screenZ - viewPoint.Z)) / (point.Z * viewPoint.Z))  +viewPoint.Y;
        }


        

    }
}
