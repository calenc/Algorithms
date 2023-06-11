using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing; // needed for the Point structure
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name:       ClosestTripleSolution.cs
// Project name:    Project2CummingsC
// ---------------------------------------------------------------------------
// Creator’s name and email:    Calen Cummings, cummingscc@etsu.edu
// Course-Section:  001
// Creation Date:   03/01/2022
// ---------------------------------------------------------------------------

namespace Project2CummingsC
{
    /**
     * Class Name: ClosestTripleSolution <br>
     * Class Purpose: Class to find the closest triple of any points within a given array. <br>
     *
     * <hr>
     * Date created: 03/01/2022 <br>
     * @author Calen Cummings
     */
    class ClosestTripleSolution
    {

        /**
         * Method Name: Main <br>
         * Method Purpose: Takes in an array of points and calculates the closest triple of points/smallest triangle. <br>
         *
         * <hr>
         * Date created: 03/01/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param args array of Strings (not used in this program)
         */
        static void Main(string[] args)
        {
            int points = Int32.Parse(Console.ReadLine());   // reads the first line to determine how many points are in the array
            Point[] values = new Point[points];     // creates an array of Points equal to the size of points to read

            for (int i = 0; i < points; i++)
            {
                String instring = Console.ReadLine();
                string[] coordinates = instring.Split(' ');     // each line of input is broken into an X coordinate and a Y coordinate and fed into the Point array
                int x = 0;  // int value to hold the x value for each point
                int y = 0;  // int value to hold the y value for each point
                Int32.TryParse(coordinates[0], out x);
                values[i].X = x;    // sets the line's x value as the point's x value
                Int32.TryParse(coordinates[1], out y);
                values[i].Y = y;    // sets the line's y value as the point's y value
                Console.WriteLine(values[i].X + " " + values[i].Y);     // after the x and y value are assigned, the point is printed to the display
            } // end for (int i = 0; i < points; i++)

            Array.Sort(values, new PointCompareByX());      // sorts the array by X value to make recursively finding the closest pairs easier
            Stopwatch sw = Stopwatch.StartNew();            // creates a new stopwatch and starts it
            double triangle = closestTripleFast(values);    // finds the smallest triangle (by perimeter) in the array
            sw.Stop();      // stops the stopwatch
            Console.WriteLine("Time Elapsed: {0}", sw.Elapsed.TotalMilliseconds / 1000);    // output to the console
            Console.WriteLine("Shortest Perimeter: {0}", Math.Round(triangle, 2));
        } // end Main(string[])

