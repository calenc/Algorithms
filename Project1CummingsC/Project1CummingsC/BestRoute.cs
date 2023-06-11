using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;   // used to create a stopwatch timer for the program
using System.Numerics;      // used to create a stopwatch timer for the program
// ---------------------------------------------------------------------------
// File name: BestRoute.cs
// Project name: Project1CummingsC
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 01/25/2022
// ---------------------------------------------------------------------------

namespace Project1CummingsC
{
    /**
    * Class Name: BestRoute <br>
    * Class Purpose: Determine the shortest/most optimal path from a given set of coordinate points. <br>
    *
    * <hr>
    * Date created: 01/25/2022 <br>
    * @author Calen Cummings
    */
    class BestRoute
    {
        /**
         * Method Name: main <br>
         * Method Purpose: Program that will accept coordinate points as input and determine the most optimal route through the points and back to the origin. <br>
         *
         * <hr>
         * Date created: 01/25/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param args array of Strings (not used in this program)
         */
        static void Main(string[] args)
        {
            int points = Int32.Parse(Console.ReadLine());   // reads the first line to determine how many data points will be entered/need to be read in
            int[] x = new int[points];    // array to store x values; size set to the number of coordinate points
            int[] y = new int[points];    // array to store y values; size set to the number of coordinate points
            double[,] distances = new double[points + 1, points + 1];      // 2d array to store all distances between the points, size of points + 1 to include distance from origin calculations
            int[] permuteArray = new int[points];    // array to hold a basic array for us to generate permutations
            int[] solutionPath = new int[points];  // array to hold our solution for output
            double pathDistance;   // int value to hold the path length
            double shortestPath = 1000000000;     // int value to hold the current shortest path distance found; initialized high to guarantee capture of first distance

            for (int i = 0; i < points; i++)
            {
                String instring = Console.ReadLine();   // read the line to get the x and y coordinates for the point
                string[] values = instring.Split(' ');  // breaks apart the string so we can isolate and store each coordinate as an integer
                Int32.TryParse(values[0], out x[i]);    // stores the first value as the x value in the x array
                Int32.TryParse(values[1], out y[i]);    // stores the second value as the y value in the y array
                permuteArray[i] = i + 1;                // add i + 1 with each point so we can reference the point's value in a table (first point read is equal to "1")
                                                        // This allows us to find permutations without having to manipulate whole coordinate points
            } // end for (int i = 0; i < points; i++)

            fillTable(x, y, distances);     // fills the table to reference the distances between all points
            
            Stopwatch sw = Stopwatch.StartNew(); // creates sw and starts stopwatch

            while (permuteArray[0] != permuteArray.Max())
            {
                if (permuteArray[0] < permuteArray[points - 1])
                {
                    pathDistance = 0;
                    pathDistance += distances[0, permuteArray[0]];  // add the distance from the origin to the starting point

                    for (int i = 0; i < permuteArray.Length - 1; i++)
                    {
                        pathDistance += distances[permuteArray[i], permuteArray[i + 1]];    // add the distance between points to the path distance
                        if (pathDistance > shortestPath)
                        {
                            break;  // once we pass our shortest distance, there is no need to continue calculating
                        } // end if (pathDistance > shortestPath)
                    } // for (int i = 0; i < permuteArray.Length - 1; i++)

                    pathDistance += distances[0, permuteArray[permuteArray.Length - 1]];     // add the distance to the origin again at the end since we must return there

                    if (pathDistance < shortestPath)
                    {
                        shortestPath = pathDistance;
                        Array.Copy(permuteArray, solutionPath, points);     // copies the current permutation into the solution array for our path
                    } // end if (pathDistance < shortestPath)
                } // end if (permuteArray[0] < permuteArray[points - 1])
                
                permuteArray = nextPerm(permuteArray);
            } // end while (permuteArray[0] != permuteArray.Max())

            sw.Stop();  // stops the stopwatch
            Console.WriteLine("Shortest Route: {0}", Math.Round(shortestPath, 2));
            Console.WriteLine("Time Elapsed: {0}", sw.Elapsed.TotalMilliseconds / 1000);
            string output = "0 ";    // string to display our solution array as output; starts with 0 to indicate starting at the origin
            for (int i = 0; i < solutionPath.Length; i++)
            {
                output += solutionPath[i].ToString() + " ";
            } // end for (int i = 0; i < solutionPath.Length; i++)
            Console.WriteLine("Optimal Route: {0}", output);
        } // end Main(string[])

