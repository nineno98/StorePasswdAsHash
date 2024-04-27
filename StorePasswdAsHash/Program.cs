using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePasswdAsHash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenerateHash generateHash = new GenerateHash();
            byte[] salt = generateHash.GenerateSaltValue(12);
            Console.WriteLine(Convert.ToBase64String(salt));



            Console.ReadKey();
        }
    }
}
