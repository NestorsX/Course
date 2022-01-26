using System;


namespace AltMath
{
    static class AltMath
    {
        public static double Pow(double x, int degree)
        {
            double result = x;
            for (var i = 1; i < degree; i++)
            {
                result *= x;
            }

            return result;
        }

        public static double Sqrt(double x, int degree, int accuracy)
        {
            if (degree < 2)
            {
                throw new ArgumentException("Степень корня не может быть меньше, чем 2.");
            }

            if (accuracy < 1)
            {
                throw new ArgumentException("Точность не может быть меньше, чем 1.");
            }

            if ((x < 0) && (degree % 2 == 0))
            {
                throw new ArgumentException("Невозможно вычислить корень четной степени из отрицательного числа.");
            }

            double result = x;
            var prevResult = 0.0;
            while (Math.Abs(prevResult - result) >= double.Epsilon)
            {
                prevResult = result;
                result = 1.0 / degree * ((degree - 1) * result + x / Pow(result, degree - 1));
            }

            return result - result % (1.0 / Pow(10, accuracy));
        }

        public static void IsEqualToMathPow(double x, int degree, int accuracy)
        {
            double result1 = Sqrt(x, degree, accuracy);
            double result2 = Math.Pow(x, 1.0 / degree);
            result2 -= result2 % (1.0 / Pow(10, accuracy));
            Console.WriteLine($"Math.Pow: {result2}\nAltMath.Sqrt: {result1}");
            if (result1 == result2)
            {
                Console.WriteLine("Результаты сошлись");
                return;
            }

            Console.WriteLine("Результаты не сошлись");
        }
    }
}
