using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CodeStadt.Draw.RayTracer;
using CodeStadt.Draw.RayTracer.Environment;

namespace CodeStadt.Core.Tests.RayTracer
{
    [TestFixture]
    public class CameraTests
    {
        [Test]
        public void CanConstructNewCamera()
        {
            // Arrange
            var pos = new Vector(0, 0, 0);
            var dir = new Vector(0, 0, 1);
            var screen = new Screen(100, 100);

            // Act
            var camera = new Camera(pos, dir, screen);

            // Assert
            Assert.AreEqual(pos, camera.Position);

            // Forward is a unit vector pointing in 'lookAt' from 'position'
            Assert.IsTrue(camera.Forward.Equals(new Vector(0, 0, 1)));

            // Right
            Assert.IsTrue(camera.Right.Equals(new Vector(1,0,0)));

            // Up
            Assert.IsTrue(camera.Up.Equals(new Vector(0,1,0)));
        }

        [Test]
        public void CanGetRayDirection()
        {
            // Arrange
            var pos = new Vector(0, 0, 0);
            var dir = new Vector(0, 0, 1);
            var screen = new Screen(400, 300);
            var camera = new Camera(pos, dir, screen);

            // Act
            var ray = camera.GetRayDirection(100, 100);
            
            // Assert
            Assert.Less(Math.Abs((-1.0 / 8.0) - ray.X), 0.005);
            Assert.Less(Math.Abs((1.0 / 12.0) - ray.Y), 0.005);
            Assert.Less(Math.Abs((1.0) - ray.Z), 0.02);
        }
    }
}
