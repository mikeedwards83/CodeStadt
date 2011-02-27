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
    public class LineTests
    {
        [Test]
        public void CanInsersectLine()
        {
            // Arrange
            var line = new Line() { Point = new Vector(0, 1, 0), Direction = new Vector(1, 0, 0) };
            var ray = new Ray() { Start = new Vector(0, 0, 0), Direction = new Vector(1, 1, 0) };

            // Act
            var isect = line.Intersect(ray);

            // Assert
            Assert.NotNull(isect);
            Assert.AreEqual(Math.Sqrt(2), isect.Distance);
            Assert.AreEqual(line, isect.Element);
        }

        [Test]
        public void CanFailToInsersectLine()
        {
            // Arrange
            var line = new Line() { Point = new Vector(0, 1, 0), Direction = new Vector(1, 0, 0) };
            var ray = new Ray() { Start = new Vector(0, 0, 0), Direction = new Vector(1, 0, 1) };

            // Act
            var isect = line.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

        [Test]
        public void CanFailToInsersectParallelLine()
        {
            // Arrange
            var line = new Line() { Point = new Vector(0, 1, 0), Direction = new Vector(1, 0, 0) };
            var ray = new Ray() { Start = new Vector(0, 0, 0), Direction = new Vector(1, 0, 0) };

            // Act
            var isect = line.Intersect(ray);

            // Assert
            Assert.IsNull(isect);
        }

    }
}
