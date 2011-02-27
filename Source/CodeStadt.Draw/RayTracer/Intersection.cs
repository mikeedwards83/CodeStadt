namespace CodeStadt.Draw.RayTracer
{
    using System;
    using CodeStadt.Draw.RayTracer.Environment.Objects;

    /// <summary>
    /// Represent a point of intersection between a ray and an object in the scence
    /// </summary>
    public class Intersection : IComparable
    {
        /// <summary>
        /// The scene object the ray intersects with
        /// </summary>
        public SceneObject Element { get; set; }

        /// <summary>
        /// The ray being traced
        /// </summary>
        public Ray Ray { get; set; }

        /// <summary>
        /// The distance from the start of the ray to 
        /// the point of intersection
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Comparision for IComparable interface
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            var isect = obj as Intersection;
            return (int)(this.Distance - isect.Distance);
        }
    }
}
