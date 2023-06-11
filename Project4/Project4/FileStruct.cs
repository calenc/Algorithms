using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
// ---------------------------------------------------------------------------
// File name: FileStruct.cs
// Project name: Project4
// ---------------------------------------------------------------------------
// Creator’s name and email: Calen Cummings, cummingscc@etsu.edu
// Course-Section: 001 
// Creation Date: 04/20/2022
// ---------------------------------------------------------------------------

namespace Project4
{
    /**
    * Class Name: FileStruct <br>
    * Class Purpose: Data structure to allow us to refer to temporary files without having to store all of them in memory at once. <br>
    *
    * <hr>
    * Date created: 04/20/2022 <br>
    * @author Calen Cummings
    */
    class FileStruct
    {
        public struct FileNode
        {
            public BinaryFile binFile { get; set; }     // property for the BinaryFile associated with the struct instance.
            public int topNode { get; set; }            // property for the integer that will be the top value in the associated BinaryFile.


            public FileNode(BinaryFile file)
            {
                binFile = file;
                topNode = 0;
            }

            public void IntUpdate()
            {
                byte [] buffer = binFile.read(4);
                int val = buffer[0];
                topNode = val;
            } // end IntUpdate()
        } //  end struct FileStruct

    } // end FileStruct
} // end Project4
