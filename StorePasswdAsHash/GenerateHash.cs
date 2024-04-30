using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StorePasswdAsHash
{
    internal class GenerateHash
    {
        public GenerateHash()
        {

        }

        public byte[] GenerateHashValue(byte[] passwd, byte[] salt)
        {

            byte[] result;
            using (HMACSHA256 hamacs = new HMACSHA256())
            {
                hamacs.Key = salt;
                result = hamacs.ComputeHash(passwd);

            }
            return result;
            /*HashAlgorithm hashAlgorithm = new SHA256Managed();
            byte[] result = new byte[passwd.Length + salt.Length];
            for (int i = 0; i < passwd.Length; i++)
            {
                result[i] = passwd[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                result[passwd.Length + i] = salt[i];
            }

            return hashAlgorithm.ComputeHash(result);*/

        }

        public byte[] GenerateSaltValue(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] result = new byte[size];
            rng.GetBytes(result);
            return result;
        }

        public bool CompareHashValues(byte[] value1, byte[] value2)
        {
            
            if (value1.Length == value2.Length)
            {
                int i = 0;
                while ((i < value1.Length) && (value1[i] == value2[i]))
                {
                    i++;
                }
                if (i == value1.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
