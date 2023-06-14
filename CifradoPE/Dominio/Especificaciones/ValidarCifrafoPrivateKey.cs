using CifradoPE.Dominio.Abstracta;
using CifradoPE.Dominio.Entidades;
using CifradoPE.Dominio.Inteface;

namespace CifradoPE.Dominio.Especificaciones
{
    internal class ValidarCifrafoPrivateKey : AValidarCifrado
    {
        public override void EsValido(ICifrado cifrado)
        {
            if (string.IsNullOrEmpty(cifrado.IV))
            {
                Exception exception = new Exception();
                ErroresCifradoPE erroresCifradoPE = new ErroresCifradoPE(ErroresCifradoPE.ErrorCifrado.PrivateKeyNullOrEmpty);
                exception.Data.Add(erroresCifradoPE.GetNroError(), erroresCifradoPE.GetDescription());
                throw exception;
            }

            if (_validador != null)
            {
                _validador.EsValido(cifrado);
            }
        }
    }
}
