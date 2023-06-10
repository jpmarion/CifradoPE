using CifradoPE.Dominio.Entidades.Interface;

namespace CifradoPE.Dominio.Entidades
{
        internal class Cifrado : ICifrado
    {
        public string Texto { get; set; }
        public string Key { get; set; }
        public string PrivateKet { get; set; }
    }
}
