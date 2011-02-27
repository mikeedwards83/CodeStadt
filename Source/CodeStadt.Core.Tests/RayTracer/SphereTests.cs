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
    public class SphereTests
    {
        /// <summary>
        /// Test intersection with the middle of the sphere
        /// </summary>
        [Test]
        public void CanIntersectSphere()
        {
            // Arrange
            var sphere = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var ray = new Ray() { Start = new Vector(0, 0, -2), Direction = new Vector(0, 0, 1) };

            // Act
            var isect = sphere.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(1, isect.Distance);
            Assert.AreEqual(sphere, isect.Element);
        }

        /// <summary>
        /// Test intersection with the very edge of the sphere
        /// </summary>
        [Test]
        public void CanIntersectEdgeOfSphere()
        {
            // Arrange
            var sphere = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var ray = new Ray() { Start = new Vector(1, 0, -2), Direction = new Vector(0, 0, 1) };

            // Act
            var isect = sphere.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(2, isect.Distance);
            Assert.AreEqual(sphere, isect.Element);
        }


        /// <summary>
        /// Test a ray that misses the sphere
        /// </summary>
        [Test]
        public void CanFailToInsersectSphere()
        {
            // Arrange
            var sphere = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var ray = new Ray() { Start = new Vector(2, 0, 0), Direction = new Vector(0, 0, 1) };

            // Act
            var isect = sphere.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

        [Test]
        public void CanFailToInsersectWithRayFacingAwayFromSphere()
        {
            // Arrange
            var sphere = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var ray = new Ray() { Start = new Vector(0, 0, -2), Direction = new Vector(0, 0, -1) };

            // Act
            var isect = sphere.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

        /// <summary>
        /// Test we can calculate a normal to the surface of the sphere
        /// </summary>
        [Test]
        public void CanCalculateNormalToSphere()
        {
            // Arrange
            var sphere = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var position = new Vector(1,0,0);

            // Act
            var normal = sphere.Normal(position);

            // Assert
            Assert.NotNull(normal);
            Assert.IsTrue(normal.Equals(new Vector(1,0,0)));
        }
    }
}
