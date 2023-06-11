using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: Lab1Question1.txt
// Project name: Lab1
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001
// Creation Date: 01/23/2022
// ---------------------------------------------------------------------------

namespace Lab1
{
   /**
    * Class Name: Lab1Question1
    * Class Purpose: Program to read through integer input and print the integer, but once 42 is read the program will stop.
    *
    * <hr>
    * Date created: 01/23/2022 <br>
    * @author Calen Cummings
    */
    class Lab1Question1
    {
        /**
         * Method Name: Main <br>
         * Method Purpose: Program will run through integer input and display the integers read until it reads the number 42. <br>
         *
         * <hr>
         * Date created: 01/23/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions:
         * N/A
         *
         * <hr>
         * @param args array of String (not used in this program)
         */
        static void Main(string[] args)
        {
            bool found = false;  // boolean value to identify when 42 is found.

            while (found == false)  // loop until 42 is found/read, at which point found will be true.
            {
                int readInt = 0;
                Int32.TryParse(Console.ReadLine(), out readInt);    // Read the line/input, and output the integer to the readInt value.

                if (readInt == 42)
                {
                    found = true;   // Once 42 is read, the program will stop running.
                } // end if (readInt == 42)
                else
                {
                    Console.WriteLine(readInt);  // As long as 42 is not read, print the read integer.
                } // end else
            } // end while (found == false)
        } // end of Main String[]
    } // end of Lab1Question1
} // end of Lab1
