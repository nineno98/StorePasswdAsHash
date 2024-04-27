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

            string salt_1 = Convert.ToBase64String(salt);
            string hashed = Convert.ToBase64String(generateHash.GenerateHashValue(Encoding.UTF8.GetBytes(passwd), salt));

            Console.WriteLine(hashed);

            string hashed_2 = Convert.ToBase64String(generateHash.GenerateHashValue(Encoding.UTF8.GetBytes((passwd)), Encoding.UTF8.GetBytes(salt_1)));

            Console.WriteLine(hashed_2);
            Console.ReadKey();
        }
    }
}
