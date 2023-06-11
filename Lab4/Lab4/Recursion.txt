using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Recursion
    {
        public static int steps = 0;

        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            double result = fastPow(1, 1000);
            sw.Stop();
            Console.WriteLine(steps + " steps taken.");
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.TotalMilliseconds / 1000);
        }

        public static int fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return fib(n - 1) + fib(n - 2);
            }
        }

        public static double pow(double x, int n)
        {
            if (n <= 1)
            {
                steps++;
                return 1;
            }
            else
            {
                steps++;
                return pow(x, n - 1) * x;
            }
        }

        public static double fastPow(double x, int n)
        {
            if (n == 0)
            {
                steps++;
                return 1;
            }
            else
            {
                steps++;
                return fastPow(x, n / 2) * fastPow(x, n / 2);
            }
        }

        public static double fasterPow(double x, int n)
        {
            if (n <= 1)
            {
                steps++;
                return 1;
            }
            else if (n % 2 == 0)
            {
                steps++;
                double z = fasterPow(x, n / 2);
                return z * z;
            }
            else
            {
                steps++;
                double z = fasterPow(x, n / 2);
                return z * z * x;
            }
            
        }
    }
}
