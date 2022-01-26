using System;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
    public static class Gcd
    {
        public static int GetGCD(int a, int b)
        {
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(a));
            }

            while (b != 0)
            {
                int buff = b;
                b = a % b;
                a = buff;
            }

            return a > 0 ? a : -a;
        }

        public static int GetGCD(int a, int b, int c)
        {
            return GetGCD(GetGCD(a, b), c);
        }

        public static int GetGCD(int a, int b, int c, int d)
        {
            return GetGCD(GetGCD(a, b, c), d);
        }

        public static int GetGCD(int a, int b, int c, int d, int e)
        {
            return GetGCD(GetGCD(a, b, c, d), e);
        }

        public static int GetGCD(int a, int b, out double time)
        {
            var timer = new Stopwatch();
            timer.Start();
            int gcd = GetGCD(a, b);
            timer.Stop();
            time = timer.Elapsed.TotalMilliseconds;
            return gcd;
        }

        public static int GetBinaryGCD(int a, int b)
        {
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(a));
            }

            a = a < 0 ? -a : a;
            b = b < 0 ? -b : b;

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if (a == b)
            {
                return a;
            }

            if (a == 1 || b == 1)
            {
                return 1;
            }

            if ((a & 1) == 0)
            {
                if ((b & 1) == 0)
                {
                    return GetBinaryGCD(a >> 1, b >> 1) << 1;
                }

                return GetBinaryGCD(a >> 1, b);
            }

            if ((a & 1) != 0 && (b & 1) == 0)
            {
                return GetBinaryGCD(a, b >> 1);
            }

            return a < b ? GetBinaryGCD((b - a) >> 1, a) : GetBinaryGCD((a - b) >> 1, b);
        }

        public static int GetBinaryGCD(int a, int b, out double time)
        {
            var timer = new Stopwatch();
            timer.Start();
            int gcd = GetBinaryGCD(a, b);
            timer.Stop();
            time = timer.Elapsed.TotalMilliseconds;
            return gcd;
        }
    }
}
