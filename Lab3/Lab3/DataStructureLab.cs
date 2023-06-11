using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class DataStructureLab
    {
        static void Main(string[] args)
        {
            int toRead = Int32.Parse(Console.ReadLine());
            //string[] lines = new string[toRead];
            //HashSet<string> lines = new HashSet<string>(StringComparer.Ordinal);
            //LinkedList<string> lines = new LinkedList<string>();
            //List<string> lines = new List<string>();
            //SortedSet<string> lines = new SortedSet<string>();
            Dictionary<string, int> lines = new Dictionary<string, int>();
            string searchTarget = "I?CXASvrg";
            //Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < toRead; i++)
            {
                //lines[i] = Console.ReadLine();    // - Array
                //lines.Add(Console.ReadLine());        // - HashSet
                //lines.AddLast(Console.ReadLine());    // - LinkedList
                //lines.Add(Console.ReadLine());    // - List
                //lines.Add(Console.ReadLine());    // - SortedSet
                String keyCheck = Console.ReadLine();   // - Dictionary
                if (lines.ContainsKey(keyCheck) == true)
                {
                    lines[keyCheck] = lines[keyCheck] + 1;
                }
                else
                {
                    lines.Add(keyCheck, 1);
                }
            }

            // Array
            //Array.Sort(lines);
            //string[] output = lines.Distinct().ToArray();
            //Stopwatch sw = Stopwatch.StartNew();
            //output.Contains(searchTarget);


            // HashSet
            //lines = new HashSet<string>(lines.OrderBy(i => i, StringComparer.Ordinal));
            //Stopwatch sw = Stopwatch.StartNew();
            //lines.Contains(searchTarget);


            // LinkedList
            //string[] shuffle = lines.ToArray();
            //Array.Sort(shuffle);
            //shuffle = shuffle.Distinct().ToArray();
            //lines.Clear();
            //foreach (string item in shuffle)
            //{
            //lines.AddLast(item);
            //}
            //Stopwatch sw = Stopwatch.StartNew();
            //lines.Contains(searchTarget);

            // List
            //lines.Sort();
            //lines = lines.Distinct().ToList();
            //Stopwatch sw = Stopwatch.StartNew();
            //lines.Contains(searchTarget);

            // SortedSet
            //Stopwatch sw = Stopwatch.StartNew();
            //lines.Contains(searchTarget);

            // Dictionary
            Stopwatch sw = Stopwatch.StartNew();
            lines.ContainsKey(searchTarget);

            sw.Stop();

            Console.WriteLine("Time to sort and remove duplicates: {0} secs", sw.Elapsed.TotalMilliseconds / 1000);
            //Console.WriteLine("Total Number of strings: {0}", lines.Count);   // - Generics
            //Console.WriteLine("Total Number of strings: {0}", output.Length);  // - Array
            //foreach (string line in output)     // - Array
            //{
                //Console.WriteLine(line);
            //}
            //foreach (string line in lines)    // - Generics
            //{
                //Console.WriteLine(line);
            //}
            foreach (var line in lines)     // - Dictionary
            {
                Console.WriteLine(line);
            }
        }
    }
}
