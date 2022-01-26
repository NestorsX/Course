using System;
using NUnit.Framework;

namespace Vector.Tests
{
    [TestFixture]
    public class VectorTests
    {
        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForLength))]
        public double VectorLength_ReturnsValue(Vector v)
        {
            return v.Length();
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAngleBetweenVectors))]
        public double VectorAngleBtwVectors_ReturnsValue(Vector v1, Vector v2)
        {
            return Vector.AngleBetweenVectors(v1, v2);
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAdd))]
        public void VectorAdd(Vector lhs, Vector rhs, Vector sum)
        {
            Assert.AreEqual(sum, lhs + rhs);
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForMulByNum))]
        public void VectorMulByNum(double a, Vector v, Vector mul)
        {
            Assert.AreEqual(mul, a * v);
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForScalarProduct))]
        public void VectorScalarProduct(Vector lhs, Vector rhs, double mul)
        {
            Assert.AreEqual(mul, lhs * rhs);
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForVectorProduct))]
        public void VectorVectorProduct(Vector lhs, Vector rhs, Vector mul)
        {
            Assert.AreEqual(mul, Vector.VectorProduct(lhs, rhs));
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForGetHashCode))]
        public void VectorAreEquals_GetHashCode(Vector lhs, Vector rhs)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lhs.GetHashCode(), rhs.GetHashCode());
                Assert.AreEqual(lhs, rhs);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool VectorEquals(Vector lhs, object rhs) => lhs.Equals(rhs);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool VectorOperatorEqual(Vector lhs, Vector rhs) => lhs == rhs;

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool VectorOperatorNotEqual(Vector lhs, Vector rhs) => !(lhs != rhs);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAreCollinear))]
        public bool VectorAreCollinear(Vector v1, Vector v2) => Vector.AreCollinear(v1, v2);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAreOrthogonal))]
        public bool VectorAreOrthogonal(Vector v1, Vector v2) => Vector.AreOrthogonal(v1, v2);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAreCoplanar))]
        public bool VectorAreCoplanar(Vector v1, Vector v2, Vector v3) => Vector.AreCoplanar(v1, v2, v3);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForToString))]
        public string VectorToString_ReturnVectorStringRepresentation(Vector v) => v.ToString();
    }
}