        /**
         * Method Name: calcDistance <br>
         * Method Purpose: Calculation method to find the distance between two points. <br>
         *
         * <hr>
         * Date created: 03/01/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param p1, the first point
         * @param p2, the second point
         */
        public static double calcDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));  // distance formula for two points
        } // end calcDistance(Point, Point)

        /**
         * Method Name: closestPerimeter <br>
         * Method Purpose: Takes a Point array and finds the smallest triangle (by perimeter) within the set. <br>
         *
         * <hr>
         * Date created: 03/01/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param array, the Point array to work
         */
        public static double closestPerimeter(Point[] array)
        {
            double smallestPerimeter = 1000000000;      // high initial value for the smallest tracker to make sure the smallest is captured
            foreach (Point p in array)
            {
                for (int i = Array.IndexOf(array, p) + 1; i < array.Length - 1; i++)
                {
                    double leg1 = calcDistance(p, array[i]);    // side length of the first distance
                    double leg2 = calcDistance(p, array[i + 1]);    // side length of the second distance
                    double leg3 = calcDistance(array[i], array[i + 1]);     // calculates the perimeter length of every possible triangle

                    double perim = leg1 + leg2 + leg3;

                    if (perim < smallestPerimeter)
                    {
                        smallestPerimeter = perim;  // when a new smallest triangle is found, set the perimeter as the smallest
                    } // end if (perim < smallestPerimeter)
                } // end for (int i = Array.IndexOf(array, p) + 1; i < array.Length - 1; i++)
            } // end foreach (Point p in array)

            return smallestPerimeter;
        } // end closestPerimeter(Point[])

        /**
         * Method Name: overlapClosest <br>
         * Method Purpose: Finds the smallest triangle (by perimeter) in the restricted box overlapping two halves of the original array. <br>
         *
         * <hr>
         * Date created: 03/01/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param array, the Point array to draw points from
         * @param d, the smallest perimeter that has already been found
         */
        public static double overlapClosest(Point[] array, double d)
        {
            double minimumFound = d;
            Array.Sort(array, new PointCompareByY());

            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i + 1; k < array.Length && array[k].Y - array[i].Y < minimumFound; k++)
                {
                    for (int j = k + 1; j < array.Length && array[j].Y - array[k].Y < minimumFound; j++)
                    {
                        double sum = 0;
                        sum += calcDistance(array[i], array[k]);
                        sum += calcDistance(array[k], array[j]);
                        sum += calcDistance(array[j], array[i]);    // calculates the distance between three points to find the perimeter of the triangle they form

                        if (sum < minimumFound)
                        {
                            minimumFound = sum;
                        } // end if (sum < minimumFound)
                    } // end for (int j = k + 1; j < array.Length && array[j].Y - array[k].Y < minimumFound; j++)
                } // end for (int k = i + 1; k < array.Length && array[k].Y - array[i].Y < minimumFound; k++)
            } // end for (int i = 0; i < array.Length; i++)

            return minimumFound;
        } // end overlapClosest(Point[], double)

        /**
         * Method Name: closestTripleFast <br>
         * Method Purpose: Takes in an array and recursively finds the smallest triangle within the set of data. <br>
         *
         * <hr>
         * Date created: 03/01/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param array, the Point array to be worked on
         */
        public static double closestTripleFast(Point[] array)
        {
            if (array.Length <= 4)
            {
                return closestPerimeter(array);     // find the smallest triangle; length <= 4 allows finding 2 or 1 triangles for faster computation
            } // end if (array.Length <= 4)

            int points = array.Length;  // points value to easily do math with the array's length
            Point mid = array[points / 2];  // mid point in the array to later refer to as our vertical divider
            Point[] firstHalf = array.Take(points / 2).ToArray();   // split the array in half for recursion
            Point[] secondHalf = array.Skip(points / 2).ToArray();  // take the second half of the array for recursion

            double t1 = closestTripleFast(firstHalf);   // finds the smallest triangle in the first half of the array
            double t2 = closestTripleFast(secondHalf);  // finds the smallest triangle in the second half of the array

            double smallT = Math.Min(t1, t2);   // finds the smaller of the two triangles to determine our smallest found so far

            List<Point> overlap = new List<Point>();    // create the overlap section to find the smallest triangle that might cross into both halves

            for (int i = 0, k = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i].X - mid.X) < smallT / 2)  // only want to concern ourselves with values that won't already exceed our smallest triangle
                {
                    overlap.Add(array[i]);  // add the point to the box that could potentially have a smaller triangle
                    k++;
                } // end if (Math.Abs(array[i].X - mid.X) < smallT / 2)
            } // end for (int i = 0, k = 0; i < array.Length; i++)
            Point[] strip = overlap.ToArray();      // convert the dynamic list to an array so we can run it through our overlap method
            return Math.Min(smallT, overlapClosest(strip, smallT));     // returns the smallest perimeter found from the separate halves and the overlap section
        } // end ClosestTripleFast(Point[])
    } // end ClosestTripleSolution

    /**
    * Class Name: PointCompareByX <br>
    * Class Purpose: Provides functionality to sort point objects by their X values. <br>
    *
    * <hr>
    * Date created: 03/10/2022 <br>
    * @author Calen Cummings (Prof. Wallace)
    */
    class PointCompareByX : IComparer<Point>    // Taken from Lab 6, provided by instructor
    {
        /**
         * Method Name: Compare <br>
         * Method Purpose: Compares two points by their X values. <br>
         *
         * <hr>
         * Date created: 03/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param p1, the first point to compare
         * @param p2, the second point to compare
         */
        public int Compare(Point p1, Point p2)
        {
            if (p1.X > p2.X)
            {
                return 1;
            } // end if (p1.X > p2.X)
            else if (p1.X < p2.X)
            {
                return -1;
            } // end else if (p1.X < p2.X)
            else
            {
                return (p1.Y > p2.Y) ? 1 : (p1.Y < p2.Y) ? -1 : 0;
            } // end else
        } // end Compare(Point, Point)
    } // end PointCompareByX

    /**
    * Class Name: PointCompareByY <br>
    * Class Purpose: Provides functionality to sort point objects by their Y values. <br>
    *
    * <hr>
    * Date created: 03/10/2022 <br>
    * @author Calen Cummings (Prof. Wallace)
    */
    class PointCompareByY : IComparer<Point> // Taken from Lab 6, provided by instructor
    {
        /**
         * Method Name: Compare <br>
         * Method Purpose: Compares two points by their Y values. <br>
         *
         * <hr>
         * Date created: 03/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param p1, the first point to compare
         * @param p2, the second point to compare
         */
        public int Compare(Point p1, Point p2)
        {
            if (p1.Y > p2.Y)
            {
                return 1;
            } // end if (p1.Y > p2.Y)
            else if (p1.Y < p2.Y)
            {
                return -1;
            } // end else if (p1.Y < p2.Y)
            else
            {
                return (p1.X > p2.X) ? 1 : (p1.X < p2.X) ? -1 : 0;
            } // end else
        } // end Compare(Point, Point)
    } // end PointCompareByY : IComparer<Point>
} // end Project2CummingsC
