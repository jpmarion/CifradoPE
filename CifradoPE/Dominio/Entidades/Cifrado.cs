using CifradoPE.Dominio.Inteface;

namespace CifradoPE.Dominio.Entidades
{
    public class Cifrado : ICifrado
    {
        public string Texto { get; set; }
        public string Key { get; set; }
        public string IV { get; set; }
        public string TextoProcesado { get ; set; }
    }
}
