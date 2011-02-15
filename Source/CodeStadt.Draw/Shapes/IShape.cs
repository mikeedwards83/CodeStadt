using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStadt.Draw.Shapes
{
    /// <summary>
    /// Represents and instance of shape
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Returns a series of faces that can be rendered to build the shape.
        /// </summary>
        IEnumerable<Face> Faces { get; }
        
    }
}
