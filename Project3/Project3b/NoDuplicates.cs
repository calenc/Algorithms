using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: NoDuplicates.cs
// Project name: Project3b
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 03/31/2022
// ---------------------------------------------------------------------------

namespace Project3b
{
    /**
    * Class Name: NoDuplicates <br>
    * Class Purpose: Reads in a string and determines if there are any duplicated words. <br>
    *
    * <hr>
    * Date created: 03/31/2022 <br>
    * @author Calen Cummings
    */
    class NoDuplicates
    {
        /**
         * Method Name: main <br>
         * Method Purpose: Read a user input string and determine if any duplicated words are present. <br>
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
            string[] phrase = Console.ReadLine().Split(' ');    // creating a string array of the words in the line
            bool safe = true;   // boolean value to use as a shutoff for a loop going through the phrase; cuts to false whenever a duplicate is found.

            for (int i = 0; i < phrase.Length && safe == true; i++)
            {
                if (Array.LastIndexOf(phrase, phrase[i]) != i)
                {
                    safe = false;   // if the first instance of a word is not its last in the phrase, then we have a duplicate.
                } // end if (Array.LastIndexOf(phrase, phrase[i]) != i)
            } // end for (int i = 0; i < phrase.Length; i++)

            if (safe is true)
            {
                Console.WriteLine("yes");   // write to the console that the phrase does pass the test for the game.
            } // end if (safe is true)
            else
            {
                Console.WriteLine("no");    // write to the console that the phrase did not pass the test for the game.
            } // end else

        } // end Main(string[])
    } // end NoDuplicates
} // end Project3b