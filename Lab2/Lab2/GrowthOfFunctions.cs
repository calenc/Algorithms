using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace Lab2
{
    class GrowthOfFunctions
    {
        private static void nsquaredgrowthversion1(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum++;
                }
            }
        }

        private static void lgnGrowthVersion1(BigInteger n)
        {
            BigInteger sum = 0;
            for (BigInteger i = 1; i < n; i *= 2)
            {
                sum++;
            }
        }

        private static void nGrowthVersion1(BigInteger n)
        {
            BigInteger sum = 0;
            for (BigInteger i = 0; i < n; i++)
            {
                sum++;
            }
        }

        private static void nlgnGrowthVersion1(BigInteger n)
        {
            BigInteger sum = 0;
            for (BigInteger i = 0; i < n; i++)
            {
                for (BigInteger k = 1; k < n; k *= 2)
                {
                    sum++;
                }
            }
        }

        private static void nSquaredGrowthVersion2(BigInteger n)
        {
            BigInteger sum = 0;
            for (BigInteger i = 0; i < n; i++)
            {
                for (BigInteger k = 0; k < n; k++)
                {
                    sum++;
                }
            }
        }

        private static void nCubedGrowthVersion1(BigInteger n)
        {
            BigInteger sum = 0;
            for (BigInteger i = 0; i < n; i++)
            {
                for (BigInteger d = 0; d < n; d++)
                {
                    for (BigInteger k = 0; k < n; k++)
                    {
                        sum++;
                    }
                }
            }
        }

        private static void nFourthGrowthVersion1(BigInteger n)
        {
            BigInteger sum = 0;
            for (BigInteger i = 0; i < n; i++)
            {
                for (BigInteger g = 0; g < n; g++)
                {
                    for (BigInteger f = 0; f < n; f++)
                    {
                        for (BigInteger e = 0; e < n; e++)
                        {
                            sum++;
                        }
                    }
                }
            }
        }

        private static void twoExponentNGrowthVersion1(int n)
        {
            BigInteger computed = BigInteger.Pow(2, n);
            nGrowthVersion1(computed);
        }

        private static void nFactorialGrowthVersion1(BigInteger n)
        {
            BigInteger count = 1;
            for (BigInteger i = 2; i < n; i++)
            {
                count = count * i;
            }

            nGrowthVersion1(count);
        }

        static void Main(string[] args)
        {
            BigInteger n;
            Console.WriteLine("Please enter an integer for n: ");
            BigInteger.TryParse(Console.ReadLine(), out n);
            Stopwatch sw =  Stopwatch.StartNew();  
            lgnGrowthVersion1(n);
            sw.Stop();  
            Console.WriteLine("Time used: {0} secs", sw.Elapsed.TotalMilliseconds / 1000);
        }
    }
}
