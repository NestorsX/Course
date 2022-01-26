using System;

namespace GreatestCommonDivisor
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите первое число:");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите второе число:");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Выберите способ нахождения НОД:\n1 - Алгоритм Евклида\t2 - Алгоритм Стейна");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.WriteLine($"НОД({a},{b}) = {Gcd.GetGCD(a, b, out double time)} | Затраченное время: {time} мс");
                        break;
                    case 2:
                        Console.WriteLine($"НОД({a},{b}) = {Gcd.GetBinaryGCD(a, b, out double time1)} | Затраченное время: {time1} мс");
                        break;
                    default:
                        Console.WriteLine("Неверное значение. Доступны только 2 варинта нахождения НОД.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
