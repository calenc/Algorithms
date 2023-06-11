using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class MergeLab
    {
        static void Main(string[] args)
        {
            int doublesToSort;
            Int32.TryParse(Console.ReadLine(), out doublesToSort);

            double[] values = new double[doublesToSort];
            for (int i = 0; i < doublesToSort; i++)
            {
                double current = 0;
                Double.TryParse(Console.ReadLine(), out current);
                values[i] = current;
            }

            Stopwatch sw = Stopwatch.StartNew();
            values = MergeSort(values);
            sw.Stop();

            Console.WriteLine("Time to sort: {0}", sw.Elapsed.TotalMilliseconds / 1000);
            foreach (double number in values)
            {
                Console.WriteLine(number);
            }
        }

        public static double[] MergeSort(double[] C)
        {
            if (C.Length != 1)
            {
                int half = C.Length / 2;
                double[] first = C.Take(half).ToArray();
                double[] second = C.Skip(half).ToArray();

                return Merge(MergeSort(first), MergeSort(second));
            }
            else
            {
                return C;
            }
        }
        
        public static double[] Merge(double[] A, double[] B)
        {
            double[] mergedResult = new double[A.Length + B.Length];
         
            for (int i = 0, k = 0, m = 0; m < mergedResult.Length; m++)
            {
                if (i < A.Length && k < B.Length)
                {
                    if (A[i] <= B[k])
                    {
                        mergedResult[m] = A[i];
                        i++;
                    }
                    else
                    {
                        mergedResult[m] = B[k];
                        k++;
                    }
                }
                else if (i < A.Length)
                {
                    mergedResult[m] = A[i];
                    i++;
                }
                else if (k < B.Length)
                {
                    mergedResult[m] = B[k];
                    k++;
                }
            }

            return mergedResult;
        }
    }
}
