using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Lab1Question2
    {
        static List<int> closestNumbers(List<int> arr)
        {
            int minDifference = 10000000;

            int[] input = arr.ToArray();
            Array.Sort(input);

            List<int> finalArray = new List<int>();

            for (int z = 1; z < arr.Count; z++)
            {
                int difference = input[z] - input[z - 1];

                if (difference < minDifference)
                {
                    finalArray.Clear();
                    minDifference = difference;
                    finalArray.Add(input[z - 1]);
                    finalArray.Add(input[z]);
                }
                else if (difference == minDifference)
                {
                    finalArray.Add(input[z - 1]);
                    finalArray.Add(input[z]);
                }
            }

            return finalArray;
        }
    }
}
