
using System.Security.Cryptography;
using System.Text;




namespace DigitalAccOpening.CommonFunctions
{
    public static class EncryptionHelper
    {
        private static readonly string EncryptionKey = "#@!3658f$dh&2j*4";
        private static readonly byte[] IV = new byte[16]; 


        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key=Encoding.UTF8.GetBytes(EncryptionKey);
                aes.IV = IV;

                ICryptoTransform encryptor=aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt,encryptor, CryptoStreamMode.Write))
                    using(StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }

        }


        public static string Decrypt(string cypherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aes.IV = IV;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cypherText)))
                
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) 
                using(StreamReader srDecrypt= new StreamReader(csDecrypt))
                { 
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }

    
}
