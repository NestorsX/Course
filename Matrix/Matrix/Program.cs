using System;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr1 = new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var arr2 = new double[3, 3] { { -3, 2, -1 }, { 4, -6, 5 }, { 8, -9, -7 } };
            try
            {
                var m1 = new Matrix(arr1);
                var m2 = new Matrix(arr2);

                Console.WriteLine("m1 + m2 = \n" + (m1 + m2));
                Console.WriteLine("m1 - m2 = \n" + (m1 - m2));
                Console.WriteLine("3 * m1 = \n" + (3 * m1));
                Console.WriteLine("m1 * m2 = \n" + (m1 * m2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
