using System;
using System.Threading;

namespace Countdown
{
    public class Countdown
    {
        private readonly int _time;
        public event EventHandler<CountDownEventArgs> TimeIsUp;

        public Countdown(int time)
        {
            if (time <= 0)
            {
                throw new ArgumentException("Time must be greater than zero.");
            }

            _time = time;
        }

        public void Start(string message)
        {
            Thread.Sleep(_time * 1000);
            var args = new CountDownEventArgs
            {
                Message = message
            };

            TimeIsUp?.Invoke(this, args);
        }
    }
}
