using CifradoPE.Dominio.Inteface;

namespace CifradoPE.Infraestructura.Interface
{
    public interface IAes
    {
        ICifrado Desencriptar(ICifrado cifrado);
        ICifrado Encriptar(ICifrado cifrado);
    }
}
