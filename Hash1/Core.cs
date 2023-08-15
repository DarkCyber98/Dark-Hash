using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Net;

namespace Hash1
{
    class Core
    {

        static void Main(string[] args)
        {
            


            string path, selectMenu, select, savePath;

            encryption encrypt = new encryption();

            Read_and_Write_Files rwf = new Read_and_Write_Files();

            EncryptFile encryptFile = new EncryptFile();

            Baner baner = new Baner();

            Crack_Encryption crack = new Crack_Encryption();

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n{0}\n\n", baner.HomeBaner());

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  1  ===>  Hashing");
                Console.WriteLine("\n  2  ===>  Crack the Hash");
                Console.WriteLine("\n  3  ===>  Hash Analysis");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n  Choose one of the items ==> ");
                selectMenu = Console.ReadLine();

                if (selectMenu == "1")  // بخش رمزنگاری 
                {
                    select = "";
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(baner.EncryptMenu()+"\n\n");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  1  ===> File");
                    Console.WriteLine("\n  2  ===> String");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\n  Choose one of the items ==> ");
                    select = Console.ReadLine();

                    if (select == "1")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("  Enter the file path  ===>  ");
                        path = Console.ReadLine();
                        Console.Write("\n  save to file [y,N]? ");
                        select = Console.ReadLine();

                        if (select == "Y" || select == "y")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("  Enter the output file path  ===>  ");
                            savePath = Console.ReadLine();
                            encryptFile.Encrypt_File_MD5(path, savePath);
                        }
                        else
                        {
                            List<string> txt = new List<string>();
                            bool check = rwf.Read(path, ref txt);

                            if (check)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                for (int i = 0; i < txt.Count; i++)
                                {
                                    string hash = encrypt.Encrypt_Md5(txt[i]);
                                    Console.WriteLine("\n  {0} : {1}", txt[i], hash);
                                }

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n  END");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n  There is no file");
                            }

                        }
                    }

                    else
                        if (select == "2")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("  Enter the  string  ===>  ");

                            string userText = Console.ReadLine();
                            string userHash = encrypt.Encrypt_Md5(userText);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n  {0}: {1}\n\n  End", userHash, userText);

                        }

                }


//==================================================================================================================================

                else
                    if (selectMenu == "2")
                    {
                        select = "";
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n{0}\n\n",baner.Crack());

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("  1  ===> File");

                        Console.WriteLine("\n  2  ===> String");

                        Console.WriteLine("\n  3  ===> Online Crack");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\n  Choose one of the items ==> ");
                        select = Console.ReadLine();

                        if (select == "1")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("  Enter the Hash file  path  ===>  ");
                            path = Console.ReadLine();

                            if (File.Exists(path))
                            {
                                List<string> userHashList = new List<string>();
                                                              
                                List<string> crackerText = new List<string>();


                                foreach (string hash in File.ReadLines(path))
                                    userHashList.Add(hash);

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("  \nEnter the Hash Crack File  ===>  ");
                                string pathCrackerFile = Console.ReadLine();

                                if (File.Exists(pathCrackerFile))
                                {

                                    foreach (string item in File.ReadLines(pathCrackerFile))
                                        crackerText.Add(item);


                                   int  index = crack.Crack(userHashList, crackerText);


                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;

                                    Console.WriteLine("\n  file does not exist\n");

                                }

                            }
                        }
                        else
                            if (select == "2")
                            {
                                string userHash = "";

                                string pathCrackerFile;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("  Enter the Hash  ===>  ");
                                userHash = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("  \nEnter the Hash Crack File  ===>  ");
                                pathCrackerFile = Console.ReadLine();

                                List<string> crackrText = new List<string>();
                                List<string> crackrHash = new List<string>();


                                if (File.Exists(pathCrackerFile))
                                {
                                    foreach (string item in File.ReadLines(pathCrackerFile))
                                    {
                                        crackrText.Add(item);
                                        crackrHash.Add(encrypt.Encrypt_Md5(item));
                                    }


                                    bool crack = false;
                                    for (int i = 0; i < crackrHash.Count; i++)
                                    {
                                        // crack = Decrypt_MD5(userHash, crackrHash[i]);

                                        if (crack)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\n  {0}  ===>  {1} ", userHash, crackrText[i]);
                                            break;
                                        }

                                    }

                                    if (!crack)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\n  It did not crack \n");
                                    }

                                }
                            }
                            else
                                if (select == "3")
                                {
                                    string pathFileSave = "";
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("  1  ===> File");

                                    Console.WriteLine("\n  2  ===> String");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("\n  Choose one of the items ==> ");
                                    select = Console.ReadLine();

                                    if (select == "1")
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("  Enter the Hash file  path  ===>  ");
                                        path = Console.ReadLine();

                                        if (File.Exists(path))
                                        {
                                            List<string> resultList = new List<string>();

                                            Console.Write("\n  save to file [y,N]? ");
                                            select = Console.ReadLine();

                                            if (select == "Y" || select == "y")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("  Enter the output file path  ===>  ");
                                                pathFileSave = Console.ReadLine();
                                            }

                                            foreach (string hash in File.ReadLines(path))
                                            {
                                                string result = Requset(hash);
                                                if (result != "")
                                                {
                                                    if (select == "Y" || select == "y")
                                                        resultList.Add(result);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine(result);
                                                }

                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("{0} : Not Found", hash);
                                                }
                                            }

                                            if (select == "Y" || select == "y")
                                            {
                                                if (File.Exists(pathFileSave))
                                                    File.AppendAllLines(pathFileSave, resultList);
                                                else
                                                    File.WriteAllLines(pathFileSave + "CrackHash", resultList);
                                            }

                                        }
                                    }
                                    else
                                        if (select == "2")
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("  Enter the  Hash  ===>  ");

                                            string userHash = Console.ReadLine();

                                            string result = Requset(userHash);

                                            if (result != "")
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine(result);
                                            }

                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("{0} : Not Found", userHash);
                                            }
                                        }
                                }


                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n  Please enter the correct number\n");
                                    select = "";
                                }
                    }

                    else
                        if (selectMenu == "3")
                        {
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\n{0}\n\n",baner.HashAnalysis());

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Hash  ===>  ");
                            string hash = Console.ReadLine();
                            string type = Hash_Analysis.Analysis(hash);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n  Hash Type ===>  {0}\n\n  End", type);
                        }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n  Press the key to return to the menu...");
                Console.ReadKey();

            }
        }


//=====================================================================================================================

        public static string Requset(string hash)
        {
            var request = (HttpWebRequest)WebRequest.Create("");

            try
            {
                request = (HttpWebRequest)WebRequest.Create(string.Format("https://www.nitrxgen.net/md5db/{0}", hash));

                var response = (HttpWebResponse)request.GetResponse();

                string status = response.StatusCode.ToString();

                if (status == "OK")
                {
                    string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


                    if (responseString != "")
                    {
                        string result = string.Format("\n  {0} : {1}", hash, responseString);
                        return result;
                    }
                    else
                        return "";
                }

                else
                    return "\n Connection error ";
            }

            catch
            {
                return "\n Connection error ";
            }
        }
    }
}
