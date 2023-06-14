using CifradoPE.Dominio.Abstracta;
using CifradoPE.Dominio.Entidades;
using CifradoPE.Dominio.Inteface;

namespace CifradoPE.Dominio.Especificaciones
{
    internal class ValidarCifradoKey : AValidarCifrado
    {
        public override void EsValido(ICifrado cifrado)
        {
            if (string.IsNullOrEmpty(cifrado.Key))
            {
                Exception exception = new Exception();
                ErroresCifradoPE erroresCifradoPE = new ErroresCifradoPE(ErroresCifradoPE.ErrorCifrado.KeyNullOrEmpty);
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
