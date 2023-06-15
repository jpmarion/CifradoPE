using CifradoPE.Infraestructura;
using CifradoPE.Infraestructura.Interface;

IAes aes = new AesAsimetrico("key", "IV");
string encriptar = aes.Encriptar("prueba");
Console.WriteLine("Encriptar: " + encriptar);

string descriptar = aes.Desencriptar(encriptar);
Console.WriteLine("Desencriptar:" + descriptar);
Console.ReadKey();
