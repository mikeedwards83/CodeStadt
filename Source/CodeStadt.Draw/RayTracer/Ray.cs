namespace CodeStadt.Draw.RayTracer
{
    /// <summary>
    /// Represent the parameters of a ray
    /// </summary>
    public class Ray
    {
        /// <summary>
        /// The start co-ordinate of the ray in 3D space
        /// </summary>
        public Vector Start { get; set; }

        /// <summary>
        /// The direction of the ray
        /// </summary>
        public Vector Direction { get; set; }
    }
}
