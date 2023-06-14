using CifradoPE.Dominio.Inteface;
using CifradoPE.Infraestructura.Interface;
using System.Security.Cryptography;
using System.Text;

namespace CifradoPE.Infraestructura
{
    public class AesAsimetrico : IAes
    {
        public ICifrado Desencriptar(ICifrado cifrado)
        {
            byte[] key = Encoding.UTF8.GetBytes(cifrado.Key);
            byte[] iv = Encoding.UTF8.GetBytes(cifrado.IV);
            byte[] cipherTextBytes = Convert.FromBase64String(cifrado.Texto);
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
            cifrado.TextoProcesado = plainText;
            return cifrado;
        }

        public ICifrado Encriptar(ICifrado cifrado)
        {
            byte[] key = Encoding.UTF8.GetBytes(cifrado.Key);
            byte[] iv = Encoding.UTF8.GetBytes(cifrado.IV);
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
                            swEncrypt.Write(cifrado.Texto);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
            }
            cifrado.TextoProcesado = Convert.ToBase64String(encryptedBytes);
            return cifrado;
        }
    }
}
