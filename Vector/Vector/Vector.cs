using System;

namespace Vector
{
    public class Vector
    {
        private readonly double _x;

        private readonly double _y;

        private readonly double _z;

        public Vector(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double Length()
        {
            return Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }

        public static bool AreCollinear(Vector v1, Vector v2)
        {
            if (v1 is null || v2 is null)
            {
                throw new ArgumentNullException(nameof(Vector));
            }

            double x = v1._x / v2._x;
            double y = v1._y / v2._y;
            double z = v1._z / v2._z;
            return x == y && x == z;
        }

        public static bool AreOrthogonal(Vector v1, Vector v2)
        {
            if (v1 is null || v2 is null)
            {
                throw new ArgumentNullException(nameof(Vector));
            }

            return v1 * v2 == 0;
        }

        public static bool AreCoplanar(Vector v1, Vector v2, Vector v3)
        {
            if (v1 is null || v2 is null)
            {
                throw new ArgumentNullException(nameof(Vector));
            }

            return v1 * VectorProduct(v2, v3) == 0;
        }

        public static double AngleBetweenVectors(Vector v1, Vector v2)
        {
            if (v1 is null || v2 is null)
            {
                throw new ArgumentNullException(nameof(Vector));
            }

            double angle = Math.Acos((v1 * v2) / (v1.Length() * v2.Length())) * (180.0 / Math.PI);
            return angle - angle % 0.00000000000001;
        }

        public static Vector operator +(Vector lhs, Vector rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException(nameof(Vector));
            }

            return new Vector(lhs._x + rhs._x, lhs._y + rhs._y, lhs._z + rhs._z);
        }

        public static Vector operator -(Vector lhs, Vector rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException(nameof(Vector));
            }

            return new Vector(lhs._x - rhs._x, lhs._y - rhs._y, lhs._z - rhs._z);
        }

        public static Vector operator *(double a, Vector v)
        {
            if (v is null)
            {
                throw new ArgumentNullException(nameof(v));
            }

            return new Vector(v._x * a, v._y * a, v._z * a);
        }

        public static double operator *(Vector lhs, Vector rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException(nameof(Vector));
            }

            return lhs._x * rhs._x + lhs._y * rhs._y + lhs._z * rhs._z;
        }

        public static Vector VectorProduct(Vector lhs, Vector rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException(nameof(Vector));
            }

            return new Vector(
                (lhs._y * rhs._z - rhs._y * lhs._z), 
                -(lhs._x * rhs._z - rhs._x * lhs._z), 
                (lhs._x * rhs._y - rhs._x * lhs._y));
        }

        public static bool operator ==(Vector lhs, Vector rhs)
        {
            if (lhs is null || rhs is null)
            {
                return false;
            }

            return lhs._x == rhs._x && lhs._y == rhs._y && lhs._z == rhs._z;
        }

        public static bool operator !=(Vector lhs, Vector rhs)
        {
            if (lhs is null || rhs is null)
            {
                return true;
            }

            return lhs._x != rhs._x || lhs._y != rhs._y || lhs._z != rhs._z;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Vector other = obj as Vector;
            return _x == other._x && _y == other._y && _z == other._z;
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode();
        }

        public override string ToString()
        {
            return $"({_x}; {_y}; {_z})";
        }
    }
}
