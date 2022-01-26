using System.Collections.Generic;
using NUnit.Framework;

namespace Vector.Tests
{
    public sealed class TestCasesData
    {
        public static IEnumerable<TestCaseData> TestCasesForEquals
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2, 4, 4))
                    .Returns(true);
                yield return new TestCaseData(new Vector(-2, -4, -4), new Vector(-2, -4, -4))
                    .Returns(true);
                yield return new TestCaseData(new Vector(0, 0, 0), new Vector(0, 0, 0))
                    .Returns(true);
                yield return new TestCaseData(new Vector(2.67, 3.41, 4.79), new Vector(2.66, 3.42, 4.79))
                    .Returns(false);
                yield return new TestCaseData(new Vector(2.67, 3.41, 4.79), null)
                    .Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForLength
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4))
                    .Returns(6);
                yield return new TestCaseData(new Vector(-2, -4, -4))
                    .Returns(6);
                yield return new TestCaseData(new Vector(0, 0, 0))
                    .Returns(0);
                yield return new TestCaseData(new Vector(2.67, 3.41, 4.79))
                    .Returns(6.457638887395299);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAngleBetweenVectors
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2, 4, 4))
                    .Returns(0);
                yield return new TestCaseData(new Vector(0, 1, 0), new Vector(1, 1, 0))
                    .Returns(45);
                yield return new TestCaseData(new Vector(5, 9, 9), new Vector(2.5, 4.5, 4.5))
                    .Returns(0);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAdd
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2, 4, 4), new Vector(4, 8, 8));
                yield return new TestCaseData(new Vector(0, 1, 0), new Vector(1, 1, 0), new Vector(1, 2, 0));
                yield return new TestCaseData(new Vector(5, 9, 9), new Vector(2.5, 4.5, 4.5), new Vector(7.5, 13.5, 13.5));
                yield return new TestCaseData(new Vector(-5, 9, -7), new Vector(2.5, -4.5, 4.5), new Vector(-2.5, 4.5, -2.5));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForSub
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2, 4, 4), new Vector(0, 0, 0));
                yield return new TestCaseData(new Vector(0, 1, 0), new Vector(1, 1, 0), new Vector(-1, 0, 0));
                yield return new TestCaseData(new Vector(5, 9, 9), new Vector(2.5, 4.5, 4.5), new Vector(2.5, 4.5, 4.5));
                yield return new TestCaseData(new Vector(-5, 9, -7), new Vector(2.5, -4.5, 4.5), new Vector(-7.5, 13.5, -11.5));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMulByNum
        {
            get
            {
                yield return new TestCaseData(0.0, new Vector(2, 4, 4), new Vector(0, 0, 0));
                yield return new TestCaseData(2.5, new Vector(1, 1, 0), new Vector(2.5, 2.5, 0));
                yield return new TestCaseData(-10.0, new Vector(2.5, 4.5, 4.5), new Vector(-25, -45, -45));
                yield return new TestCaseData(2.5, new Vector(2.5, -4.5, 4.5), new Vector(6.25, -11.25, 11.25));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForScalarProduct
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2, 4, 4), 36.0);
                yield return new TestCaseData(new Vector(0, 1, 0), new Vector(1, 1, 0), 1.0);
                yield return new TestCaseData(new Vector(5, 9, 9), new Vector(2.5, 4.5, 4.5), 93.5);
                yield return new TestCaseData(new Vector(-5, 9, -7), new Vector(2.5, -4.5, 4.5), -84.5);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForVectorProduct
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2, 4, 4), new Vector(0, 0, 0));
                yield return new TestCaseData(new Vector(0, 1, 0), new Vector(1, 1, 0), new Vector(0, 0, -1));
                yield return new TestCaseData(new Vector(5, 9, 9), new Vector(2.5, 4.5, 4.5), new Vector(0, 0, 0));
                yield return new TestCaseData(new Vector(-5, 9, -7), new Vector(2.5, -4.5, 4.5), new Vector(9, 5, 0));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForGetHashCode
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2, 4, 4));
                yield return new TestCaseData(new Vector(0, 1, 0), new Vector(0, 1, 0));
                yield return new TestCaseData(new Vector(2.5, 4.5, 4.5), new Vector(2.5, 4.5, 4.5));
                yield return new TestCaseData(new Vector(-5.49, 9.402, -7), new Vector(-5.49, 9.402, -7));
                yield return new TestCaseData(new Vector(0, 0, 0), new Vector(0, 0, 0));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAreCollinear
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2.5, 4.5, 4.5))
                    .Returns(false);
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(8, 16, 16))
                    .Returns(true);
                yield return new TestCaseData(new Vector(5, 9, 9), new Vector(2.5, 4.5, 4.5))
                    .Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAreOrthogonal
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2.5, 4.5, 4.5))
                    .Returns(false);
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(8, 16, 16))
                    .Returns(false);
                yield return new TestCaseData(new Vector(-5, 5, 1), new Vector(1, 0, 5))
                    .Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAreCoplanar
        {
            get
            {
                yield return new TestCaseData(new Vector(2, 4, 4), new Vector(2.5, 4.5, 4.5), new Vector(8, 16, 16))
                    .Returns(true);
                yield return new TestCaseData(new Vector(1, 0, 5), new Vector(8, 16, 16), new Vector(-5, 5, 1))
                    .Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForToString
        {
            get
            {
                yield return new TestCaseData(new Vector(0.00731, 0.000402, 0.000300021))
                    .Returns("(0,00731; 0,000402; 0,000300021)");
                yield return new TestCaseData(new Vector(0.2, 3.313, 0.004))
                    .Returns("(0,2; 3,313; 0,004)");
                yield return new TestCaseData(new Vector(-0.0957, -2.2242, 10.0991))
                    .Returns("(-0,0957; -2,2242; 10,0991)");
                yield return new TestCaseData(new Vector(-14.498, -0.2046, 0.0000012))
                    .Returns("(-14,498; -0,2046; 1,2E-06)");
            }
        }
    }
}
