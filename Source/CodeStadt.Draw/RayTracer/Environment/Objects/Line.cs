namespace CodeStadt.Draw.RayTracer.Environment.Objects
{
    using System;

    /// <summary>
    /// Represent a line in the scene.  This is for testing only.
    /// A line doesn't have any thickness, so the rendering is flakey
    /// as hell.
    /// </summary>
    public class Line : SceneObject
    {
        /// <summary>
        /// A point on the line
        /// </summary>
        public Vector Point;

        /// <summary>
        /// The direction vector of the line
        /// </summary>
        public Vector Direction;

        /// <summary>
        /// Calculate the point of intersection between the line and a ray
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <returns>The point of intersection or null</returns>
        public override Intersection Intersect(Ray ray)
        {
            // line = Point + a * Direction
            // a (Dl x Dr) = (Pr - Pl) x Dr

            var b = Vector.Cross(this.Direction, ray.Direction);
            var c = Vector.Cross((ray.Start - this.Point), ray.Direction);

            // We use epsilon to fudge rendering the line.  The bigger the value
            // the bigger the line
            var e = 0.01;

            // b and c should be parallel if lines intersct (apparently!)
            // so lets see if they point in the same direction
            if(Math.Abs(Vector.Cross(b, c).Magnitude) < e == false){
                return null;
            }

            // No intersection
            if (b.Magnitude == 0)
            {
                return null;
            }

            // Solve the equation
            var a = c.Magnitude / b.Magnitude;

            // Use the solution to find the point of intersection and distance
            var PoI = this.Point + this.Direction.Times(a);
            var distance = (PoI - ray.Start).Magnitude;

            return new Intersection()
            {
                Element = this,
                Ray = ray,
                Distance = distance
            };
        }

        /// <summary>
        /// You cant have a normal to a line, so this is a fudge
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override Vector Normal(Vector position)
        {
            return new Vector(1, 0, 0);
        }
    }
}
