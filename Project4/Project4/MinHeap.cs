﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: MinHeap.cs
// Project name: Project4
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/27/2022
// ---------------------------------------------------------------------------

namespace Project4
{
    /**
    * Class Name: MinHeap <br>
    * Class Purpose: Class of Min-Heap objects. <br>
    *
    * <hr>
    * Date created: 04/27/2022 <br>
    * 
    * @author Calen Cummings
    */
    class MinHeap
    {
        private int max_size;   // private attribute to represent the maximum size of the heap.
        private int size;       // private int to represent the current size of the heap.
        private FileStruct.FileNode[] h;     // array of strings that the heap will use

        /**
         * Method Name: MinHeap <br>
         * Method Purpose: Constructor method that will instantiate a MinHeap object and fill it with initial values from the parameter value. <br>
         *
         * <hr>
         * Date created: 04/27/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param totalSize; int value that will determine the maximum size of the heap.
         */
        public MinHeap(int totalSize)
        {
            size = 0;                           // initial size of the empty heap is zero.
            max_size = totalSize + 1;           // maximum size is equal to the input + 1 (not using the 0 index).
            h = new FileStruct.FileNode[totalSize + 1];      // array to hold the int objects of the heap.
        } // end MinHeap(int)

        /**
         * Method Name: Print <br>
         * Method Purpose: Prints the current heap to the console window. <br>
         *
         * <hr>
         * Date created: 04/27/2022 <br>
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
         * Last modified: 04/27/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param item; int value that will be inserted into the heap. 
         */
        public void Insert(FileStruct.FileNode file)
        {
            size++;                 // increment the size of the heap by 1 for adding an object.
            h[size] = file;         // placing the item at the end of the current heap.
            int current = size;     // int value to easily move through the heap nodes and fix the heap after inserting.
            while (current != 1 && h[current].topNode < h[current / 2].topNode)
            {
                FileStruct.FileNode temp = new FileStruct.FileNode();               // temporary value to hold our place and swap nodes correctly.
                temp = h[current / 2];          // assign the parent node to the temp value.
                h[current / 2] = h[current];    // swap the parent and current child node.
                h[current] = temp;              // set the child node as the original parent node value.

                current = current / 2;          // update the current value so we can start with the correct node in the next loop.
            } // end while (current != 1 && h[current] < h[current / 2])
        } // end Insert(string)

        /**
         * Method Name: Extract_Min <br>
         * Method Purpose: Removes the maximum value from the heap to sort it within the container array. <br>
         *
         * <hr>
         * Date created: 04/27/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         *  
         */
        public void Extract_Min()
        {
            FileStruct.FileNode temp = new FileStruct.FileNode();   // temporary int so we can swap the first and last elements in the array.
            temp = h[1];        // hold the value of the top node before swapping.
            h[1] = h[size];     // set the top node to the value of the last node.
            h[size] = temp;     // set the last node to the max value that was at the top of the heap.
            size--;             // decrease size by 1 so we have effectively removed the node from the heap while leaving it in the container array.

            int current = 1;    // starting at the top of the heap, fix it until the max-heap property is restored.
            while (current <= size / 2 && h[current].topNode > h[current * 2].topNode || current <= size / 2 && h[current].topNode > h[current * 2 + 1].topNode)
            {
                int firstChild = h[current * 2].topNode;           // store the first child node as a char value.
                int secondChild = h[current * 2 + 1].topNode;      // store the second child node as a char value.
                int bigChild = -1;        // placeholder string value for the larger of the two children.
                int smallChild = -1;      // placeholder string value for the smaller of the two children.
                if (firstChild > secondChild)
                {
                    bigChild = firstChild;          // if first child is bigger, set it as big child.
                    smallChild = secondChild;       // set smaller child.
                } // end if (firstChild > secondChild)
                else
                {
                    bigChild = secondChild;     // if second child is bigger, set it as big child.
                    smallChild = firstChild;    // set smaller child.
                } // end else
                int childSpot = Array.IndexOf(h, smallChild);     // int to hold the index of the child node that will be used to switch.
                if (childSpot > size)
                {
                    childSpot = Array.IndexOf(h, bigChild);   // if the larger child node is outside of the heap, assign the smaller child as the one to compare to.
                }// end if (childSpot > size)

                if (h[childSpot].topNode < h[current].topNode)
                {
                    FileStruct.FileNode holder = new FileStruct.FileNode();     // temporary int to hold the value of the parent that we need to switch.
                    holder = h[current];    // holding the value of the parent node to be moved down.
                    h[current] = h[childSpot];     // assigning the larger child value found to the parent node.
                    h[childSpot] = holder;         // finishing the swap of parent and child node values. 
                } // end if (h[childSpot] < h[current])

                current = childSpot;        // moving current to the node that we just swapped our minimum value into so we can continue fixing the heap.
            } // end while (current <= size / 2 && h[current] > h[current * 2] || current <= size / 2 && h[current] > h[current * 2 + 1])
        } // end Extract_Max()

        /**
         * Method Name: Heap_Sort <br>
         * Method Purpose: Calls Extract_Max until the heap is empty to sort the contents. <br>
         *
         * <hr>
         * Date created: 04/27/2022 <br>
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
                Extract_Min();      // Extract the top value of the heap until the heap is empty and sorted into the container array.
            } // while (size != 0)

            Array.Reverse(h);   // by extracting the min and moving it to the end of the array, we must reverse the array to have it sorted in increasing order.
        } // end Heap_Sort()

        /**
         * Method Name: Print_Array <br>
         * Method Purpose: Prints the array container for the heap. <br>
         *
         * <hr>
         * Date created: 04/27/2022 <br>
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

        /**
         * Method Name: IsFull <br>
         * Method Purpose: Returns if the heap is full or not. <br>
         *
         * <hr>
         * Date created: 04/27/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @return true/false if the heap is full.
         */
        public bool IsFull()
        {
            if (size == max_size - 1)
            {
                return true;    // if the current size of the heap has reached its max, it is full.
            } // end if (size == max_size - 1)
            else
            {
                return false;   // if the current size is less than the max, it is not full.
            } // end else
        } // end IsFull()

        /**
         * Method Name: Heap_Flush <br>
         * Method Purpose: Empties the heap and container array to reset back into a fresh heap. <br>
         *
         * <hr>
         * Date created: 04/27/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * 
         */
        public void Heap_Flush()
        {
            size = 0;       // set size back to 0 because our heap is empty.
            h = new FileStruct.FileNode[max_size];      // create an empty array to flush out the current container.
        } // end Heap_Flush()
    } // end MinHeap
} // end Project4
