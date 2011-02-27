namespace CodeStadt.Draw.RayTracer.Environment.Objects
{
    /// <summary>
    /// Abstract class to represent an arbitrary element in the scene
    /// </summary>
    public abstract class SceneObject
    {
        /// <summary>
        /// The surface quality of the scene object
        /// </summary>
        public Surface Surface;

        /// <summary>
        /// Perform an intersection test between the ray and the object
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <returns>The intersection or null</returns>
        public abstract Intersection Intersect(Ray ray);

        /// <summary>
        /// Calculate a normal to the surface as the position
        /// </summary>
        /// <param name="pos">The position on the surface</param>
        /// <returns>The normal vector</returns>
        public abstract Vector Normal(Vector pos);
    }
}
