using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name:       PowerSumSolution.cs
// Project name:    Project2CummingsC
// ---------------------------------------------------------------------------
// Creator’s name and email:    Calen Cummings, cummingscc@etsu.edu
// Course-Section:  001
// Creation Date:   03/01/2022
// ---------------------------------------------------------------------------

namespace Project2CummingsC
{
    /**
     * Class Name: PowerSumProblem <br>
     * Class Purpose: Use the powerSum method to find the most solutions of an integer as a sum of integers to the Nth power. <br>
     *
     * <hr>
     * Date created: 03/01/2022 <br>
     * @author Calen Cummings
     */
    class PowerSumProblem
    {
        /**
         * Method Name: powerSum <br>
         * Method Purpose: Uses recursion to find the most amount of solutions for an integer as the sum of integers to the Nth power. <br>
         *
         * <hr>
         * Date created: 03/01/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions:
         * Recursion will be used to quickly find possible solutions by eliminating possible starting integers
         *
         * <hr>
         * @param X, the integer to be solved
         * @param N, the power to raise integers to
         * @param min, the minimum integer to start raising to the N power; optional argument to allow method to recursively keep track without requiring user input value.
         * @param paths, the number of ways that the initial integer can be found from a sum of integers to the Nth power; optional argument to recursively keep track and eliminate need for user definition.
         * @return int value of the number of ways that X can be solved
         */
        public static int powerSum(int X, int N, int min = 1, int paths = 0)
        {
            int sum = X - (int)Math.Pow(min, N);    // subtract our minimum starting Nth power integer from the desired sum to determine the integer's viability as a potential solution piece.

            if (sum == 0)   // if sum is 0, then we have identified the min integer to the Nth root as a solution and can return 1 to indicate a found solution.
            {
                return 1;
            } // end if (sum == 0)
            else if (sum < 0)   // if sum is negative, we have identified the path as a non-solution. While sum is still positive, we have work to do, so nothing is done in this case.
            {
                return 0;
            } // end else if (sum < 0)

            paths += powerSum(X, N, min + 1, 0);    // performing powerSum with the original integer and the updated minimum to start with, which eventually leads to the sum == 0 case if it exists for this X.
            paths += powerSum(sum, N, min + 1, 0);  // performing powerSum recursively with the decreased X value to work towards a solution path if one exists for X of integers raised to N.

            return paths;   // return the calculated number of solutions found.
        } // end powerSum(int, int, int = 1, int = 0)
    } // end PowerSumProblem
} // end Project2CummingsC
