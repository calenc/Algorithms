using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
// ---------------------------------------------------------------------------
// File name: BinaryFile.cs
// Project name: Project4
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/20/2022
// ---------------------------------------------------------------------------

namespace Project4
{
    // Class BinaryFile
    //   manages the details of reading and writing fixed
    //   length binary records to from/to a binary file. Taken from Binary Files Lab.
    class BinaryFile
    {
        private BinaryWriter binOutFile; // Output file
        private BinaryReader binInFile;  // Input file
        private long position = 0,       // Current file position
	             length = 0;         // Length of input file
        bool writing = false;            // Writing == true

	    // Constructor
	    // Open fileName for writing if writeit == true,
	    // reading if writeit == false
        public BinaryFile(string fileName, bool writeit)
        {
            writing = writeit;
            if (writing)
            {
                binOutFile = new BinaryWriter(File.Open(fileName, 
		                  FileMode.Create, FileAccess.Write));
            } // end if (writing)
            else
            {
                binInFile = new BinaryReader(File.Open(fileName, 
		                FileMode.Open, FileAccess.Read));
		    // Set the length of this file
                length = binInFile.BaseStream.Length;
            } // end else
        } // end BinaryFile(string, bool)

	    // Write one binary record
        public void write(byte[] buffer, int size)
        {
            binOutFile.Write(buffer, 0, size);
        } // end write(byte[], int)

	    // Read one binary record
        public byte[] read(int size)
        {
            byte[] buffer = new byte[size];
            binInFile.Read(buffer, 0, size);
            return (buffer);
        } // end read(int)

	    // Return file length
        public long getLength()
        {
            return length;
        } // end getLength()

	    // Close whichever file
        public void Close()
        {
            if (writing) binOutFile.Close();
            else binInFile.Close();
        } // end Close()

    } // end BinaryFile
} // end Project4
