using CifradoPE.Infraestructura.Interface;
using System.Security.Cryptography;
using System.Text;

namespace CifradoPE.Infraestructura
{
    public class AesAsimetrico : IAes
    {
        private string _key;
        private readonly string _iV;

        public AesAsimetrico(string IV)
        {
            _iV = @"?`Zh>guSY_N3+MR3" + IV;
            _iV = _iV.Substring(IV.Length, 16);
        }
        public void Key(string key)
        {
            _key = @"{@BCe-DWtXGWZu7`k7W^&t];<9'vB>r=" + key;
            _key = _key.Substring(key.Length, 32);
        }

        public string Desencriptar(string texto)
        {
            byte[] key = Encoding.UTF8.GetBytes(_key);
            byte[] iv = Encoding.UTF8.GetBytes(_iV);
            byte[] cipherTextBytes = Convert.FromBase64String(texto);
            string plainText;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plainText;
        }
        public string Encriptar(string texto)
        {
            byte[] key = Encoding.UTF8.GetBytes(_key);
            byte[] iv = Encoding.UTF8.GetBytes(_iV);
            byte[] encryptedBytes;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryiptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryiptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(texto);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }
    }
}
