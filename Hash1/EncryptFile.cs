using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hash1
{
  public  class EncryptFile
    {
      public EncryptFile()
      {
          encrypt = new encryption();

          rwf = new Read_and_Write_Files();
      }

      encryption encrypt;

      Read_and_Write_Files rwf;



      public void Encrypt_File_MD5(string path, string pathOutPut)
      {
          List<string> lines = new List<string>();

          List<string> hashList = new List<string>();

          bool readCheck = rwf.Read(path, ref lines);

          if (readCheck)
              foreach (var line in lines)
                  hashList.Add(encrypt.Encrypt_Md5(line));

          List<string> hashText = new List<string>();
          for (int i = 0; i < hashList.Count; i++)
                       hashText.Add(string.Format("{0}: {1}", hashList[i], lines[i]));


          if (File.Exists(pathOutPut))
              File.AppendAllLines(pathOutPut, hashText);

          else
              if (pathOutPut != "")
                  File.WriteAllLines(pathOutPut, hashText);



      }

      public void Encrypt_File_SHA1(string path, string pathOutPut)
      {
          List<string> lines = new List<string>();

          List<string> hashList = new List<string>();

          bool readCheck = rwf.Read(path, ref lines);

          if (readCheck)
              foreach (var line in lines)
                  hashList.Add(encrypt.Encrypt_SHA1(line));

          if (File.Exists(pathOutPut))
              File.AppendAllLines(pathOutPut, hashList);

          else
              if (pathOutPut != "")
              {
                  List<string> hashText = new List<string>();
                  for (int i = 0; i < hashList.Count; i++)
                  {
                      hashText.Add(string.Format("{0}: {1}", hashList[i], lines[i]));

                      File.WriteAllLines(pathOutPut, hashText);
                  }
              }
      }


    }
}
