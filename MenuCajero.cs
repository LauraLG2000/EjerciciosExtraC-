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

    public void ConsultarSaldo()
    {
        Console.WriteLine($"Saldo actual: {saldo} euros");
    }

    public void IngresarDinero()
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

    public void RetirarDinero()
    {
        try
        {
            decimal dineroRetirar;

            Console.WriteLine("Introduce la cantidad a retirar: ");
            if (!decimal.TryParse(Console.ReadLine(), out dineroRetirar) || dineroRetirar <= 0 || dineroRetirar > saldo)
            {
                throw new ArgumentOutOfRangeException("Error: La cantidad no puede ser 0, negativa o superior al saldo disponible");
            }

            saldo -= dineroRetirar;

            Console.WriteLine($"Cantidad retirada: {dineroRetirar}. Saldo disponible: {saldo}");
        } catch(ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }
}