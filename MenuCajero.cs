class MenuCajero
{
    private decimal saldo;
    private const int OpcionSalir = 4;

    public MenuCajero()
    {
        saldo = 1000;
    }

    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== CAJERO ======");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Ingresar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.WriteLine("Introduce una opción (1-4): ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
            {
                Console.WriteLine("Error: Opción no válida. Introduce una opcion del menú (1-4)");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    ConsultarSaldo();
                    break;

                case 2:
                    IngresarDinero();
                    break;

                case 3:
                    RetirarDinero();
                    break;

                case OpcionSalir:
                    break;
            }
        } while (opcion != OpcionSalir);
    }

    void ConsultarSaldo()
    {
        Console.WriteLine($"Saldo actual: {saldo} euros");
    }

    void IngresarDinero()
    {
        try
        {
            decimal dineroIngresar;
            Console.WriteLine("Introduce la cantidad a ingresar: ");

            if (!decimal.TryParse(Console.ReadLine(), out dineroIngresar) || dineroIngresar <= 0)
            {
                throw new ArgumentOutOfRangeException("Error: La cantidad a ingresar no puede ser 0 o negativa");
            }

            saldo += dineroIngresar;
            Console.WriteLine($"Saldo actualizado: {saldo} euros");
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }

    void RetirarDinero()
    {

    }
}