using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class MontoNoValidoException : Exception
    {
        public MontoNoValidoException()
            :base ("El monto ingresado no es valido para la operacion solicitada.") { }
    }
    public class CuentaNoActivaException : Exception
    {
        public CuentaNoActivaException(Estado estado)
            : base($"No se puede operar con la cuenta {estado}") { }
    }
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException()
            :base("La cuenta no cuenta con saldo para la operación solicitada. " +
                 "\n La cuenta fue suspendida.") { }
    }


}
