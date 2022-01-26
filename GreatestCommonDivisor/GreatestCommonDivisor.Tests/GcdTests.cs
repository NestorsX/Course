using System;
using NUnit.Framework;

namespace GreatestCommonDivisor.Tests
{
    [TestFixture]
    public class GcdTests
    {
        [TestCase(15, 75, ExpectedResult = 15)]
        [TestCase(0, 75, ExpectedResult = 75)]
        [TestCase(15, 0, ExpectedResult = 15)]
        [TestCase(-15, 75, ExpectedResult = 15)]
        [TestCase(15, -75, ExpectedResult = 15)]
        [TestCase(-15, -75, ExpectedResult = 15)]
        [TestCase(0, -75, ExpectedResult = 75)]
        [TestCase(-15, 0, ExpectedResult = 15)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, 0, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int GetGCD_ReturnsValue(int a, int b)
        {
            return Gcd.GetGCD(a, b);
        }

        [TestCase(15, 75, 125, ExpectedResult = 5)]
        [TestCase(0, 75, 125, ExpectedResult = 25)]
        [TestCase(15, 0, 125, ExpectedResult = 5)]
        [TestCase(-15, 75, 250, ExpectedResult = 5)]
        [TestCase(15, -75, 0, ExpectedResult = 15)]
        [TestCase(-15, -75, -125, ExpectedResult = 5)]
        [TestCase(0, -75, 0, ExpectedResult = 75)]
        [TestCase(-15, 0, 0, ExpectedResult = 15)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, 0, 0, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int GetGCD_ReturnsValue(int a, int b, int c)
        {
            return Gcd.GetGCD(a, b, c);
        }

        [TestCase(15, 75, 125, -5, ExpectedResult = 5)]
        [TestCase(0, 75, 125, 25, ExpectedResult = 25)]
        [TestCase(15, 0, 125, 50, ExpectedResult = 5)]
        [TestCase(-15, 75, 250, -50, ExpectedResult = 5)]
        [TestCase(15, -75, 0, 30, ExpectedResult = 15)]
        [TestCase(-15, -75, -125, 90, ExpectedResult = 5)]
        [TestCase(0, -75, 0, -0, ExpectedResult = 75)]
        [TestCase(-15, 0, 0, 25, ExpectedResult = 5)]
        [TestCase(0, -0, 0, -0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, 0, 0, 0, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int GetGCD_ReturnsValue(int a, int b, int c, int d)
        {
            return Gcd.GetGCD(a, b, c, d);
        }

        [TestCase(15, 75, 125, -5, 125, ExpectedResult = 5)]
        [TestCase(0, 75, 125, 25, -75, ExpectedResult = 25)]
        [TestCase(15, 0, 125, 50, -25, ExpectedResult = 5)]
        [TestCase(-15, 75, 250, -50, -500, ExpectedResult = 5)]
        [TestCase(15, -75, 0, 30, 900, ExpectedResult = 15)]
        [TestCase(-15, -75, -125, 90, 25, ExpectedResult = 5)]
        [TestCase(0, -75, 0, -0, 75, ExpectedResult = 75)]
        [TestCase(-15, 0, 0, 25, 5, ExpectedResult = 5)]
        [TestCase(0, -0, 0, -0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, 0, 0, 0, 0, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int GetGCD_ReturnsValue(int a, int b, int c, int d, int e)
        {
            return Gcd.GetGCD(a, b, c, d, e);
        }

        [TestCase(int.MinValue, 0)]
        [TestCase(0, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue)]
        public void GetGCD_ValuesAreEqualsIntegerMinValue_ThrowArgumentOutOfRangeException(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Gcd.GetGCD(a, b));
        }

        [TestCase(15, 75, ExpectedResult = 15)]
        [TestCase(0, 75, ExpectedResult = 75)]
        [TestCase(15, 0, ExpectedResult = 15)]
        [TestCase(-15, 75, ExpectedResult = 15)]
        [TestCase(15, -75, ExpectedResult = 15)]
        [TestCase(-15, -75, ExpectedResult = 15)]
        [TestCase(0, -75, ExpectedResult = 75)]
        [TestCase(-15, 0, ExpectedResult = 15)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, 0, ExpectedResult = int.MaxValue)]
        public int GetBinaryGCD_ReturnsValue(int a, int b)
        {
            return Gcd.GetBinaryGCD(a, b);
        }

        [TestCase(int.MinValue, 0)]
        [TestCase(0, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue)]
        public void GetBinaryGcd_ValuesAreEqualsIntegerMinValue_ThrowArgumentOutOfRangeException(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Gcd.GetGCD(a, b));
        }

    }
}
