using System;
using System.Text;

namespace Matrix
{
    public class Matrix
    {
        private readonly double[,] _array;

        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Input array is null");
            }

            _array = new double[array.GetLength(0), array.GetLength(1)];
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    _array[i, j] = array[i, j];
                }
            }
        }

        private int GetRowsCount()
        {
            return _array.GetLength(0);
        }

        private int GetColumnsCount()
        {
            return _array.GetLength(1); 
        }

        private static void CheckMatrixObjects(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null)
            {
                throw new ArgumentNullException("Matrix is null");
            }

            if (m1.GetRowsCount() != m2.GetRowsCount() || m1.GetColumnsCount() != m2.GetColumnsCount())
            {
                throw new ArgumentException("Number of rows or columns is not equal");
            }
        }


        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            CheckMatrixObjects(m1, m2);
            double[,] newMatrix = new double[m1.GetRowsCount(), m1.GetColumnsCount()];
            for (var i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = m1._array[i, j] + m2._array[i, j];
                }
            }

            return new Matrix(newMatrix);
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            CheckMatrixObjects(m1, m2);
            double[,] newMatrix = new double[m1.GetRowsCount(), m1.GetColumnsCount()];
            for (var i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = Math.Round(m1._array[i, j] - m2._array[i, j], 10);
                }
            }

            return new Matrix(newMatrix);
        }

        public static Matrix operator *(double number, Matrix m)
        {
            if (m == null)
            {
                throw new ArgumentNullException("Matrix is null");
            }

            double[,] newMatrix = new double[m.GetRowsCount(), m.GetColumnsCount()];
            for (var i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = m._array[i, j] * number;
                }
            }

            return new Matrix(newMatrix);
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null)
            {
                throw new ArgumentNullException("Matrix is null");
            }

            if (m1.GetColumnsCount() != m2.GetRowsCount())
            {
                throw new ArgumentException("Number of columns of first matrix is not equal to number of rows of second matrix");
            }

            double[,] newMatrix = new double[m1.GetRowsCount(), m2.GetColumnsCount()];
            for (var i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = 0;
                    for (var k = 0; k < m1.GetColumnsCount(); k++)
                    {
                        newMatrix[i, j] += m1._array[i, k] * m2._array[k, j];
                    }

                    newMatrix[i, j] = Math.Round(newMatrix[i, j], 10);
                }
            }

            return new Matrix(newMatrix);
        }

        public override string ToString()
        {
            var line = new StringBuilder();
            for (var i = 0; i < GetRowsCount(); i++)
            {
                for (var j = 0; j < GetColumnsCount(); j++)
                {
                    line.Append(_array[i, j] + " ");
                }

                line.AppendLine();
            }

            return line.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Matrix matrix = obj as Matrix;
            if (matrix.GetColumnsCount() != GetColumnsCount() || matrix.GetRowsCount() != GetRowsCount())
            {
                return false;
            }

            for (var i = 0; i < GetRowsCount(); i++)
            {
                for (var j = 0; j < GetColumnsCount(); j++)
                {
                    if (Math.Abs(matrix._array[i, j] - _array[i, j]) >= double.Epsilon)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return GetRowsCount() ^ GetColumnsCount();
        }
    }
}
