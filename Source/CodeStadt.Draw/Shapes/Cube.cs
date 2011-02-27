using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStadt.Draw.Shapes
{
    public class Cube : IShape
    {
        public Coordinate3D FrontBottomLeft { private set; get; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        public Cube(Coordinate3D frontBottomLeft, int width, int height, int depth)
        {
            FrontBottomLeft = frontBottomLeft;
            Width = width;
            Height = height;
            Depth = depth;

            Faces = GenerateFaces(FrontBottomLeft, width, height, depth);
        }

        private static IEnumerable<Face> GenerateFaces(Coordinate3D frontBottomLeft, int width, int height, int depth)
        {
            //create corners
            Coordinate3D frontBottomRight = new Coordinate3D(frontBottomLeft.X + width, frontBottomLeft.Y, frontBottomLeft.Z);
            Coordinate3D frontTopLeft = new Coordinate3D(frontBottomLeft.X, frontBottomLeft.Y+height, frontBottomLeft.Z);
            Coordinate3D frontTopRight = new Coordinate3D(frontBottomLeft.X + width, frontBottomLeft.Y + height, frontBottomLeft.Z);

            Coordinate3D backBottomLeft = new Coordinate3D(frontBottomLeft.X, frontBottomLeft.Y, frontBottomLeft.Z + depth);
            Coordinate3D backBottomRight = new Coordinate3D(frontBottomLeft.X + width, frontBottomLeft.Y, frontBottomLeft.Z+depth);
            Coordinate3D backTopLeft = new Coordinate3D(frontBottomLeft.X, frontBottomLeft.Y + height, frontBottomLeft.Z+depth);
            Coordinate3D backTopRight = new Coordinate3D(frontBottomLeft.X + width, frontBottomLeft.Y + height, frontBottomLeft.Z+depth);


            List<Face> faces = new List<Face>();
            
            //faces are drawn in the order specified, therefore they should be drawn back to front but then maybe top down,
            //however if the view point changes then the order of rendering needs to change? how do we cope with this?
            
            //back
            faces.Add(new Face(new Coordinate3D[] { backBottomLeft, backBottomRight, backTopRight, backTopLeft }) { Brush = Brushes.Beige });
            //right
            faces.Add(new Face(new Coordinate3D[] { frontBottomLeft, frontTopLeft, backTopLeft, backBottomLeft }) { Brush = Brushes.Orange });
            
            
            //base
            faces.Add(new Face(new Coordinate3D[] { frontBottomLeft, frontBottomRight, backBottomRight, backBottomLeft }) { Brush = Brushes.Blue });
            //top
            faces.Add(new Face(new Coordinate3D[] { frontTopLeft, frontTopRight, backTopRight, backTopLeft }) { Brush = Brushes.DarkGreen });
            //left
            faces.Add(new Face(new Coordinate3D[] { frontBottomRight, frontTopRight, backTopRight, backBottomRight }) { Brush = Brushes.Red });
            //front
            faces.Add(new Face(new Coordinate3D[] { frontBottomLeft, frontBottomRight, frontTopRight, frontTopLeft }) { Brush = Brushes.Azure });
            
            return faces;

        }
        



        #region IShape Members

        public IEnumerable<Face> Faces
        {
            get;
            private set;
        }

        #endregion
    }
}
