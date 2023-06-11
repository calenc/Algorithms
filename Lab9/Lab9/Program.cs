using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: Program.cs
// Project name: Lab9
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/10/2022
// ---------------------------------------------------------------------------

namespace Lab9
{
    /**
    * Class Name: Program <br>
    * Class Purpose: Class to run the main method. <br>
    *
    * <hr>
    * Date created: 04/10/2022 <br>
    * @author Calen Cummings
    */
    class Program
    {
        /**
         * Method Name: main <br>
         * Method Purpose: Takes in input to create and fill a heap, and then sort and print the heap. <br>
         *
         * <hr>
         * Date created: 04/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param args array of Strings (not used in this program)
         */
        static void Main(string[] args)
        {
            int items = Convert.ToInt32(Console.ReadLine());        // Read the line to get the size.
            MaxHeap heap = new MaxHeap(items);      // create the heap.
            for (int i = 0; i < items; i++)
            {
                heap.Insert(Console.ReadLine());        // insert the current line object into the heap.
            } // end for (int i = 0; i < items; i++)

            heap.Heap_Sort();       // Sort the heap.
            Console.WriteLine(items);   // Print the number of items entered in the heap.
            heap.Print_Array();     // Print the sorted container array.
        } // end Main(string[])
    } // end Program
} // end HW8
