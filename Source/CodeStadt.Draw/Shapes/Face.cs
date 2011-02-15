using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeStadt.Draw.Shapes
{
    /// <summary>
    /// A face is the solid side of a shape
    /// </summary>
    public class Face :  IEnumerable<Coordinate3D> 
    {
        public Face(IEnumerable<Coordinate3D> coordinates)
        {
            Coordinates = coordinates;
            Brush = Brushes.Black;
        }
        /// <summary>
        /// The list  of coordinates that represent the corners of the face
        /// </summary>
        public IEnumerable<Coordinate3D> Coordinates { get; private set; }

        public Brush Brush { get; set; }

        #region IEnumerable<Coordinate3D> Members

        public IEnumerator<Coordinate3D> GetEnumerator()
        {
            return Coordinates.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Coordinates.GetEnumerator();
        }

        #endregion
    }

}
