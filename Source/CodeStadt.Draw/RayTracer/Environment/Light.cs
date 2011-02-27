namespace CodeStadt.Draw.RayTracer.Environment
{
    /// <summary>
    /// Represent a light source in the scene
    /// </summary>
    public class Light
    {
        /// <summary>
        /// The positition of the light source
        /// </summary>
        public Vector Position { get; set; }

        /// <summary>
        /// The color of the light source
        /// </summary>
        public Color Color { get; set; }
    }
}
