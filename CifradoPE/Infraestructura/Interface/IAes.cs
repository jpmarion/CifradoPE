namespace CifradoPE.Infraestructura.Interface
{
    public interface IAes
    {
        string Desencriptar(string texto);
        string Encriptar(string texto);
    }
}
