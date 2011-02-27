using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CodeStadt.Draw.RayTracer;
using CodeStadt.Draw.RayTracer.Environment;
using CodeStadt.Draw.RayTracer.Environment.Objects;

namespace CodeStadt.Core.Tests.RayTracer
{
    [TestFixture]
    public class PolygonTests
    {
        [Test]
        public void CanDeterminePointInPolygon_Square()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(0, 1), new Vertex(1, 1), new Vertex(1, 0) };
            var test = new Vertex(0.5, 0.5);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsTrue(b);
        }

        [Test]
        public void CanDeterminePointInPolygon_Square_NearBottomLeftCorner()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(0, 1), new Vertex(1, 1), new Vertex(1, 0) };
            var test = new Vertex(0.1, 0.1);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsTrue(b);
        }

        [Test]
        public void CanDeterminePointInPolygon_Square_NearTopRightCorner()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(0, 1), new Vertex(1, 1), new Vertex(1, 0) };
            var test = new Vertex(0.9, 0.9);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsTrue(b);
        }

        [Test]
        public void CanDeterminePointInPolygon_Square_NegativeCoords()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, -1), new Vertex(0, -1) };
            var test = new Vertex(0.5, -0.5);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsTrue(b);
        }

        [Test]
        public void CanDeterminePointInPolygon_Square_NegativeCoords_NearBottomLeft()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, -1), new Vertex(0, -1) };
            var test = new Vertex(0.1, -0.1);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsTrue(b);
        }

        [Test]
        public void CanDeterminePointInPolygon_Square_NegativeCoords_NearTopRight()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, -1), new Vertex(0, -1) };
            var test = new Vertex(0.9, -0.9);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsTrue(b);
        }

        [Test]
        public void CanDeterminePointNotInPolygon_Square_MixedCoords()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1), new Vertex(0, 1) };
            var test = new Vertex(0.9, -0.9);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsFalse(b);
        }

        [Test]
        public void CanDeterminePointNotInPolygon_Square_NegativeCoords()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(1, 0), new Vertex(1, 1), new Vertex(0, 1) };
            var test = new Vertex(-0.9, -0.9);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsFalse(b);
        }

        [Test]
        public void CanDeterminePointOutsidePolygon_Square()
        {
            // Arrange
            var points = new List<Vertex>() { new Vertex(0, 0), new Vertex(0, 1), new Vertex(1, 1), new Vertex(1, 0) };
            var test = new Vertex(1.5, 0.5);

            // Act
            var b = Polygon.PointInPolygon(points, test);

            // Assert
            Assert.IsFalse(b);
        }

        [Test]
        public void CanInsersectPolygon_Square()
        {
            // Arrange
            var points = new List<Vector>(){ new Vector(0,0,0), new Vector(1,0,0), new Vector(1,1,0), new Vector(0,1,0)};
            var poly = new Polygon(points, new Vector(0,0,1));

            var ray = new Ray() { Start = new Vector(0.5, 0.5, 0.5), Direction = new Vector(0, 0, -1) };

            // Act
            var isect = poly.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(0.5, isect.Distance);
            Assert.AreEqual(poly, isect.Element);
        }

        [Test]
        public void CanFailToInsersectPolygon_Square()
        {
            // Arrange
            var points = new List<Vector>() { new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(1, 1, 0), new Vector(0, 1, 0) };
            var poly = new Polygon(points, new Vector(0, 0, 1));

            var ray = new Ray() { Start = new Vector(1.5, 0.5, 0.5), Direction = new Vector(0, 0, -1) };

            // Act
            var isect = poly.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

        [Test]
        public void CanFailToInsersectPolygon_Square_NegativeMiss()
        {
            // Arrange
            var points = new List<Vector>() { new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(1, 1, 0), new Vector(0, 1, 0) };
            var poly = new Polygon(points, new Vector(0, 0, 1));

            var ray = new Ray() { Start = new Vector(-0.5, 0.5, 0.5), Direction = new Vector(0, 0, -1) };

            // Act
            var isect = poly.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

        [Test]
        public void CanFailToInsersectPolygon_Square_ParallelRay()
        {
            // Arrange
            var points = new List<Vector>() { new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(1, 1, 0), new Vector(0, 1, 0) };
            var poly = new Polygon(points, new Vector(0, 0, 1));

            var ray = new Ray() { Start = new Vector(1, 0, 0.5), Direction = new Vector(1, 0, 0) };

            // Act
            var isect = poly.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

        [Test]
        public void CanInsersectPolygon_Square_AngledRay()
        {
            // Arrange
            var points = new List<Vector>() { new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(1, 1, 0), new Vector(0, 1, 0) };
            var poly = new Polygon(points, new Vector(0, 0, 1));

            var ray = new Ray() { Start = new Vector(1, 1, 1), Direction = new Vector(-0.5, -0.5, -1) };

            // Act
            var isect = poly.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(1, isect.Distance, 0.001);
            Assert.AreEqual(poly, isect.Element);
        }

        [Test]
        public void CanInsersectPolygon_Square_NearBottomRight()
        {
            // Arrange
            var points = new List<Vector>() { new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(1, 1, 0), new Vector(0, 1, 0) };
            var poly = new Polygon(points, new Vector(0, 0, 1));

            var ray = new Ray() { Start = new Vector(0.1, 0.1, 0.5), Direction = new Vector(0, 0, -1) };

            // Act
            var isect = poly.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(0.5, isect.Distance);
            Assert.AreEqual(poly, isect.Element);
        }

        [Test]
        public void CanInsersectPolygon_Square_NearTopRight()
        {
            // Arrange
            var points = new List<Vector>() { new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(1, 1, 0), new Vector(0, 1, 0) };
            var poly = new Polygon(points, new Vector(0, 0, 1));

            var ray = new Ray() { Start = new Vector(0.9, 0.9, 0.5), Direction = new Vector(0, 0, -1) };

            // Act
            var isect = poly.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(0.5, isect.Distance);
            Assert.AreEqual(poly, isect.Element);
        }

        [Test]
        public void CanFindPointOfIntersection()
        {
            // Arrange
            var points = new List<Vector>() { new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(1, 1, 0), new Vector(0, 1, 0) };
            var poly = new Polygon(points, new Vector(0, 0, 1));

            var ray = new Ray() { Start = new Vector(0.5, 0.5, 0.5), Direction = new Vector(0, 0, -1) };

            // Act
            var isect = poly.GetPointOfIntersectionWithPlane(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(0.5, isect.X);
            Assert.AreEqual(0.5, isect.Y);
        }

        [Test]
        public void CanFailToIntersectPlaneWithParallelRay()
        {
            // Arrange
            var points = new List<Vector>() { new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(1, 1, 0), new Vector(0, 1, 0) };
            var poly = new Polygon(points, new Vector(0, 0, 1));

            var ray = new Ray() { Start = new Vector(1, 0, 0.5), Direction = new Vector(1, 0, 0) };

            // Act
            var isect = poly.GetPointOfIntersectionWithPlane(ray);

            // Assert
            Assert.IsNull(isect);
        }
    }
}
