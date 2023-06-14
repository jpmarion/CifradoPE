using CifradoPE.Dominio.Inteface;

namespace CifradoPE.Dominio.Abstracta
{
    internal abstract class AValidarCifrado
    {
        public AValidarCifrado _validador;
        public void ProximaValidacion(AValidarCifrado validador)
        {
            _validador = validador;
        }
        public abstract void EsValido(ICifrado cifrado);
    }
}
