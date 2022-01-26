using System;
using System.Linq;

namespace Triangle
{
    public class Triangle
    {
        private readonly double[] sides;
        public Triangle(double[] sides)
        {
            this.sides = sides;
            if (!CheckTriangle())
            {
                throw new ArgumentException("Triangle does not exist.");
            }

            if(double.IsPositiveInfinity(sides.Sum()))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public double Perimeter()
        {
            return sides.Sum();
        }

        public double Area()
        {
            double p = Perimeter() / 2.0;
            return Math.Sqrt(p * sides.Aggregate(1.0, (product, x) => product * (p - x)));
        }

        private bool CheckTriangle()
        {
            if (sides.Any(x => x <= 0))
            {
                return false;
            }

            for (var i = 0; i < sides.Length; i++)
            {
                if (sides[i] >= Perimeter() - sides[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
