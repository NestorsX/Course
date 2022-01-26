using System;

namespace Polynomial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите степень первого полинома:");
                int degree = Convert.ToInt32(Console.ReadLine());
                var coefficients = new double[degree + 1];
                Console.WriteLine("Вводите коэффициенты полинома начиная от младшего члена через Enter:");
                for (var i = 0; i <= degree; i++)
                {
                    coefficients[i] = Convert.ToDouble(Console.ReadLine());
                }

                var polynomial1 = new Polynomial(coefficients);
                Console.WriteLine(polynomial1.ToString());
                Console.WriteLine("Введите степень второго полинома:");
                degree = Convert.ToInt32(Console.ReadLine());
                coefficients = new double[degree + 1];
                Console.WriteLine("Вводите коэффициенты полинома начиная от младшего члена через Enter:");
                for (var i = 0; i <= degree; i++)
                {
                    coefficients[i] = Convert.ToDouble(Console.ReadLine());
                }

                var polynomial2 = new Polynomial(coefficients);
                Console.WriteLine(polynomial2.ToString());
                Console.WriteLine("p1 + p2 = " + (polynomial1 + polynomial2));
                Console.WriteLine("p1 - p2 = " + (polynomial1 - polynomial2));
                Console.WriteLine("p1 * p2 = " + (polynomial1 * polynomial2));
                Console.WriteLine("p1 = p2 - " + (polynomial1 == polynomial2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
