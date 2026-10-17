using ModelsUtils;

class MenuCajero
{
    private decimal saldo;
    private const int OpcionSalir = 4;
    private const int PrimeraOpcion = 1;
    string mensajeInput;

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
            Console.WriteLine($"{PrimeraOpcion}. Consultar saldo");
            Console.WriteLine("2. Ingresar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine($"{OpcionSalir}. Salir");
            Console.WriteLine($"Introduce una opción ({PrimeraOpcion}-{OpcionSalir}): ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < PrimeraOpcion || opcion > OpcionSalir)
            {
                Console.WriteLine($"Error: Opción no válida. Introduce una opcion del menú ({PrimeraOpcion}-{OpcionSalir})");
                continue;
            }

            switch (opcion)
            {
                case PrimeraOpcion:
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
            mensajeInput = "Introduce la cantidad a ingresar ";
            decimal dineroIngresar = InputUtils.InputDecimalMayorQueCero(mensajeInput);

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
            mensajeInput = "Introduce la cantidad a retirar ";
            decimal dineroRetirar = InputUtils.InputDecimalMayorQueCero(mensajeInput);
            
            if (dineroRetirar > saldo)
            {
                throw new ArgumentOutOfRangeException("Error: La cantidad no puede ser superior al saldo disponible");
            }

            saldo -= dineroRetirar;

            Console.WriteLine($"Cantidad retirada: {dineroRetirar}. Saldo disponible: {saldo}");
        } catch(ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }
}