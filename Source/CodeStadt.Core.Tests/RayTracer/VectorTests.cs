using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CodeStadt.Draw.RayTracer;

namespace CodeStadt.Core.Tests.RayTracer
{
    [TestFixture]
    public class VectorTests
    {
        [Test]
        public void IdenticalVectorsAreEqual()
        {
            // Arrange
            var v1 = new Vector(1, 1, 1);
            var v2 = new Vector(1, 1, 1);

            // Act
            var b = (v1.Equals(v2));

            // Assert
            Assert.IsTrue(b);
        }

        [Test]
        public void IdenticalVectorsAreEqual_Static()
        {
            // Arrange
            var v1 = new Vector(1, 1, 1);
            var v2 = new Vector(1, 1, 1);

            // Act
            var b = Vector.Equals(v1, v2);

            // Assert
            Assert.IsTrue(b);
        }

        [Test]
        public void DifferentVectorsAreNotEqual()
        {
            // Arrange
            var v1 = new Vector(1, 1, 1);
            var v2 = new Vector(2, 2, 2);

            // Act
            var b = (v1.Equals(v2));

            // Assert
            Assert.IsFalse(b);
        }

        [Test]
        public void ObjectAndVectorsAreNotEqual()
        {
            // Arrange
            var v1 = new Vector(1, 1, 1);
            var obj = new Object(); ;

            // Act
            var b = (v1.Equals(obj));

            // Assert
            Assert.IsFalse(b);
        }


        [Test]
        public void CanAddVectors()
        {
            // Arrange
            var v1 = new Vector(1, 1, 1);
            var v2 = new Vector(2, 3, 4);

            // Act
            var sum_member = v1.Plus(v2);
            var sum_static = Vector.Plus(v1, v2);
            var sum_operator = v1 + v2;

            // Assert
            var result = new Vector(3,4,5);
            Assert.IsTrue(sum_member.Equals(result));
            Assert.IsTrue(sum_static.Equals(result));
            Assert.IsTrue(sum_operator.Equals(result));
        }

        [Test]
        public void CanSubtractVectors()
        {
            // Arrange
            var v1 = new Vector(2, 3, 4);
            var v2 = new Vector(1, 1, 1);

            // Act
            var sum_member = v1.Minus(v2);
            var sum_static = Vector.Minus(v1, v2);
            var sum_operator = v1 - v2;

            // Assert
            var result = new Vector(1, 2, 3);
            Assert.IsTrue(sum_member.Equals(result));
            Assert.IsTrue(sum_static.Equals(result));
            Assert.IsTrue(sum_operator.Equals(result));
        }

        [Test]
        public void CanMultiplyVectorByConstant()
        {
            // Arrange
            var v = new Vector(2, 3, 4);

            // Act
            var sum_member = v.Times(2);
            var sum_static = Vector.Times(2,v);
            var sum_operator = 2 * v;

            // Assert
            var result = new Vector(4, 6, 8);
            Assert.IsTrue(sum_member.Equals(result));
            Assert.IsTrue(sum_static.Equals(result));
            Assert.IsTrue(sum_operator.Equals(result));
        }

        [Test]
        public void CanCalculateMagnitudeOfVector()
        {
            // Arrange
            var v = new Vector(6, 8, 0);

            // Act
            var mag = v.Magnitude;

            // Assert
            Assert.AreEqual(10, mag);
        }

        [Test]
        public void CanCalculateMagnitudeOfVector_2()
        {
            // Arrange
            var v = new Vector(1, 1, 1);

            // Act
            var mag = v.Magnitude;

            // Assert
            Assert.AreEqual(Math.Sqrt(3), mag);
        }

        [Test]
        public void CanNormaliseVector()
        {
            // Arrange
            var v = new Vector(3, 4, 0);

            // Act
            var norm = v.Normalise;

            // Assert
            // using * 0.2 so that we get the same double inaccuracy
            var result = new Vector(3.0 *0.2, 4.0 * 0.2, 0.0);
            Assert.AreEqual(result, norm);
        }

        [Test]
        public void CanCalculateDotProduct()
        {
            // Arrange
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(2, 3, 4);

            // Act
            var dot = v1.Dot(v2);
            var dot_static = Vector.Dot(v1, v2);

            // Assert
            Assert.AreEqual(20, dot);
            Assert.AreEqual(20, dot_static);
        }

        [Test]
        public void CanCalculateCrossProduct()
        {
            // Arrange
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(2, 3, 4);

            // Act
            var cross = v1.Cross(v2);
            var cross_static = Vector.Cross(v1, v2);

            // Assert
            Assert.AreEqual(new Vector(-1, 2, -1), cross);
            Assert.AreEqual(new Vector(-1, 2, -1), cross_static);
        }

        [Test]
        public void CanConvertToNiceString()
        {
            // Arrange
            var v1 = new Vector(1, 2, 3);

            // Act
            var str = v1.ToString();

            // Assert
            Assert.AreEqual("X=1 Y=2 Z=3", str);
        }
    }
}
