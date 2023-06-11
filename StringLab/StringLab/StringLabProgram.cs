using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLab
{
    class StringLabProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many strings to build?");
            int lines = Convert.ToInt32(Console.ReadLine());
            StringBuilder sb = new StringBuilder(lines);
            Console.WriteLine("Enter the strings one by one: ");
            for (int i = 0; i < lines; i++)
            {
                sb.Append(Console.ReadLine() + " ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
