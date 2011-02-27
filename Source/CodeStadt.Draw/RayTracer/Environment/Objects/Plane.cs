namespace CodeStadt.Draw.RayTracer.Environment.Objects
{
    /// <summary>
    /// Represent a flat plane
    /// </summary>
    public class Plane : SceneObject
    {
        /// <summary>
        /// A normal to the plane
        /// </summary>
        public Vector Norm;

        /// <summary>
        /// A point on the plane
        /// </summary>
        public Vector Point;

        /// <summary>
        /// Calculate the point of intersection between the plane and a ray
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <returns>The point of intersection or null</returns>
        public override Intersection Intersect(Ray ray)
        {
            // d = distance
            // p0 = point on the plane
            // l0 = point on the line
            // l = direction of the line
            // n = normal to plane

            // d = (p0 - l0) . n
            //     -------------
            //     (l . n)

            double denominator = Vector.Dot(this.Norm, ray.Direction);

            if (denominator >= 0)
            {
                return null;
            }

            var d = (this.Point - ray.Start).Dot(this.Norm) / denominator;

            // The point of intersection
            return new Intersection()
            {
                Element = this,
                Ray = ray,
                Distance = d
            };
        }

        /// <summary>
        /// Return a normal to the plane at the specified position
        /// </summary>
        /// <param name="position">The position to test</param>
        /// <returns>The normal vector</returns>
        public override Vector Normal(Vector position)
        {
            return this.Norm;
        }
    }
}
