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
    public class PlaneTests
    {
        [Test]
        public void CanInsersectPlane()
        {
            // Arrange
            var plane = new Plane() { Point = new Vector(0, 0, 0), Norm = new Vector(0, 1, 0) };
            var ray = new Ray() { Start = new Vector(0, 1, 0), Direction = new Vector(0, -1, 0) };

            // Act
            var isect = plane.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(1, isect.Distance);
            Assert.AreEqual(plane, isect.Element);
        }

        [Test]
        public void CanFailToIntersectPlane()
        {
            // Arrange
            var plane = new Plane() { Point = new Vector(0, 0, 0), Norm = new Vector(0, 1, 0) };
            var ray = new Ray() { Start = new Vector(0, 1, 0), Direction = new Vector(0, 1, 1) };

            // Act
            var isect = plane.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

        [Test]
        public void CanCalculateNormalToPlane()
        {
            // Arrange
            var plane = new Plane() { Point = new Vector(0, 0, 0), Norm = new Vector(0, 1, 0) };

            // Act
            var normal = plane.Normal(new Vector(0, 2,2));

            // Assert
            Assert.IsTrue(normal.Equals(new Vector(0, 1, 0)));
        }

        [Test]
        public void CanFailToIntersectWhenRayFacingAwayFromPlane()
        {
            // Arrange
            var plane = new Plane() { Point = new Vector(0, 0, 0), Norm = new Vector(0, 1, 0) };
            var ray = new Ray() { Start = new Vector(0, 1, 0), Direction = new Vector(0, 1, 0) };

            // Act
            var isect = plane.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

        [Test]
        public void CanFailToIntersectWhenRayParallelToPlane()
        {
            // Arrange
            var plane = new Plane() { Point = new Vector(0, 0, 0), Norm = new Vector(0, 1, 0) };
            var ray = new Ray() { Start = new Vector(0, 1, 0), Direction = new Vector(1, 0, 0) };

            // Act
            var isect = plane.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }
    }
}
