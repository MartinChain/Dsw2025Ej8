namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; set; }
    public string[] Titulares { get; }

    protected CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }

    public abstract void Depositar(decimal monto);

    public abstract void Retirar(decimal monto);
    

    protected void VerificarMonto(decimal monto)
    {
        if(monto <= 0)
            throw new MontoNoValidoException();
    }
    protected void VerificarCuentaActiva()
    {
        if (Estado != Estado.Activa)
            throw new CuentaNoActivaException(Estado);
    }
}
