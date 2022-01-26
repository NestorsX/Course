using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Matrix.Tests
{
    [TestClass]
    public class MatrixTests
    {
        public static IEnumerable<object[]> DataForSum
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 2, 4 }, { 6, 8 }, { 10, 12 } })
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1, 2 }, { -3, 4 }, { 5.2, 6 } }),
                        new Matrix(new double[,] { { -1, 2.4 }, { 3.5, 4 }, { 5, -6 } }),
                        new Matrix(new double[,] { { 0, 4.4 }, { 0.5, 8 }, { 10.2, 0 } })
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }),
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } })
                    }
                };
            }
        }

        public static IEnumerable<object[]> DataForSubstruct
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } })
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1, 2 }, { -3, 4 }, { 5.2, 6 } }),
                        new Matrix(new double[,] { { -1, 2.4 }, { 3.5, 4 }, { 5, -6 } }),
                        new Matrix(new double[,] { { 2, -0.4 }, { -6.5, 0 }, { 0.2, 12 } })
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } }),
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } })
                    }
                };
            }
        }

        public static IEnumerable<object[]> DataForMultiply
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } }),
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 22, 28 }, { 49, 64 } })
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1.1, 3, 5 }, { 7, 7.3, 5.3 }, { 3, 1, 6 } }),
                        new Matrix(new double[,] { { 8, 9, 5.59, 23 }, {7, 5.678, 9, 4 }, {3.987, 5, 8.14, 5 } }),
                        new Matrix(new double[,] { { 49.735, 51.934, 73.849, 62.3 }, { 128.2311, 130.9494, 147.972, 216.7 }, { 54.922, 62.678, 74.61, 103 } })
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1.1, 3, 5 }, { 7, 7.3, 5.3 }, { 3, 1, 6 } }),
                        new Matrix(new double[,] { { 1.1 }, { 1.11 }, { 1.111 } }),
                        new Matrix(new double[,] { { 10.095 }, { 21.6913 }, { 11.076 } })
                    }
                };
            }
        }

        public static IEnumerable<object[]> DataForMultiplyByNumber
        {
            get
            {
                return new[]
                {
                    new object[] {
                        3.58,
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 3.58, 7.16 }, { 10.74, 14.32 }, { 17.9, 21.48 } })
                    },
                    new object[] {
                        4.0,
                        new Matrix(new double[,] { { 8, 9, 5.59, 23 }, {7, 5.678, 9, 4 }, {3.987, 5, 8.14, 5 } }),
                        new Matrix(new double[,] { { 32, 36, 22.36, 92 }, { 28, 22.712, 36, 16 }, { 15.948, 20, 32.56, 20 } })
                    },
                    new object[] {
                        0.0,
                        new Matrix(new double[,] { { 1.1 }, { 1.11 }, { 1.111 } }),
                        new Matrix(new double[,] { { 0 }, { 0 }, { 0 } })
                    }
                };
            }
        }

        public static IEnumerable<object[]> DataForEquals
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        true
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1.1, 3, 5 }, { 7, 7.3, 5.3 }, { 3, 1, 6 } }),
                        new Matrix(new double[,] { { 8, 9, 5.59, 23 }, {7, 5.678, 9, 4 }, {3.987, 5, 8.14, 5 } }),
                        false
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1.1 }, { 1.11 }, { 1.111 } }),
                        new Matrix(new double[,] { { 0 }, { 0 }, { 0 } }),
                        false
                    }
                };
            }
        }

        public static IEnumerable<object[]> DataForSumWithException
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }),
                        new Matrix(new double[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 5, 6, 7 } })
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1.1, 3, 5 }, { 7, 7.3, 5.3 }, { 3, 1, 6 } }),
                        new Matrix(new double[,] { { 8, 9 }, {7, 8 }, {3.987, 5 } })
                    },
                    new object[] {
                        new Matrix(new double[,] { { 1.1 }, { 1.11 } }),
                        new Matrix(new double[,] { { 0 }, { 0 }, { 0 } })
                    }
                };
            }
        }

        [TestMethod]
        [DynamicData("DataForSum")]
        public void MatrixSum_ReturnsValue(Matrix m1, Matrix m2, Matrix expected)
        {
            Assert.AreEqual(expected, m1 + m2);
        }

        [TestMethod]
        [DynamicData("DataForSubstruct")]
        public void MatrixSub_ReturnsValue(Matrix m1, Matrix m2, Matrix expected)
        {
            Assert.AreEqual(expected, m1 - m2);
        }

        [TestMethod]
        [DynamicData("DataForMultiply")]
        public void MatrixMul_ReturnsValue(Matrix m1, Matrix m2, Matrix expected)
        {
            Assert.AreEqual(expected, m1 * m2);
        }

        [TestMethod]
        [DynamicData("DataForMultiplyByNumber")]
        public void MatrixMulByNum_ReturnsValue(double num, Matrix m, Matrix expected)
        {
            Assert.AreEqual(expected, num * m);
        }

        [TestMethod]
        [DynamicData("DataForEquals")]
        public void MatrixEquals_ReturnsValue(Matrix m1, Matrix m2, bool expected)
        {
            Assert.AreEqual(expected, m1.Equals(m2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Array is null")]
        public void MatrixConstructor_ThrowsArgumentNullException()
        {
            var matrix = new Matrix(null);
        }

        [TestMethod]
        [DynamicData("DataForSumWithException")]
        [ExpectedException(typeof(ArgumentException), "Number of rows or columns is not equal")]
        public void MatrixSum_ThrowsArgumentException(Matrix m1, Matrix m2)
        {
            var m3 = m1 + m2;
        }
    }
}
