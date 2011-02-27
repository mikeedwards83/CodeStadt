namespace CodeStadt.Draw.RayTracer.Environment
{
    using System;

    /// <summary>
    /// Represent the characteristics of a surface
    /// </summary>
    public class Surface
    {
        /// <summary>
        /// The diffuse reflection quality of the surface at a given location
        /// </summary>
        /// <remarks>
        /// Diffuse reflection is the reflection of light from a surface such that an 
        /// incident ray is reflected at many angles rather than at just one angle as 
        /// in the case of specular reflection.
        /// </remarks>
        public Func<Vector, Color> Diffuse { get; set; }

        /// <summary>
        /// The specular reflection quality of the surface at a given location
        /// </summary>
        /// <remarks>
        /// Specular reflection is the mirror-like reflection of light (or of other kinds of wave) 
        /// from a surface, in which light from a single incoming direction (a ray) is reflected 
        /// into a single outgoing direction
        /// </remarks>
        public Func<Vector, Color> Specular { get; set; }

        /// <summary>
        /// The reflectiveness of the surface at a given location
        /// </summary>
        public Func<Vector, double> Reflectiveness { get; set; }

        /// <summary>
        /// The roughness of the surface
        /// </summary>
        public double Roughness { get; set; }
    }
}
