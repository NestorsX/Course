using System;

namespace Vector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите координаты первого вектора:\nX: ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Y: ");
                double y = Convert.ToDouble(Console.ReadLine());
                Console.Write("Z: ");
                double z = Convert.ToDouble(Console.ReadLine());
                var v1 = new Vector(x, y, z);
                Console.Write("Координаты второго вектора:\nX: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Y: ");
                y = Convert.ToDouble(Console.ReadLine());
                Console.Write("Z: ");
                z = Convert.ToDouble(Console.ReadLine());
                var v2 = new Vector(x, y, z);
                Console.Write("Координаты третьего вектора:\nX: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Y: ");
                y = Convert.ToDouble(Console.ReadLine());
                Console.Write("Z: ");
                z = Convert.ToDouble(Console.ReadLine());
                var v3 = new Vector(x, y, z);
                Console.WriteLine("V1 = " + v1);
                Console.WriteLine("V2 = " + v2);
                Console.WriteLine("V3 = " + v3);
                Console.WriteLine("V1 length = " + v1.Length());
                Console.WriteLine("V2 length = " + v2.Length());
                Console.WriteLine("V3 length = " + v3.Length());
                Console.WriteLine("V1 + V2 = " + (v1 + v2));
                Console.WriteLine("V1 - V2 = " + (v1 - v2));
                Console.WriteLine("V1 - V2 + V3 = " + (v1 - v2 + v3));
                Console.WriteLine("3 * V1 = " + (3 * v1));
                Console.WriteLine("0.5 * V2 = " + (0.5 * v2));
                Console.WriteLine("-V3 = " + (-1 * v3));
                Console.WriteLine("Scalar product: V1 * V2 = " + (v1 * v2));
                Console.WriteLine("Vector product: V1 x V2 = " + (Vector.VectorProduct(v1, v2)));
                Console.WriteLine("Mixed product: V1 * (V2 x V3) = " + (v1 * Vector.VectorProduct(v2, v3)));
                Console.WriteLine("Are V1 and V2 collinear: " + Vector.AreCollinear(v1, v2));
                Console.WriteLine("Are V1 and V2 orthogonal: " + Vector.AreOrthogonal(v1, v2));
                Console.WriteLine("Are V1, V2 and V3 coplanar: " + Vector.AreCoplanar(v1, v2, v3));
                Console.WriteLine("Angle (in degrees) between V1 and V2 = " + Vector.AngleBetweenVectors(v1, v2));
                Console.WriteLine("V1 == V2: " + (v1 == v2));
                Console.WriteLine("V1 != V2: " + (v1 != v2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
