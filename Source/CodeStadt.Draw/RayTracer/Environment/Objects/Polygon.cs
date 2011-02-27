namespace CodeStadt.Draw.RayTracer.Environment.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Represent a polygon that can be used to construct more complex objects.
    /// </summary>
    public class Polygon : SceneObject
    {
        /// <summary>
        /// A normal to the plane
        /// </summary>
        public Vector Norm { get; private set; }

        /// <summary>
        /// The collection of points that make up the polygon.  The points
        /// must be co-planar (in the same plane).
        /// </summary>
        public IList<Vector> Points { get; private set; }

        public Polygon(IList<Vector> points, Vector norm)
        {
            this.Norm = norm;
            this.Points = points;

            // TODO: We should verify the points are co-planar
            //       we need at least 3 points as well.
        }

        /// <summary>
        /// Calculate the point of intersection between the plane and a ray
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <returns>The point of intersection or null</returns>
        public override Intersection Intersect(Ray ray)
        {
            var PoI = this.GetPointOfIntersectionWithPlane(ray);

            if (PoI == null)
            {
                return null;
            }

            // Create an ortho-normal basis
            var u = (this.Points[1] - this.Points[0]).Normalise;
            var v = u.Cross(this.Norm).Normalise;

            // Set the plane's origin to a known point
            var p1 = this.Points[0];

            // Convert the PoI to 2D
            var x = (PoI - p1).Dot(u);
            var y = (PoI - p1).Dot(v);
            var PoI_2d = new Vertex(x, y);

            // Convert the vertices of the polygon to 2D using the same basis
            IList<Vertex> vertices = new List<Vertex>();
            foreach (var p in this.Points)
            {
                var Px = (p - p1).Dot(u);
                var Py = (p - p1).Dot(v);
                vertices.Add(new Vertex(Px, Py));
            }

            if (Polygon.PointInPolygon(vertices, PoI_2d))
            {
                return new Intersection()
                {
                    Element = this,
                    Ray = ray,
                    Distance = (PoI - ray.Start).Magnitude
                };
            }
            

            return null;
        }

        /// <summary>
        /// Find the point at which the ray intersects the 
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public Vector GetPointOfIntersectionWithPlane(Ray ray)
        {
            // Intersect the ray with the plane the polygon lies in and 
            // find the point of intersection.  See notes in Plane for
            // details on how this works.
            double denominator = Vector.Dot(this.Norm, ray.Direction);

            if (denominator >= 0)
            {
                return null;
            }

            var d = (this.Points[0] - ray.Start).Dot(this.Norm) / denominator;

            // if d is the distance.  does it follow that ray.Start + d * ray.Direction.Normalise
            return ray.Start + (d * ray.Direction.Normalise);
        }

        /// <summary>
        /// Test if a 2D point is inside a 2D polygon.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="testPoint"></param>
        /// <returns></returns>
        public static bool PointInPolygon(IList<Vertex> polygon, Vertex testPoint)
        {
            Vertex p1, p2;
            bool inside = false;
            int vertices = polygon.Count;

            if (vertices < 3)
            {
                return false;
            }

            // This algo doesnt work with negative co-ordinates, so we need to shift everything into the positive
            // quadrant before running the test.
            double minX = 0, minY = 0;

            for (int i = 0; i < vertices; i++)
            {
                minX = Math.Min(minX, polygon[i].X);
                minY = Math.Min(minY, polygon[i].Y);
            }

            // Not sure we need to do this
            var shiftedPolygon = new List<Vertex>();
            var shiftedTestPoint = new Vertex();

            minX = (minX < 0) ? Math.Abs(minX) : 0;
            minY = (minY < 0) ? Math.Abs(minY) : 0;

            // Shift the test point
            shiftedTestPoint.X = testPoint.X + minX;
            shiftedTestPoint.Y = testPoint.Y + minY;

            // Shift the vertices
            foreach (var v in polygon)
            {
                shiftedPolygon.Add(new Vertex(v.X + minX, v.Y + minY));
            }

            // Now we've adjusted, lets do the test

            if (shiftedTestPoint.X < 0 || shiftedTestPoint.Y < 0)
            {
                return false;
            }

            var oldPoint = new Vertex(shiftedPolygon[vertices - 1].X, shiftedPolygon[vertices - 1].Y);

            for (int i = 0; i < vertices; i++)
            {
                var newPoint = new Vertex(shiftedPolygon[i].X, shiftedPolygon[i].Y);

                // Make p1 the left-most vertex
                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.X < shiftedTestPoint.X) == (shiftedTestPoint.X <= oldPoint.X)
                        && ((long)shiftedTestPoint.Y - (long)p1.Y) * (long)(p2.X - p1.X) < ((long)p2.Y - (long)p1.Y) * (long)(shiftedTestPoint.X - p1.X))
                {
                    inside = !inside;
                }

                oldPoint = newPoint;
            }

            return inside;
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
