using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: NineKnights.cs
// Project name: Project3c
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/01/2022
// ---------------------------------------------------------------------------

namespace Project3c
{
    /**
    * Class Name: NineKnights <br>
    * Class Purpose: Reads in a table of placed Knight chess pieces and determines if the placement is a valid solution where no knights can take another. <br>
    *
    * <hr>
    * Date created: 04/01/2022 <br>
    * @author Calen Cummings
    */
    class NineKnights
    {
        /**
         * Method Name: main <br>
         * Method Purpose: Read a user input table of knights and calculate if any knight can capture another. If so, the table is invalid. <br>
         *
         * <hr>
         * Date created: 04/01/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param args array of Strings (not used in this program)
         */
        static void Main(string[] args)
        {
            char[,] board = new char[5, 5];     // 5x5 table to represent the chess board. We can use a fixed size since we are checking the same board for the game.
            int[] knightCol = new int[9];       // int array to store the column index of a found knight so we can quickly refer back to their location and test the board.
            int[] knightRow = new int[9];       // int array to store the row index of a found knight to quickly refer back and test the board for validity.
            int knightCount = -1;                // int value to externally track through our knight arrays and increment as we find a knight.
            for (int i = 0; i < 5; i++)
            {
                string row = Console.ReadLine();    // reading in each row so we can fill in the table.
                for (int j = 0; j < 5; j++)
                {
                    board[i, j] = row[j];       // fill the board with the lines as we read them, filling each row.
                    if (row[j] == 'k')
                    {
                        knightCount++;      // increment the knights whenever we find one so we can place its indices in the arrays properly.
                        knightCol[knightCount] = j;     // store the column index of the knight.
                        knightRow[knightCount] = i;     // store the row index of the knight.
                    } // end (row[j] == 'k')
                } // end for (int j = 0; j < 5; j++)
            } // end for (int i = 0; i < 5; i++)

            if (knightCount < 8)
            {
                Console.WriteLine("\ninvalid");   // if we did not reach the ninth index in our knight arrays, then we do not have nine knights, making the board invalid.
            } // end if (knightCount < 8)
            else
            {
                bool validity = true;   // boolean value to conditionally print valid/invalid statements.
                for (int i = 0; i <= knightCount; i++)
                {
                    // for each knight, we test the possible spaces it can move to and see if another knight is present in that spot, marking an invalid solution.
                    if (knightRow[i] - 2 > -1 && knightCol[i] - 1 > -1 && board[knightRow[i] - 2, knightCol[i] - 1] == 'k')
                    {
                        Console.WriteLine("\ninvalid");     // same output for all cases; if another knight is found in "attack range" then we output "invalid" and set validity to false.
                        validity = false;
                        break;
                    } // end if (knightRow[i] - 2 > -1 && knightCol[i] - 1 > -1 && board[knightRow[i] - 2, knightCol[i] - 1] == 'k')
                    else if (knightRow[i] - 2 > -1 && knightCol[i] + 1 < 5 && board[knightRow[i] - 2, knightCol[i] + 1] == 'k')
                    {
                        Console.WriteLine("\ninvalid");
                        validity = false;
                        break;
                    } // end else if (knightRow[i] - 2 > -1 && knightCol[i] + 1 < 5 && board[knightRow[i] - 2, knightCol[i] + 1] == 'k')
                    else if (knightRow[i] - 1 > -1 && knightCol[i] - 2 > -1 && board[knightRow[i] - 1, knightCol[i] - 2] == 'k')
                    {
                        Console.WriteLine("\ninvalid");
                        validity = false;
                        break;
                    } // end else if (knightRow[i] - 1 > -1 && knightCol[i] - 2 > -1 && board[knightRow[i] - 1, knightCol[i] - 2] == 'k')
                    else if (knightRow[i] - 1 > -1 && knightCol[i] + 2 < 5 && board[knightRow[i] - 1, knightCol[i] + 2] == 'k')
                    {
                        Console.WriteLine("\ninvalid");
                        validity = false;
                        break;
                    } // end else if (knightRow[i] - 1 > -1 && knightCol[i] + 2 < 5 && board[knightRow[i] - 1, knightCol[i] + 2] == 'k')
                    else if (knightRow[i] + 1 < 5 && knightCol[i] - 2 > -1 && board[knightRow[i] + 1, knightCol[i] - 2] == 'k')
                    {
                        Console.WriteLine("\ninvalid");
                        validity = false;
                        break;
                    } // end else if (knightRow[i] + 1 < 5 && knightCol[i] - 2 > -1 && board[knightRow[i] + 1, knightCol[i] - 2] == 'k')
                    else if (knightRow[i] + 1 < 5 && knightCol[i] + 2 < 5 && board[knightRow[i] + 1, knightCol[i] + 2] == 'k')
                    {
                        Console.WriteLine("\ninvalid");
                        validity = false;
                        break;
                    } // end else if (knightRow[i] + 1 < 5 && knightCol[i] + 2 < 5 && board[knightRow[i] + 1, knightCol[i] + 2] == 'k')
                    else if (knightRow[i] + 2 < 5 && knightCol[i] - 1 > -1 && board[knightRow[i] + 2, knightCol[i] - 1] == 'k')
                    {
                        Console.WriteLine("\ninvalid");
                        validity = false;
                        break;
                    } // end else if (knightRow[i] + 2 < 5 && knightCol[i] - 1 > -1 && board[knightRow[i] + 2, knightCol[i] - 1] == 'k')
                    else if (knightRow[i] + 2 < 5 && knightCol[i] + 1 < 5 && board[knightRow[i] + 2, knightCol[i] + 1] == 'k')
                    {
                        Console.WriteLine("\ninvalid");
                        validity = false;
                        break;
                    } // end else if (knightRow[i] + 2 < 5 && knightCol[i] + 1 < 5 && board[knightRow[i] + 2, knightCol[i] + 1] == 'k')
                } // end for (int i = 0; i <= knightCount; i++)

                if (validity is true)
                {
                    Console.WriteLine("\nvalid");   // if no knights can capture one another in one move, then we have a valid solution.
                } // end if (validity is true)
            } // end else
        } // end Main(string[])
    } // end NineKnights
} // end Project3c
