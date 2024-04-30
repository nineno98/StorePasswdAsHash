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

            string passwd = "almakorte";

            
            string hashed = Convert.ToBase64String(generateHash.GenerateHashValue(Encoding.UTF8.GetBytes(passwd), salt));

            Console.WriteLine(Convert.ToBase64String(generateHash.GenerateHashValue(Encoding.UTF8.GetBytes(passwd), salt)));
            Console.WriteLine(Convert.ToBase64String(generateHash.GenerateHashValue(Encoding.UTF8.GetBytes(passwd), salt)));
            Console.WriteLine(generateHash.GenerateHashValue(Encoding.UTF8.GetBytes(passwd), salt).Length);
            Console.WriteLine(salt.Length);


            Console.ReadKey();
        }
    }
}
