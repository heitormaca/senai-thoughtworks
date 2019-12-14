using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TW.Utils {
    public class EncryptPassword {
        public string Encrypt (string encryptString) {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";
            byte[] clearBytes = Encoding.Unicode.GetBytes (encryptString);
            using (Aes encryptor = Aes.Create ()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes (EncryptionKey, new byte[] {
                    0x49,
                    0x76,
                    0x61,
                    0x6e,
                    0x20,
                    0x4d,
                    0x65,
                    0x64,
                    0x76,
                    0x65,
                    0x64,
                    0x65,
                    0x76
                });
                encryptor.Key = pdb.GetBytes (32);
                encryptor.IV = pdb.GetBytes (16);
                using (MemoryStream ms = new MemoryStream ()) {
                    using (CryptoStream cs = new CryptoStream (ms, encryptor.CreateEncryptor (), CryptoStreamMode.Write)) {
                        cs.Write (clearBytes, 0, clearBytes.Length);
                        cs.Close ();
                    }
                    encryptString = Convert.ToBase64String (ms.ToArray ());
                }
            }
            return encryptString;
        }
    }
}