using CifradoPE.Aplicacion;
using CifradoPE.Dominio.Entidades;
using CifradoPE.Dominio.Inteface;
using CifradoPE.Infraestructura;
using CifradoPE.Infraestructura.Interface;
using CompartidoPE.Abstracta;
using CompartidoPE.Interface;
using CompartidoPE.Modelo;

ICifrado cifrado = new Cifrado();
cifrado.Texto = "Juan Pablo Marion Juan Pablo Marion Juan Pablo Marion Juan Pablo Marion";
cifrado.Key = "ClaveSecreta12345ClaveSecreta123";
cifrado.IV = "ClaveSecreta1234";

IResponse<ICifrado> response = new Response<ICifrado>();
IAes aes = new AesAsimetrico();

AEjecutarCU<ICifrado> aEjecutarCU = new EncriptarCU<ICifrado>(response, aes, cifrado);
response = aEjecutarCU.Ejectuar();

Console.WriteLine("Encriptar: " + response.Data[0].TextoProcesado);

cifrado.Texto = cifrado.TextoProcesado;
AEjecutarCU<ICifrado> desencriptarCU = new DesencriptarCU<ICifrado>(response,aes,cifrado);
response = desencriptarCU.Ejectuar();

Console.WriteLine("Desencriptar:" + response.Data[0].TextoProcesado);
Console.ReadKey();
