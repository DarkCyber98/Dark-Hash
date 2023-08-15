using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hash1
{
   public  class encryption
    {
      
       
       public  string Encrypt_Md5(string Text)
       {
           string hashString;
           UTF8Encoding ue = new UTF8Encoding();
           byte[] bytes = ue.GetBytes(Text);

           MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
           byte[] hashBytes = md5.ComputeHash(bytes);

           // Bytes to string

           hashString = System.Text.RegularExpressions.Regex.Replace
          (BitConverter.ToString(hashBytes), "-", "").ToLower();
           return hashString;
       }

       //=======================================================================================================


       public string Encrypt_SHA1(string Text)
       {
           string hashString;
           UTF8Encoding ue = new UTF8Encoding();
           byte[] bytes = ue.GetBytes(Text);

           SHA1CryptoServiceProvider sha1= new SHA1CryptoServiceProvider();
           byte[] hashBytes = sha1.ComputeHash(bytes);

           // Bytes to string

           hashString = System.Text.RegularExpressions.Regex.Replace
          (BitConverter.ToString(hashBytes), "-", "").ToLower();
           return hashString;
       }

       //=======================================================================================================


       public string Encrypt_SHA256(string Text)
       {
           string hashString;
           UTF8Encoding ue = new UTF8Encoding();
           byte[] bytes = ue.GetBytes(Text);

           SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
           byte[] hashBytes = sha256.ComputeHash(bytes);

           // Bytes to string

           hashString = System.Text.RegularExpressions.Regex.Replace
          (BitConverter.ToString(hashBytes), "-", "").ToLower();
           return hashString;
       }

       //=======================================================================================================


       public string Encrypt_SHA384(string Text)
       {
           string hashString;
           UTF8Encoding ue = new UTF8Encoding();
           byte[] bytes = ue.GetBytes(Text);

           SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
           byte[] hashBytes = sha384.ComputeHash(bytes);

           // Bytes to string

           hashString = System.Text.RegularExpressions.Regex.Replace
          (BitConverter.ToString(hashBytes), "-", "").ToLower();
           return hashString;
       }

       //=======================================================================================================

       public string Encrypt_SHA512(string Text)
       {
           string hashString;
           UTF8Encoding ue = new UTF8Encoding();
           byte[] bytes = ue.GetBytes(Text);

           SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
           byte[] hashBytes = sha512.ComputeHash(bytes);

           // Bytes to string

           hashString = System.Text.RegularExpressions.Regex.Replace
          (BitConverter.ToString(hashBytes), "-", "").ToLower();
           return hashString;
       }

    }
}
