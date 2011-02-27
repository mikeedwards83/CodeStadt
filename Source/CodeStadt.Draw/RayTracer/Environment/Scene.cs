namespace CodeStadt.Draw.RayTracer.Environment
{
    using System.Collections.Generic;
    using System.Linq;
    using CodeStadt.Draw.RayTracer.Environment.Objects;

    /// <summary>
    /// Represent the scene: objects, lighting and camera.
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// The objects in the scene
        /// </summary>
        public SceneObject[] Elements { get; set; }

        /// <summary>
        /// The lights in the world
        /// </summary>
        public Light[] Lights { get; set; }

        /// <summary>
        /// The camera position
        /// </summary>
        public Camera Camera { get; set; }

        /// <summary>
        /// Perform an intersection test between a ray and the elements in the scene
        /// </summary>
        /// <param name="r">The ray to test</param>
        /// <returns>The intersection points</returns>
        public IEnumerable<Intersection> Intersect(Ray r)
        {
            // We're getting some really short, negative intersections.  so trying with distance > 0
            return this.Elements.Select(el => el.Intersect(r)).Where(i => i != null && i.Distance > 0);
        }

        /// <summary>
        /// Calculate the closest intersection between a ray and the items in the scene.
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <returns>The closest of intersection</returns>
        public Intersection ClosestIntersection(Ray r)
        {
            return this.Intersect(r).Min();
        }

        /// <summary>
        /// Test a ray against the objects in the scene
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <returns>The distance to the point of intersection</returns>
        public double TestRay(Ray ray)
        {
            var isect = this.ClosestIntersection(ray);
            if (isect == null)
            {
                return 0;
            }

            return isect.Distance;
        }
    }
}
