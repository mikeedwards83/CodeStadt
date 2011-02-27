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
    public class IntersectionTests
    {
        /// <summary>
        /// Test the implementation of IComparable for intersections
        /// </summary>
        [Test]
        public void CanFindClosestIntersection()
        {
            // Arrange
            var isect = from x in new double[] { 2, 3, 1, 4 } select new Intersection() { Distance = x };

            // Act
            var closest = isect.Min();

            // Assert
            Assert.AreEqual(1, closest.Distance);
        }
    }
}
