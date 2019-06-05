using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bdd_Database.Helpers
{
    public class CryptographyHelper
    {
        private string _key;

        public CryptographyHelper()
        {
            this._key = "$CHAVE_CRIPTOGRAFIA_SENHA#";
        }

        public string Encrypt(string content)
        {
            return Encrypt(content, _key);
        }

        public string Decrypt(string content)
        {
            return Decrypt(content, _key);
        }

        public string Encrypt(string content, string key)
        {
            var service = new TripleDESCryptoServiceProvider();
            var md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteBuff;
            string strTempKey = key;

            byteHash = md5.ComputeHash(ASCIIEncoding.UTF8.GetBytes(strTempKey));
            md5 = null;
            service.Key = byteHash;
            service.Mode = CipherMode.ECB;

            byteBuff = ASCIIEncoding.UTF8.GetBytes(content);
            return Convert.ToBase64String(service.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }

        public static string Decrypt(string content, string key)
        {
            var service = new TripleDESCryptoServiceProvider();
            var md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteBuff;
            string strTempKey = key;

            byteHash = md5.ComputeHash(ASCIIEncoding.UTF8.GetBytes(strTempKey));
            md5 = null;
            service.Key = byteHash;
            service.Mode = CipherMode.ECB;

            byteBuff = Convert.FromBase64String(content);
            string strDecrypted = ASCIIEncoding.UTF8.GetString(service.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            service = null;

            return strDecrypted;
        }
    }

}
