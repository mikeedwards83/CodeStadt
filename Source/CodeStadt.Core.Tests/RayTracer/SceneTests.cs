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
    public class SceneTests
    {
        [Test]
        public void CanIntersectWithObjectsInTheScene()
        {
            // Arrange
            var s1 = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var p = new Plane() { Point = new Vector(0, -1, 0), Norm = new Vector(0, 1, 0) };
            var scene = new Scene() { Elements = new SceneObject[] { p, s1 } };
            var ray = new Ray() { Start = new Vector(0,2, -2), Direction = new Vector(0,-1,1)};

            // Act
            var isect = scene.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(2, isect.Count());
        }

        [Test]
        public void CanIntersectWithObjectsInTheSceneAndNotReturnNulls()
        {
            // Arrange
            var s1 = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var p = new Plane() { Point = new Vector(0, -1, 0), Norm = new Vector(0, 1, 0) };
            var scene = new Scene() { Elements = new SceneObject[] { p, s1 } };
            var ray = new Ray() { Start = new Vector(0, 0, -2), Direction = new Vector(0, 0, 1) };

            // Act
            var isect = scene.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(1, isect.Count());
        }

        [Test]
        public void CanFindClosestIntersectionWithObjectsInTheScene()
        {
            // Arrange
            var s1 = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var p = new Plane() { Point = new Vector(0, -1, 0), Norm = new Vector(0, 1, 0) };
            var scene = new Scene() { Elements = new SceneObject[] { p, s1 } };
            var ray = new Ray() { Start = new Vector(0, 2, -2), Direction = new Vector(0, -1, 1) };

            // Act
            var isect = scene.ClosestIntersection(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(s1, isect.Element);
        }

        [Test]
        public void CanTestRay_Succeed()
        {
            // Arrange
            var s1 = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var p = new Plane() { Point = new Vector(0, -1, 0), Norm = new Vector(0, 1, 0) };
            var scene = new Scene() { Elements = new SceneObject[] { p, s1 } };
            var ray = new Ray() { Start = new Vector(0, 2, -2), Direction = new Vector(0, -1, 1) };

            // Act
            var distance = scene.TestRay(ray);

            // Assert
            Assert.AreEqual(1, distance);
        }

        [Test]
        public void CanTestRay_Failure()
        {
            // Arrange
            var s1 = new Sphere() { Center = new Vector(0, 0, 0), Radius = 1 };
            var p = new Plane() { Point = new Vector(0, -1, 0), Norm = new Vector(0, 1, 0) };
            var scene = new Scene() { Elements = new SceneObject[] { p, s1 } };
            var ray = new Ray() { Start = new Vector(0, 2, -2), Direction = new Vector(0, 1, 0) };

            // Act
            var distance = scene.TestRay(ray);

            // Assert
            Assert.AreEqual(0, distance);
        }
    }
}
