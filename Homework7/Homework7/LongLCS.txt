using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: LongLCS.cs
// Project name: Homework7
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/03/2022
// ---------------------------------------------------------------------------

namespace Homework7
{
    /**
    * Class Name: LongLCS <br>
    * Class Purpose: Find the LCS of arbitrarily long strings. <br>
    *
    * <hr>
    * Date created: 04/03/2022 <br>
    * @author Calen Cummings
    */
    class LongLCS
    {
        /**
         * Method Name: main <br>
         * Method Purpose: Program reads in two strings and finds the LCS between them, even for arbitrarily long strings that make solving with a table worthless. <br>
         *
         * <hr>
         * Date created: 04/03/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param args array of Strings (not used in this program)
         */
        static void Main(string[] args)
        {
            string first = Console.ReadLine();      // read the first string from the input.
            string second = Console.ReadLine();     // read the second string from the input.
            int firstSize = first.Length;       // int value to hold the length of the first string entered.
            int secondSize = second.Length;     // int value to hold the length of the second string entered.

            int[] row1 = new int[secondSize + 1];     // create first row to begin LCS comparing
            int[] row2 = new int[secondSize + 1];     // create second row to begin LCS comparing; we only need two rows to increment through the LCS table and find the solution length.
            int[] reset = new int[secondSize + 1];    // third array that will act as a way to clear out the second row as if we are moving down the LCS table.

            for (int j = 1; j < firstSize + 1; j++)
            {
                for (int g = 1; g < secondSize + 1; g++)
                {
                    if (first[j - 1].Equals(second[g - 1]))
                    {
                        row2[g] = row1[g - 1] + 1;   // set the current column value in row2 by taking the diagonal value and add 1.
                    } // end if (first[j - 1].Equals(second[g - 1]))
                    else if (!first[j - 1].Equals(second[g - 1]) && row1[g] > row2[g - 1])
                    {
                        row2[g] = row1[g];      // set the current column value in row2 to the value in the above row.
                    } // end else if (!first[j - 1].Equals(second[g - 1]) && row1[g] > row2[g - 1])
                    else if (!first[j - 1].Equals(second[g - 1]) && row1[g] < row2[g - 1])
                    {
                        row2[g] = row2[g - 1];  // set the current column value in row2 to the value in the previous column.
                    } // end else if (!first[j - 1].Equals(second[g - 1]) && row1[g] < row2[g - 1])
                    else if (!first[j - 1].Equals(second[g - 1]) && row1[g] == row2[g - 1])
                    {
                        row2[g] = row1[g];      // set the current column value in row2 to the value in above row.
                    } // end else if (!first[j - 1].Equals(second[g - 1]) && row1[g] == row2[g - 1])
                } // end for (int g = 1; g < secondSize + 1; g++)

                if (j < firstSize)
                {
                    Array.Copy(row2, row1, secondSize + 1);        // set the first row to the second row as though we were moving down through the whole LCS table.
                    Array.Copy(reset, row2, secondSize + 1);       // set the second row back to an empty one as if we were moving through a whole LCS table.
                } // end if (j < firstSize)
            } // end for (int j = 1; j < firstSize + 1; j++)

            int lcs = row2[secondSize];     // the value in the last row, last column of the LCS solution table is the length of the solution.

            Console.WriteLine(lcs);     // print the LCS count to the console.
        } // end Main(string[])
    } // end LongLCS
} // end Homework7
