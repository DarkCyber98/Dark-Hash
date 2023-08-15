using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash1
{
    class Crack_Encryption
    {
        encryption encrypt;

       

        public Crack_Encryption()
        {
            encrypt = new encryption();
           
        }

        public int Crack(List<string> userHash, List<string> crackerList)
        {
            List<string> hashList = new List<string>();

            string type = Hash_Analysis.Analysis(userHash[0]);

            switch (type)
            {
                case "MD5":
                    foreach (string txt in crackerList)
                        hashList.Add(encrypt.Encrypt_Md5(txt));
                    for (int i = 0; i < userHash.Count; i++)
                    {
                        for (int p = 0; p < crackerList.Count; p++)
                        {
                            if (userHash[i] == crackerList[p])
                                return p;
                        }
                    }
                    return -1;
              

                case "SHA-1":
                    foreach (string txt in crackerList)
                        hashList.Add(encrypt.Encrypt_SHA1(txt));
                    break;

                case "SHA-256":
                    foreach (string txt in crackerList)
                        hashList.Add(encrypt.Encrypt_SHA256(txt));
                    break;

                case "SHA-384":
                    foreach (string txt in crackerList)
                        hashList.Add(encrypt.Encrypt_SHA384(txt));
                    break;

                case "512":
                    foreach (string txt in crackerList)
                        hashList.Add(encrypt.Encrypt_SHA512(txt));
                    break;

                case "Not Found":
                    return -2;
                default :
                    return -1;

            }

        }
               
    }
}
