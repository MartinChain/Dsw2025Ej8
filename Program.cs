namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Presentacion.Principal();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
