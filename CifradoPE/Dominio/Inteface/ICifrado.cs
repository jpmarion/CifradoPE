namespace CifradoPE.Dominio.Inteface
{
    internal interface ICifrado
    {
        string Key { get; set; }
        string PrivateKet { get; set; }
        string Texto { get; set; }
    }
}
