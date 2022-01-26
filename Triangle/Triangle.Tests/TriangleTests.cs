using System;
using NUnit.Framework;

namespace Triangle.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [TestCase(new double[] { 3, 4, 5 }, ExpectedResult = 12)]
        [TestCase(new double[] { 2, 3, 4 }, ExpectedResult = 9)]
        [TestCase(new double[] { 3, 3, 3 }, ExpectedResult = 9)]
        [TestCase(new double[] { 16, 27, 35 }, ExpectedResult = 78)]
        public double Peremeter_ReturnsValue(double[] sides)
        {
            var triangle = new Triangle(sides);
            return triangle.Perimeter();
        }

        [TestCase(new double[] { 3, 4, 5 }, ExpectedResult = 6)]
        [TestCase(new double[] { 2, 3, 4 }, ExpectedResult = 2.9047375096555625)]
        [TestCase(new double[] { 3, 3, 3 }, ExpectedResult = 3.897114317029974)]
        [TestCase(new double[] { 16, 27, 35 }, ExpectedResult = 207.499397589487)]
        public double Area_ReturnsValue(double[] sides)
        {
            var triangle = new Triangle(sides);
            return triangle.Area();
        }

        [TestCase(new double[] { double.MinValue, 0, -2 })]
        [TestCase(new double[] { -3, -4, -5 })]
        [TestCase(new double[] { -2, 2, 2 })]
        [TestCase(new double[] { 0, 0, 0 })]
        [TestCase(new double[] { double.MinValue, double.MinValue, double.MinValue })]
        public void TriangleDoesNotExist_ThrowArgumentException(double[] sides)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(sides));
        }

        [TestCase(new double[] { double.MaxValue, double.MaxValue, 1 })]
        [TestCase(new double[] { double.MaxValue / 2.0, double.MaxValue / 2.0, double.MaxValue / 2.0 })]
        public void TriangleSidesAreTooLarge_ThrowArgumentOutOfRangeException(double[] sides)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sides));
        }
    }
}
