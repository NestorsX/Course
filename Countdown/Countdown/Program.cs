using System;

namespace Countdown
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of seconds to wait: ");
            try
            {
                int time = Convert.ToInt32(Console.ReadLine());
                var timer = new Countdown(time);
                var tc1 = new TestClass1();
                var tc2 = new TestClass2();
                timer.TimeIsUp += (sender, e) => { Console.WriteLine($"{e.Message} | handler using lambda"); };
                timer.TimeIsUp += delegate (object sender, CountDownEventArgs e)
                {
                    Console.WriteLine($"{e.Message} | handler using delegate");
                };

                timer.TimeIsUp += tc1.OnTimeIsUp;
                timer.TimeIsUp += tc2.OnTimeIsUp;
                timer.Start($"{time} sec is up");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Time should be a number and greater than zero");
            }
        }
    }

    public class TestClass1
    {
        public void OnTimeIsUp(object sender, CountDownEventArgs e)
        {
            Console.WriteLine($"{e.Message} | handler from {GetType().Name}");
        }
    }

    public class TestClass2
    {
        public void OnTimeIsUp(object sender, CountDownEventArgs e)
        {
            Console.WriteLine($"{e.Message} | handler from {GetType().Name}");
        }
    }
}