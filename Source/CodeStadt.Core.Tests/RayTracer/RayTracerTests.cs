using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using rt = CodeStadt.Draw.RayTracer;
using CodeStadt.Draw.RayTracer.Environment;
using CodeStadt.Draw.RayTracer.Environment.Objects;

namespace CodeStadt.Core.Tests.RayTracer
{
    [TestFixture]
    public class RayTracerTests
    {
        /// <summary>
        /// Useful action to have for tests
        /// </summary>
        private Action<int, int, System.Drawing.Color> withresult = (x, y, c) => { };

        [Test]
        public void CanConstructNewRayTracer()
        {
            // Arrange

            // Act
            var rt = new rt.RayTracer(withresult);

            // Assert
            Assert.NotNull(rt);
            Assert.AreEqual(5, rt.MaxDepth);
        }

        [Test]
        public void CanConstructNewRayTracerWithRecursiveDepth()
        {
            // Arrange

            // Act
            var rt = new rt.RayTracer(withresult, 3);

            // Assert
            Assert.NotNull(rt);
            Assert.AreEqual(3, rt.MaxDepth);
        }

        
    }
}
