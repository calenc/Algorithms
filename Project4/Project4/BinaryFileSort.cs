using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ---------------------------------------------------------------------------
// File name: BinaryFileSort.cs
// Project name: Project4
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/20/2022
// ---------------------------------------------------------------------------

namespace Project4
{
    /**
    * Class Name: BinaryFileSort <br>
    * Class Purpose: Takes in a user binary file and sorts it using heaps and . <br>
    *
    * <hr>
    * Date created: 04/20/2022 <br>
    * @author Calen Cummings
    */
    class BinaryFileSort
    {
        /**
         * Method Name: main <br>
         * Method Purpose: Reads in the binary file to sort, uses a max heap to store and sort the data, creating temporary files to later combine to create the original file, but sorted. <br>
         *
         * <hr>
         * Date created: 04/20/2022 <br>
         *
         * <hr>
         * Notes on specifications, special algorithms, and assumptions: N/A
         *
         * <hr>
         * @param args array of Strings (not used in this program)
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Which file do you want to sort? Please enter the EXACT filepath: ");     // Ask the user while file to sort.
            string fileString = Console.ReadLine();
            try
            {
                BinaryFile chosen = new BinaryFile(fileString, false);      // Open the selected file so we can read from it.
                chosen.Close();
                Console.WriteLine("What heap size would you like to use?");     // Ask the user for the heap size to use.
                int h = Convert.ToInt32(Console.ReadLine());        // int value to capture the heap size.
                Console.WriteLine("How many temp files would you like to merge at once?");      // Ask the user for the number of files to merge.
                int k = Convert.ToInt32(Console.ReadLine());        // int value to hold the number of files to merge at a time.
                MaxHeap siftAndSort = new MaxHeap(h);           // Create the heap that will hold the input from the file, sort it once the heap is full or file ends, and then output to a temporary file.
                List<string> fileList = new List<string>();     // dynamic List to hold all the names of our temp files so we can call back to and merge them.
                using (FileStream fs = new FileStream(fileString, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        while (br.PeekChar() != -1)
                        {
                            int line = br.ReadInt32();       // read the integer from the file.
                            siftAndSort.Insert(line);       // insert the read integer into the heap.

                            if (siftAndSort.IsFull() || br.PeekChar() == -1)
                            {
                                siftAndSort.Heap_Sort();        // if the heap is full or the end of the file has been reached, sort the heap.
                                string temp = Path.GetTempFileName();   // create temp file to hold the heap/data read in.
                                FileInfo tempInfo = new FileInfo(temp);     // create FileInfo object so we can set the temp flag for our file and use as much cache memory as possible rather than defaulting to disk space.
                                tempInfo.Attributes = FileAttributes.Temporary;     // setting the file as temporary to utilize cache memory.
                                fileList.Add(temp);     // add the temp file path to the List.
                                using (StreamWriter t = File.AppendText(temp))
                                {
                                    string [] data = siftAndSort.Print_Array();      // print the sorted heap array to the temp file.
                                    for (int i = 0; i < data.Length; i++)
                                    {
                                        t.WriteLine(data[i]);   // write the array to the file.
                                    } // end for (int i = 0; i < data.Length; i++)
                                    t.Flush();      // reset the buffer
                                    t.Close();      // close the writer
                                } // end using (StreamWriter t = new StreamWriter(temp))

                                siftAndSort.Heap_Flush();   // empty the stored heap so we can fill it back up.
                            } // end if (siftAndSort.IsFull() || br.PeekChar() == -1)
                        } // end while (br.PeekChar() != -1)
                    } // end while (f.Peek() != -1)
                } // end using (FileStream fs = new FileStream(fileString, FileMode.Open))

                
            } // end try
            catch (Exception ex)
            {
                Console.WriteLine("Unable to process file; please make sure to enter the exact, correct filepath. Closing...");    // If the file cannot be found, catch the exception and let the program end.
            } // end catch (Exception ex)
        } // end Main(string[])


        public BinaryFile Merge(List<string> files, int k)
        {
            if (files.Count == 1)
            {
                // convert last temp file to a binary file
            }
            MinHeap mergeHeap = new MinHeap(k);
            // run until the count of List is 1
        } // end Merge(List<string>, int)
    } // end BinaryFileSort
} // end Project4
