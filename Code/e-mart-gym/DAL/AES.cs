using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;


namespace DAL
{

    public class AES
    {
        /*
         * encrypt the bytesToBeEncrypted into a new encrypted byte array and returns it
         */
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            byte[] saltBytes = passwordBytes;//an extension to the key, complicates the encryptions level
            // Example:
            //saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())//memory stream on which to save the encrypted data
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);//pass,saltB,number of repetitions
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))//creation of cryptoSteam 
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);//writing encrypted data onto memory steam
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();//entering memory stream into a byte array
                }
            }

            return encryptedBytes;
        }

        /*
         * dencrypts the bytesToBeDecrypted into a new dencrypted byte array and returns it
         */
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            // Set your salt here to meet your flavor:
            byte[] saltBytes = passwordBytes;
            // Example:
            //saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);//key generator
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);//writing the cryptostream into memory stream
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();//writing stream into byte array
                }
            }

            return decryptedBytes;
        }
    }
}
