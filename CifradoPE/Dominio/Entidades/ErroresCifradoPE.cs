using AuthPeDDD.Compartido.Abstracta;

namespace CifradoPE.Dominio.Entidades
{
    internal class ErroresCifradoPE : AErrores
    {
        public enum ErrorCifrado
        {
            
        }
        public ErroresCifradoPE(Enum enumValor) : base(enumValor)
        {
        }
    }
}
