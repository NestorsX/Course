using System;
using System.IO;

namespace ProtectedStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите пароль:");
                string password = Console.ReadLine();
                using (var ps = new ProtectedStream(new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\file.txt", FileMode.Open), password))
                {
                    int count = 250000;
                    byte[] array = new byte[count];
                    int data = ps.Read(array, 0, array.Length);
                    Console.WriteLine("Прочитанные байты: " + data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
