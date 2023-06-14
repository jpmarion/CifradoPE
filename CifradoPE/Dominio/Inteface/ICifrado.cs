namespace CifradoPE.Dominio.Inteface
{
    public interface ICifrado
    {
        string Key { get; set; }
        string IV { get; set; }
        string Texto { get; set; }
        string TextoProcesado { get; set; }
    }
}
