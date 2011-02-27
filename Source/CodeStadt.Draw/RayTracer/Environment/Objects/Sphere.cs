namespace CodeStadt.Draw.RayTracer.Environment.Objects
{
    using System;

    /// <summary>
    /// Represent a sphere
    /// </summary>
    public class Sphere : SceneObject
    {
        /// <summary>
        /// The center of the sphere
        /// </summary>
        public Vector Center { get; set; }

        /// <summary>
        /// The radius of the sphere
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Calculate an intersection between the ray and the sphere
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <returns>The point of intersection or null</returns>
        public override Intersection Intersect(Ray ray)
        {
            // Direction from start of ray to center of sphere
            Vector dirToCenter = this.Center - ray.Start;

            // Cosine of angle between center ray and ray's direction
            double v = Vector.Dot(dirToCenter, ray.Direction);
            double distance;

            // Is the angle greater-equal 90deg (therefore intersection not possible)
            if (v < 0)
            {
                distance = 0;
            }
            else
            {
                double disc = Math.Pow(Radius, 2) - (Vector.Dot(dirToCenter, dirToCenter) - Math.Pow(v, 2));
                distance = disc < 0 ? 0 : v - Math.Sqrt(disc);
            }

            // We didnt intersect the object, so return null
            if (distance == 0)
            {
                return null;
            }

            // Return the point of intersection
            return new Intersection()
            {
                Element = this,
                Ray = ray,
                Distance = distance
            };
        }

        /// <summary>
        /// Calculate the normal to the surface of the sphere at the given position
        /// </summary>
        /// <param name="position">The position on the surface</param>
        /// <returns>The normal vector</returns>
        public override Vector Normal(Vector position)
        {
            return (position - this.Center).Normalise;
        }
    }
}
