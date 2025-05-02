using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public decimal Comision { get; set; }
        public decimal LimiteDeDescubierto { get; set; }

        public CuentaCorriente(string numero, decimal saldo, string[] titulares)
            :base(numero, saldo, titulares) { }

        public override void Depositar(decimal monto)
        {
            VerificarMonto(monto);
            VerificarCuentaActiva();
            Saldo += monto - (monto * Comision);
        }

        public override void Retirar(decimal monto)
        {
            VerificarMonto(monto);
            VerificarCuentaActiva();
            if(Saldo - monto < LimiteDeDescubierto)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
            }
            Saldo -= monto;
            if (Saldo < 0) Estado = Estado.Suspendida;
        }
    }
}
