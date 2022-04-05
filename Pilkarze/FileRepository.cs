using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lab_02_4
{
    class FileRepository
    {
        public void Save(IEnumerable<Piłkarz> pilkarze)
        {
            using (StreamWriter writer = new StreamWriter("pilkarze.txt"))
            {
                var result = Encrypt(pilkarze.CollectionToString());
                writer.WriteLine(result);
            }
        }

        public List<Piłkarz> GetAll()
        {
            if (File.Exists("pilkarze.txt"))
            {
                using (StreamReader reader = new StreamReader("pilkarze.txt"))
                {
                    var readLine = Decrypt(reader.ReadLine());
                    return readLine.StringToCollection();
                }
            }
            return new List<Piłkarz>();
        }

        private string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("klucz"));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        private string Decrypt(string cipher)
        {
            if (!string.IsNullOrWhiteSpace(cipher))
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    using (var tdes = new TripleDESCryptoServiceProvider())
                    {
                        tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("klucz"));
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;

                        using (var transform = tdes.CreateDecryptor())
                        {
                            byte[] cipherBytes = Convert.FromBase64String(cipher);
                            byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                            return UTF8Encoding.UTF8.GetString(bytes);
                        }
                    }
                }
            }

            return "";
        }
    }
}
