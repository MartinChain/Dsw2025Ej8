using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Presentacion
    {
        public static void Principal()
        {
            var cuentas = new List<CuentaBancaria>();

            //Crear dos cuentas de cada tipo para probar
            //Caja de Ahorro
            var caja1 = new CajaDeAhorro("CA01", 1000, new[] { "Juancito Pacheco" }) { TasaDeInteres = 0.05m };
            var caja2 = new CajaDeAhorro("CA02", 500, new[] { "Juana Viale" }) { TasaDeInteres = 0.03m };
            //Cuenta Corriente
            var corriente1 = new CuentaCorriente("CC01", 200, new[] { "Carlos Lopez" }) { LimiteDeDescubierto = 300, Comision = 0.02m };
            var corriente2 = new CuentaCorriente("CC02", 100, new[] { "Marta Minujin" }) { LimiteDeDescubierto = 100, Comision = 0.05m };

            cuentas.AddRange(new CuentaBancaria[] { caja1, caja2, corriente1, corriente2 });

            //Comprobacion de reglas
            foreach (var cuenta in cuentas)
            {
                try
                {
                    cuenta.Depositar(500);
                    cuenta.Retirar(200);

                    cuenta.Retirar(-100); //probar MontoNoValido
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Excepción] Cuenta {cuenta.Numero}: {ex.Message}");
                }
            }

            //Forazando errores de cuenta inactiva y sin saldo
            try
            {
                caja2.Estado = Estado.Inactiva;
                caja2.Depositar(100); //Para CuentaNoActiva
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Excepción] Cuenta {caja2.Numero}: {ex.Message}");
            }

            try
            {
                corriente2.Retirar(300); //Exceso del Descubierto-> SaldoInsuficiente
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Excepción] Cuenta {corriente2.Numero}: {ex.Message}");
            }

            Console.WriteLine("\n\t---- RESUMEN DE CUENTAS ---\n");

            var resumen = cuentas.Select(c => new
            {
                c.Numero,
                Tipo = c.GetType().Name,
                c.Saldo,
                c.Estado

            });

            foreach (var r in resumen)
            {
                Console.WriteLine($"Cuenta: {r.Numero} | Tipo: {r.Tipo} | Saldo: {r.Saldo} | Estado: {r.Estado}");
            }
        }

    }
}
