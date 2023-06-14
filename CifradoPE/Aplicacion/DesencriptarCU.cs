using CifradoPE.Dominio.Especificaciones;
using CifradoPE.Dominio.Inteface;
using CifradoPE.Infraestructura.Interface;
using CompartidoPE.Abstracta;
using CompartidoPE.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoPE.Aplicacion
{
    public class DesencriptarCU<T> : AEjecutarCU<T>
    {
        private readonly IAes _aes;
        private ICifrado _cifrado;
        private readonly ValidarCifradoTexto _validarCifradoTexto = new ValidarCifradoTexto();
        private readonly ValidarCifradoKey _validarCifradoKey = new ValidarCifradoKey();
        private readonly ValidarCifrafoPrivateKey _validarCifrafoPrivateKey = new ValidarCifrafoPrivateKey();

        public DesencriptarCU(IResponse<T> response, IAes aes, ICifrado cifrado) : base(response)
        {
            _aes = aes;
            _cifrado = cifrado;
            _validarCifradoTexto.ProximaValidacion(_validarCifradoKey);
            _validarCifradoKey.ProximaValidacion(_validarCifrafoPrivateKey);
            _validarCifradoKey.ProximaValidacion(_validarCifrafoPrivateKey);
        }

        public override IList<T> Proceso()
        {
            _validarCifradoTexto.EsValido(_cifrado);

            _cifrado = _aes.Desencriptar(_cifrado);
            IList<ICifrado> lstCifrado = new List<ICifrado>
            {
                _cifrado
            };

            return (IList<T>)lstCifrado;
        }
        public override void BeginTransaction() { }
        public override void CommitTransaction() { }
        public override void RollbackTransaction() { }
    }
}
