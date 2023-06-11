using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: BatterUp.cs
// Project name: Project3
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 03/31/2022
// ---------------------------------------------------------------------------

namespace Project3
{
    /**
    * Class Name: BatterUp <br>
    * Class Purpose: Finds a slugging percentage from a given number of at-bats and their results. <br>
    *
    * <hr>
    * Date created: 03/31/2022 <br>
    * @author Calen Cummings
    */
    class BatterUp
    {
        /**
         * Method Name: main <br>
         * Method Purpose: Reads in a number of at-bats and calculates the batter's slugging percentage based on their batting results. <br>
         *
         * <hr>
         * Date created: 03/31/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param args array of Strings (not used in this program)
         */
        static void Main(string[] args)
        {
            int divisor = Int32.Parse(Console.ReadLine());      // int value to take the number of at-bats from the input, and use to divide our total bases.
            int bases = 0;      // int value to hold the number of bases hit by the player for calculating the slugging percentage.
            string[] hits = Console.ReadLine().Split(' ');      // string array to hold our input values since they are all entered on one line.
            for (int i = 0; i < hits.Length; i++)
            {
                int value = Int32.Parse(hits[i]);       // int to capture the value of the current hit.
                if (value != -1)
                {
                    bases += value;         // adding the bases hit for calculation
                } // end if (value != -1)
                else
                {
                    divisor--;      // decreasing the divisor whenever a walk is detected so we do not average it in.
                } // end else
            } // end for (int i = 0; i < hits.Length; i++)

            double slugPercent = (double)bases / divisor;   // once the value of bases has been added and the divisor is set, perform the math; integer division requires a cast to represent as a double.

            Console.WriteLine(slugPercent);   // display the slugging percentage to the screen.  

        } // end Main(string[])
    } // end BatterUp
} // end Project3
