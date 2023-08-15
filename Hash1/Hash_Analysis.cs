using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash1
{
  public static class Hash_Analysis
    {
      public static string Analysis(string hash)
      {
          int length = hash.Length;

          switch (length)
          {
              case 32:
                  return "MD5";
                  
              case 40:
                  return "SHA-1";

              case 64:
                  return "SHA-256";

              case 96 :
                  return "SHA-384";

              case 128:
                  return "SHA-512";

              default:
                  return "Not Found";
                  
          }
      }
    }
}
