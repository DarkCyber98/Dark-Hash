using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hash1
{
    class Read_and_Write_Files
    {
        encryption encrypt;

        public Read_and_Write_Files ()
        {
                encrypt=new encryption();
        }

        public bool Read(string path, ref List<string> lines)
        {
            
            if (File.Exists(path))
            {
                foreach (string line in File.ReadLines(path))
                    lines.Add(line);
                return true;
            }

            return false;
        }
        
        //=============================================================================
                
        public bool Write(string path)
        {
            return true;
        }

    }
}
