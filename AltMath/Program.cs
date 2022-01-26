using System;

namespace AltMath
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите степень корня, число, из которого хотите извлечь корень, а также точность:\nЧисло = ");
            try
            {
                double x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Степень корня = ");
                int degree = Convert.ToInt32(Console.ReadLine());
                Console.Write("Кол-во знаков после запятой = ");
                int accuracy = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Console.WriteLine($"Полученный результат: {AltMath.Sqrt(x, degree, accuracy)}");
                    Console.WriteLine($"\nСравнение результатов:");
                    AltMath.IsEqualToMathPow(x, degree, accuracy);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