        /**
         * Method Name: pointDistance <br>
         * Method Purpose: Finds the distance between two points. <br>
         *
         * <hr>
         * Date created: 02/02/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param x1 - the x value of the first point
         * @param y1 - the y value of the first point
         * @param x2 - the x value of the second point
         * @param y2 - the y value of the second point
         * @return distance - the value of the calculated distance between the two points
         */
        private static double pointDistance(int x1, int y1, int x2, int y2)
        {
            double xSquared = Math.Pow((x2 - x1), 2);   // Calculates the change in x from the two points, and squares it
            double ySquared = Math.Pow((y2 - y1), 2);   // Calculates the change in y from the two points, and squares it
            double distance = Math.Sqrt(xSquared + ySquared);   // Calculates the square root of the added values to find the distance between the points

            return distance;
        } // end pointDistance(int, int, int, int)

        /**
         * Method Name: distFromOrigin <br>
         * Method Purpose: Finds the distance between a point and the origin so that we don't need to include the origin as a point in the permutation. <br>
         *
         * <hr>
         * Date created: 02/02/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param x - the x value of the point
         * @param y - the y value of the point
         * @return distance - the value of the calculated distance between the point and the origin
         */
        private static double distFromOrigin(int x, int y)
        {
            double xSquared = Math.Pow(x, 2);   // Calculates the change in x from the point to the origin (x - 0), and squares it
            double ySquared = Math.Pow(y, 2);   // Calculates the change in y from the point to the origin (y - 0), and squares it
            double distance = Math.Sqrt(xSquared + ySquared);   // Calculates the square root of the added values to find the distance between the points

            return distance;
        } // end distFromOrigin(int, int)

        /**
         * Method Name: nextPerm <br>
         * Method Purpose: Takes an array and generates the next permutation of the data values. <br>
         *
         * <hr>
         * Date created: 02/03/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param array - array of values to be permuted
         * @return array - the next permutation of the array that was taken in
         */
        private static int[] nextPerm(int[] array)
        {
            int count = array.Length - 1;   // counter set to the length - 1 so we can start the loop with the last element in the array
            int temp;       // temp value to hold the index of the value to be moved to create the next permutation. Set to an arbitrary value
            for (int i = count; i > 0; i--)
            {
                if (array[i] > array[i - 1])    // i - 1 will be the index of the number that we need to swap around
                {
                    temp = array[i - 1];    
                    
                    for (int j = count; j >= i; j--)
                    {
                        if (array[j] > temp)    // find the first value larger than the one we need to swap, then swap the values
                        {
                            array[i - 1] = array[j];
                            array[j] = temp;
                            Array.Reverse(array, i, array.Length - i);  // reverse the back part of the array so that the next ordinal permutation is generated
                            break;
                        } // end if (array[j] > temp)
                    } // end for (int j = count; j >= i; j--)
                    
                    break;
                } // if (array[i] > array[i - 1])
            } // end for (int i = count; i > 0; i--)

            return array;
        } // end nextPerm(int[])

        /**
         * Method Name: fillTable <br>
         * Method Purpose: Takes array parameters and calculates all distances between points, filling the values into a 2d array to reference. <br>
         *
         * <hr>
         * Date created: 02/03/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions:
         * The table considers the location [0,0] to be the origin starting point of the path. Referencing the table for a distance between two points
         * directly correlates to the point's "physical location" in the coordinate array ( table[0, 1] would be the distance from the origin to the FIRST point
         * that was read in, table[2, 5] would be the distance from the SECOND point read to the FIFTH point read). 
         * This allows us to store origin distances without having to account for the origin in any permutations.
         *
         * <hr>
         * @param x - array of x values for the points
         * @param y - array of y values for the points
         * @param table - 2d array to store the values calculated
         */
        private static void fillTable(int[] x, int[] y, double[,] table)
        {
            int count = x.Length;   // counter set to the length of one of the arrays, to stop our loop

            table[0, 0] = 0;    // setting the origin in position 0, 0 for the table

            double originDist;      // distance value to hold distance from origin for each point
            double pointToPoint;    // distance value to hold the distance between a pair of points
            for (int i = 0; i < count; i++)
            { 
                originDist = distFromOrigin(x[i], y[i]);    // this section finds the point distance from the origin and adds it to the table
                table[0, i + 1] = originDist;               // because [0, 0] for the table represents the origin, we can fill both the 0 row and 0 column with the origin distances
                table[i + 1, 0] = originDist;

                for (int j = i + 1; j < count; j++)
                {
                    pointToPoint = pointDistance(x[i], y[i], x[j], y[j]);   // calculate distance between the points, and store in the table.
                    table[i + 1, j + 1] = pointToPoint;                     // again, because the table indexes represent the two points being compared, we can assign the found distance to the mirrored row/column
                    table[j + 1, i + 1] = pointToPoint;                     // the + 1 offset is to account for the origin included in the table
                } // end for (int j = i + 1; j < count; j++)
            } // for (int i = 0; i < count; i++)
        } // end fillTable(int[], int[], int[,])
    } // end BestRoute
} // Project1CummingsC
