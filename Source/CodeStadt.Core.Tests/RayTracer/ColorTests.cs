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
    public class ColorTests
    {
        [Test]
        public void EqualColorsAreEqual()
        {
            // Arrange
            var c1 = new Color(0.2, 0.2, 0.2);
            var c2 = new Color(0.2, 0.2, 0.2);

            // Act;
            var b = c1.Equals(c2);
            var b_static = Color.Equals(c1, c2);

            // Assert
            Assert.IsTrue(b);
            Assert.IsTrue(b_static);
        }

        [Test]
        public void UnequalColorsAreNotEqual()
        {
            // Arrange
            var c1 = new Color(0.2, 0.2, 0.2);
            var c2 = new Color(0.3, 0.2, 0.2);

            // Act;
            var b = c1.Equals(c2);
            var b_static = Color.Equals(c1, c2);

            // Assert
            Assert.IsFalse(b);
            Assert.IsFalse(b_static);
        }

        [Test]
        public void ObjectAndColorAreNotEqual()
        {
            // Arrange
            var c1 = new Color(0.2, 0.2, 0.2);
            var c2 = new Object();

            // Act;
            var b = c1.Equals(c2);

            // Assert
            Assert.IsFalse(b);
        }

        [Test]
        public void CanAddColors()
        {
            // Arrange
            var c1 = new Color(0.2, 0.2, 0.2);
            var c2 = new Color(0.3, 0.3, 0.3);

            // Act
            var sum = c1.Plus(c2);
            var sum_static = Color.Plus(c1, c2);
            var sum_operator = c1 + c2;

            // Assert
            var result = new Color(0.2 + 0.3, 0.2 + 0.3, 0.2 + 0.3);
            Assert.AreEqual(result, sum);
            Assert.AreEqual(result, sum_static);
            Assert.AreEqual(result, sum_operator);
        }

        [Test]
        public void CanSubtractColors()
        {
            // Arrange
            var c1 = new Color(0.3, 0.3, 0.3);
            var c2 = new Color(0.1, 0.1, 0.1);

            // Act
            var sum = c1.Minus(c2);
            var sum_static = Color.Minus(c1, c2);
            var sum_operator = c1 - c2;

            // Assert
            var result = new Color(0.3 - 0.1, 0.3 - 0.1, 0.3 - 0.1);
            Assert.AreEqual(result, sum);
            Assert.AreEqual(result, sum_static);
            Assert.AreEqual(result, sum_operator);
        }

        [Test]
        public void CanMultiplyColors()
        {
            // Arrange
            var c1 = new Color(0.3, 0.3, 0.3);
            var c2 = new Color(0.1, 0.1, 0.1);

            // Act
            var sum = c1.Times(c2);
            var sum_static = Color.Times(c1, c2);
            var sum_operator = c1 * c2;

            // Assert
            var result = new Color(0.3 * 0.1, 0.3 * 0.1, 0.3 * 0.1);
            Assert.AreEqual(result, sum);
            Assert.AreEqual(result, sum_static);
            Assert.AreEqual(result, sum_operator);
        }

        [Test]
        public void CanMultiplyColorByConstant()
        {
            // Arrange
            var c1 = new Color(0.3, 0.3, 0.3);

            // Act
            var sum = c1.Times(2);
            var sum_static = Color.Times(2,c1);
            var sum_operator = 2 * c1;

            // Assert
            var result = new Color(0.3 * 2, 0.3 * 2, 0.3 * 2);
            Assert.AreEqual(result, sum);
            Assert.AreEqual(result, sum_static);
            Assert.AreEqual(result, sum_operator);
        }

        [Test]
        public void CanConvertToDrawingColor()
        {
            // Arrange
            var c = new Color(0.5, 0.6, 1);

            // Act
            var sc = c.ToDrawingColor();

            // Assert
            Assert.AreEqual(127, sc.R);
            Assert.AreEqual(153, sc.G);
            Assert.AreEqual(255, sc.B);
        }
    }
}
