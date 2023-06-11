using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class CPPFaster
    {
        static void Main(string[] args)
        {
            int points = Int32.Parse(Console.ReadLine());
            Point[] values = new Point[points];

            for (int i = 0; i < points; i++)
            {
                String instring = Console.ReadLine();   
                string[] coordinates = instring.Split(' ');
                int x = 0;
                int y = 0;
                Int32.TryParse(coordinates[0], out x);
                values[i].X = x;
                Int32.TryParse(coordinates[1], out y);
                values[i].Y = y;
                Console.WriteLine(values[i].X + " " + values[i].Y);
            }

            Array.Sort(values, new PointCompareByX());

            Stopwatch sw = Stopwatch.StartNew();
            double output = closestPairFast(values);
            sw.Stop();
            Console.WriteLine("Time elapsed: {0}", sw.Elapsed.TotalMilliseconds / 1000);
            Console.WriteLine("Shortest Distance: {0}", Math.Round(output, 6));
            
        }

        public static double calcDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static double closestDistance(Point[] array)
        {
            double smallestDistance = 1000000000;
            foreach (Point p in array)
            {
                for (int i = Array.IndexOf(array, p) + 1; i < array.Length; i++)
                {
                    double distance = calcDistance(p, array[i]);

                    if (distance < smallestDistance)
                    {
                        smallestDistance = distance;
                    }
                }
            }

            return smallestDistance;
        }

        public static double overlapClosest(Point[] array, double d)
        {
            double minimumFound = d;
            Array.Sort(array, new PointCompareByY());

            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i + 1; k < array.Length && array[k].Y - array[i].Y < minimumFound; k++)
                {
                    if (calcDistance(array[i], array[k]) < minimumFound)
                    {
                        minimumFound = calcDistance(array[i], array[k]);
                    }
                }
            }

            return minimumFound;
        }

        public static double closestPairFast(Point[] array)
        {
            if (array.Length <= 3)
            {
                return closestDistance(array);
            }

            int points = array.Length;
            Point mid = array[points / 2];
            Point[] firstHalf = array.Take(points / 2).ToArray();
            Point[] secondHalf = array.Skip(points / 2).ToArray();
            
            double d1 = closestPairFast(firstHalf);
            double d2 = closestPairFast(secondHalf);

            double smallD = Math.Min(d1, d2);

            List<Point> overlap = new List<Point>();

            for (int i = 0, k = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i].X - mid.X) < smallD)
                {
                    overlap.Add(array[i]);
                    k++;
                }
            }
            Point[] strip = overlap.ToArray();
            return Math.Min(smallD, overlapClosest(strip, smallD));
        }
    }

    class PointCompareByX : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            if (p1.X > p2.X)
            {
                return 1;
            }
            else if (p1.X < p2.X)
            {
                return -1;
            }
            else
            {
                return (p1.Y > p2.Y) ? 1 : (p1.Y < p2.Y) ? -1 : 0;
            }
        }
    }

    class PointCompareByY : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            if (p1.Y > p2.Y)
            {
                return 1;
            }
            else if (p1.Y < p2.Y)
            {
                return -1;
            }
            else
            {
                return (p1.X > p2.X) ? 1 : (p1.X < p2.X) ? -1 : 0;
            }
        }
    }
}