using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: PIFunction.cs
// Project name: KMPLab
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/21/2022
// ---------------------------------------------------------------------------

namespace KMPLab
{
    /**
    * Class Name: PIFunction <br>
    * Class Purpose: Utilize the KMP functions to find matches between two different strings. <br>
    *
    * <hr>
    * Date created: 04/21/2022 <br>
    * @author Calen Cummings
    */
    class PIFunction
    {
        /**
         * Method Name: main <br>
         * Method Purpose: Program reads in two strings and finds any occurrences of the pattern string in the text string. <br>
         *
         * <hr>
         * Date created: 04/21/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param args array of Strings (not used in this program)
         */
        static void Main(string[] args)
        {
            Console.Write("Enter Text: ");          // Ask user for the text.
            string text = Console.ReadLine();       // store the text as a string.
            Console.Write("Enter pattern: ");       // Ask user for the pattern.
            string pattern = Console.ReadLine();    // store the pattern as a string.

            KMP_Matcher(text, pattern);             // Find the occurrences of the pattern in the text string.
        } // end Main(string[])

        /**
         * Method Name: ComputePI <br>
         * Method Purpose: Takes a string and determines the longest possible prefix to find a pattern. <br>
         *
         * <hr>
         * Date created: 04/21/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param p, the string to find a longest-prefix for
         * @return π, the array representing the solution to prefixes in the string
         */
        public static int[] ComputePI(string p)
        {
            int[] π = new int[p.Length];        // create pi array to hold the number of character matches and determine the longest prefix.
            π[0] = 0;       // initialize the first value of the array to zero.
            int m = p.Length;   // set int m to the length of the string so we can identify when to stop looping.
            int k = 0;          // set int k to track our number of matched letters (intially 0).

            for (int q = 1; q < m; q++)
            {
                while (k > 0 && p[k] != p[q])
                {
                    k = π[k - 1];   // until we return back to a letter that matches or 0, decrement k and find where the pattern can resume.
                } // end while (k > 0 && p[k] != p[q])
                if (p[k] == p[q])
                {
                    k = k + 1;  // if the letters match, increase number of matches by 1.
                } // end if (p[k] == p[q])

                π[q] = k;   // after finding a match or not, set the value of pi at the index q to whatever k's value is.
            } // end for (int q = 1; q < m; q++)

            return π;   // return the pi array.
        } // end ComputePI

        /**
         * Method Name: KMP_Matcher <br>
         * Method Purpose: Method takes two strings and finds all occurrences of the second string that are within the first string. <br>
         *
         * <hr>
         * Date created: 04/21/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param t, the text string that will be compared to
         * @param p, the pattern string that will be used to find matches in the text
         */
        public static void KMP_Matcher(string t, string p)
        {
            int n = t.Length;       // int value to reference the length of the string t.
            int m = p.Length;       // int value to reference the length of the string p.
            int[] π = new int[m];   // create pi array for string matching.
            π = ComputePI(p);       // find the longest pattern possible in the second string entered.
            int q = 0;              // number of characters matched.

            for (int i = 0; i < n; i++)
            {
                while (q > 0 && p[q] != t[i])
                {
                    q = π[q - 1];   // current character does not match.
                } // end while (q > 0 && p[q] != t[i])

                if (p[q] == t[i])
                {
                    q = q + 1;  // current character matches.
                } // end if (p[q] == t[i])

                if (q == m)
                {
                    Console.WriteLine("Pattern found starting at shift " + (i - m + 1));  // is all of P matched?
                    q = π[q - 1];       // to cover for overlapping patterns, set q back to the longest prefix to see if the next character will continue another match or not.
                } // end if (q == m)
            } // end for (int i = 0; i < n; i++)
        } // end KMP_Matcher(string, string)
    } // end PIFunction
} // end KMPLab
