using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Polynomial
{
    public sealed class Polynomial
    {
        private readonly double[] _coefficients;

        public static AppSettings AppSettings { get; }

        public int Degree { get; }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= _coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _coefficients[index];
            }

            private set
            {
                _coefficients[index] = value;
            }
        }

        static Polynomial()
        {
            AppSettings = new AppSettings
            {
                Epsilon = double.Epsilon,
            };
        }


        public Polynomial(params double[] coefficients)
        {
            if (coefficients is null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            _coefficients = new double[coefficients.Length];
            for (var i = 0; i < coefficients.Length; i++)
            {
                _coefficients[i] = coefficients[i];
            }

            Degree = _coefficients.Length - 1;
        }

        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException(nameof(Polynomial));
            }

            var newCoefficients = new double[(lhs.Degree < rhs.Degree ? rhs.Degree : lhs.Degree) + 1];
            for (var i = 0; i <= lhs.Degree; i++)
            {
                newCoefficients[i] += lhs[i];
            }

            for (var i = 0; i <= rhs.Degree; i++)
            {
                newCoefficients[i] += rhs[i];
            }

            return new Polynomial(newCoefficients);
        }

        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            var newCoefficients = new double[(lhs.Degree < rhs.Degree ? rhs.Degree : lhs.Degree) + 1];
            for (var i = 0; i <= lhs.Degree; i++)
            {
                newCoefficients[i] += lhs[i];
            }

            for (var i = 0; i <= rhs.Degree; i++)
            {
                newCoefficients[i] -= rhs[i];
            }

            return new Polynomial(newCoefficients);
        }

        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException(nameof(Polynomial));
            }

            var result = new Polynomial(0);
            for (int i = rhs.Degree; i >= 0; i--)
            {
                var newCoefficients = new double[lhs.Degree + 1 + i];
                int h = newCoefficients.Length - 1;
                for (int j = lhs.Degree; j >= 0; j--)
                {
                    newCoefficients[h] += lhs[j] * rhs[i];
                    h--;
                }

                result += new Polynomial(newCoefficients);
            }

            return result;
        }


        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null || rhs is null)
            {
                return false;
            }

            for (var i = 0; i < lhs.Degree; i++)
            {
                if (Math.Abs(lhs[i] - rhs[i]) >= AppSettings.Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null || rhs is null)
            {
                return true;
            }

            for (var i = 0; i < lhs.Degree; i++)
            {
                if (Math.Abs(lhs[i] - rhs[i]) >= AppSettings.Epsilon)
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var polynomial = obj as Polynomial;
            if (obj == null || polynomial.Degree != Degree)
            {
                return false;
            }

            for (var i = 0; i < Degree; i++)
            {
                if (Math.Abs(polynomial[i] - this[i]) >= AppSettings.Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var value = 0.0;
            for (int i = _coefficients.Length - 1; i >= 0; i--)
            {
                value += Math.Round(_coefficients[i], 5);
            }

            return value.GetHashCode();
        }

        public override string ToString()
        {
            if (_coefficients.All(x => x == 0))
            {
                return "0";
            }

            var line = new StringBuilder();
            for (int i = _coefficients.Length - 1; i >= 0; i--)
            {
                if (Math.Round(_coefficients[i], 5) != 0)
                {
                    if (_coefficients[i] > 0 && i != _coefficients.Length - 1)
                    {
                        line.Append('+');
                    }

                    line.Append(_coefficients[i].ToString(CultureInfo.InvariantCulture));
                    if (i != 0)
                    {
                        line.Append("*x");
                        if (i > 1)
                        {
                            line.Append($"^{i}");
                        }
                    }
                }
            }

            return line.ToString();
        }

        public double CalculateValue(double x)
        {
            var value = 0.0;
            for (int i = _coefficients.Length - 1; i >= 0; i--)
            {
                value += _coefficients[i] * Math.Pow(x, i);
            }

            return value;
        }
    }

}
