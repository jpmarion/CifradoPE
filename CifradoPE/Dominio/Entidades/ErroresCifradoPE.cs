using AuthPeDDD.Compartido.Abstracta;
using System.ComponentModel;

namespace CifradoPE.Dominio.Entidades
{
    internal class ErroresCifradoPE : AErrores
    {
        public enum ErrorCifrado
        {
            [Description("Ingrese el texto")]
            TextoNullOrEmpty,
            [Description("Ingrese la key")]
            KeyNullOrEmpty,
            [Description("Ingrese la PrivateKey")]
            PrivateKeyNullOrEmpty
        }
        public ErroresCifradoPE(Enum enumValor) : base(enumValor)
        {
        }
    }
}
