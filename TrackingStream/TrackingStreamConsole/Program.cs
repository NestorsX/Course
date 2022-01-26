using System;
using System.IO;

namespace TrackingStreamConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ts = new TrackingStream(new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\file.txt", FileMode.Open)))
            {
                ts.Notify += DisplayProgress;
                int count = 935;
                byte[] array = new byte[count];
                int data = ts.Read(array, 0, count);
            }
        }

        private static void DisplayProgress(object sender, TrackingStreamEventArgs e)
        {
            Console.SetCursorPosition(0, 0);
            int percents = Convert.ToInt32((double)e.Value / (double)e.Length * 100);
            Console.WriteLine(new string('|', percents) + $" {percents}%");
        }
    }
}
