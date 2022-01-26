using System;

namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите сторону A:");
                double a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите сторону B:");
                double b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите сторону C:");
                double c = Convert.ToInt32(Console.ReadLine());
                var triangle = new Triangle(new double[] {a, b, c});
                Console.WriteLine($"Периметр треугольника: {triangle.Perimeter()}");
                Console.WriteLine($"Площадь треугольника: {triangle.Area()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}