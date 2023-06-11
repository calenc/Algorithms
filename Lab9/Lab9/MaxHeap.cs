using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: MaxHeap.cs
// Project name: Lab9
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/10/2022
// ---------------------------------------------------------------------------

namespace Lab9
{
    /**
    * Class Name: MaxHeap <br>
    * Class Purpose: Class of Max-Heap objects. <br>
    *
    * <hr>
    * Date created: 04/10/2022 <br>
    * @author Calen Cummings
    */
    class MaxHeap
    {
        private int max_size;   // private attribute to represent the maximum size of the heap.
        private int size;       // private int to represent the current size of the heap.
        private string[] h;     // array of strings that the heap will use

        /**
         * Method Name: MaxHeap <br>
         * Method Purpose: Constructor method that will instantiate a MaxHeap object and fill it with initial values from the parameter value. <br>
         *
         * <hr>
         * Date created: 04/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param totalSize; int value that will determine the maximum size of the heap.
         */
        public MaxHeap(int totalSize)
        {
            size = 0;                           // initial size of the empty heap is zero.
            max_size = totalSize + 1;           // maximum size is equal to the input + 1 (not using the 0 index).
            h = new string[totalSize + 1];      // array to hold the string objects of the heap.
        } // end MaxHeap(int)

        /**
         * Method Name: Print <br>
         * Method Purpose: Prints the current heap to the console window. <br>
         *
         * <hr>
         * Date created: 04/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * 
         */
        public void Print()
        {
            for (int i = 1; i < size + 1; i++)
            {
                Console.WriteLine("{0}", h[i]);    // print each item in the heap.
            } // end for (int i = 1; i < size + 1; i++)
        } // end Print()


        /**
         * Method Name: Insert <br>
         * Method Purpose: Method to insert an item into an existing MaxHeap object and fix the heap after inserting. <br>
         *
         * <hr>
         * Date created: 04/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param item; string value that will be inserted into the heap. 
         */
        public void Insert(string item)
        {
            size++;                 // increment the size of the heap by 1 for adding an object.
            h[size] = item;         // placing the item at the end of the current heap.
            int current = size;     // int value to easily move through the heap nodes and fix the heap after inserting.
            while (current != 1 && String.CompareOrdinal(h[current], h[current / 2]) > 0)
            {
                string temp = "";               // temporary value to hold our place and swap nodes correctly.
                temp = h[current / 2];          // assign the parent node to the temp value.
                h[current / 2] = h[current];    // swap the parent and current child node.
                h[current] = temp;              // set the child node as the original parent node value.

                current = current / 2;          // update the current value so we can start with the correct node in the next loop.
            } // end while (current != 1 && String.CompareOrdinal(h[current], h[current / 2]) > 0)
        } // end Insert(string)

        /**
         * Method Name: Extract_Max <br>
         * Method Purpose: Removes the maximum value from the heap to sort it within the container array. <br>
         *
         * <hr>
         * Date created: 04/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         *  
         */
        public void Extract_Max()
        {
            string temp = "";   // temporary string so we can swap the first and last elements in the array.
            temp = h[1];        // hold the value of the top node before swapping.
            h[1] = h[size];     // set the top node to the value of the last node.
            h[size] = temp;     // set the last node to the max value that was at the top of the heap.
            size--;             // decrease size by 1 so we have effectively removed the node from the heap while leaving it in the container array.

            int current = 1;    // starting at the top of the heap, fix it until the max-heap property is restored.
            while (current <= size / 2 && String.CompareOrdinal(h[current], h[current * 2]) < 0 || current <= size / 2 && String.CompareOrdinal(h[current], h[current * 2 + 1]) < 0)
            {
                string firstChild = h[current * 2];           // store the first child node as a char value.
                string secondChild = h[current * 2 + 1];      // store the second child node as a char value.
                string bigChild = "";        // placeholder string value for the larger of the two children.
                string smallChild = "";      // placeholder string value for the smaller of the two children.
                if (String.CompareOrdinal(firstChild, secondChild) > 0)
                {
                    bigChild = firstChild;          // if first child is bigger, set it as big child.
                    smallChild = secondChild;       // set smaller child.
                } // end if (String.CompareOrdinal(firstChild, secondChild) > 0)
                else
                {
                    bigChild = secondChild;     // if second child is bigger, set it as big child.
                    smallChild = firstChild;    // set smaller child.
                } // end else
                int childSpot = Array.IndexOf(h, bigChild);     // int to hold the index of the child node that will be used to switch.
                if (childSpot > size)
                {
                    childSpot = Array.IndexOf(h, smallChild);   // if the larger child node is outside of the heap, assign the smaller child as the one to compare to.
                }// end if (childSpot > size)

                if (String.CompareOrdinal(h[childSpot], h[current]) > 0)
                {
                    string holder = "";     // temporary string to hold the value of the parent that we need to switch.
                    holder = h[current];    // holding the value of the parent node to be moved down.
                    h[current] = h[childSpot];     // assigning the larger child value found to the parent node.
                    h[childSpot] = holder;         // finishing the swap of parent and child node values. 
                } // end if (String.CompareOrdinal(h[childSpot], h[current]) > 0)

                current = childSpot;        // moving current to the node that we just swapped our minimum value into so we can continue fixing the heap.
            } // end while (current <= size / 2 && String.CompareOrdinal(h[current], h[current * 2]) < 0 || current <= size / 2 && String.CompareOrdinal(h[current], h[current * 2 + 1]) < 0)
        } // end Extract_Max()

        /**
         * Method Name: Heap_Sort <br>
         * Method Purpose: Calls Extract_Max until the heap is empty to sort the contents. <br>
         *
         * <hr>
         * Date created: 04/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         *  
         */
        public void Heap_Sort()
        {
            while (size != 0)
            {
                Extract_Max();      // Extract the top value of the heap until the heap is empty and sorted into the container array.
            } // while (size != 0)
        } // end Heap_Sort()

        /**
         * Method Name: Print_Array <br>
         * Method Purpose: Prints the array container for the heap. <br>
         *
         * <hr>
         * Date created: 04/10/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         *  
         */
        public void Print_Array()
        {
            for (int i = 1; i < max_size; i++)
            {
                Console.WriteLine("{0}", h[i]);    // print the items in the container array (excluding the unused 0-index)
            } // end for (int i = 1; i < max_size; i++)
        } // end Print_Array()
    } // end MaxHeap
} // end HW8
