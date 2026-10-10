using ModelsParking;

class MenuParking
{
    private List<Vehiculo> vehiculos;
    private const int OpcionSalir = 7;
    public MenuParking()
    {
        vehiculos = new List<Vehiculo>();
    }
    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== PARKING ======");
            Console.WriteLine("1. Registrar Coche");
            Console.WriteLine("2. Registrar Moto");
            Console.WriteLine("3. Registrar Furgoneta");
            Console.WriteLine("4. Ver vehículos");
            Console.WriteLine("5. Buscar por matrícula");
            Console.WriteLine("6. Mostrar coches");
            Console.WriteLine("7. Volver al menú principal");
            Console.Write("Introduce el número de la opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
            {
                Console.WriteLine("Error: Opción no válida. Introduce una opcion del menú (1-7)");
                continue;
            }
            switch (opcion)
            {
                case 1:
                    RegistrarCoche();
                    break;

                case 2:
                    RegistrarMoto();
                    break;

                case 3:
                    RegistrarFurgoneta();
                    break;

                case 4:
                    ListarVehiculos();
                    break;

                case 5:
                    BuscarPorMatricula();
                    break;

                case 6:
                    MostrarSoloCoches();
                    break;

                case OpcionSalir:
                    break;
            }
        } while (opcion != OpcionSalir);
    }

    void RegistrarCoche()
    {
        try
        {
            Console.WriteLine("Matrícula: ");
            string matricula = Console.ReadLine();
            if (matricula is null || matricula == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo matrícula.");
            }

            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();
            if (marca is null || marca == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo marca.");
            }

            int volumenMaletero;
            Console.WriteLine("Volúmen del maletero (en litros): ");
            if (!int.TryParse(Console.ReadLine(), out volumenMaletero))
            {
                throw new InvalidCastException("Error: Tipo de dato incorrecto.");
            }

            int capacidadPasajeros;
            Console.WriteLine("Cantidad de pasajeros: ");
            if (!int.TryParse(Console.ReadLine(), out capacidadPasajeros))
            {
                throw new InvalidCastException("Error: Tipo de dato incorrecto.");
            }


            Coche coche = new Coche(matricula, marca, volumenMaletero, capacidadPasajeros);

            vehiculos.Add(coche);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
        catch (InvalidCastException ice)
        {
            Console.WriteLine(ice.ToString());
        }
    }

    void RegistrarMoto()
    {
        try
        {
            Console.WriteLine("Matrícula: ");
            string matricula = Console.ReadLine();
            if (matricula is null || matricula == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo matrícula.");
            }

            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();
            if (marca is null || marca == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo marca.");
            }

            Console.WriteLine("Tipo de manillar: ");
            string manillar = Console.ReadLine();

            bool isScooter = false;
            Console.WriteLine("¿Es una scooter? (si/no)");
            string scooter = Console.ReadLine().ToLower().Trim();

            if (scooter.Equals("si"))
            {
                isScooter = true;
            }

            Moto moto = new Moto(matricula, marca, manillar, isScooter);

            vehiculos.Add(moto);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
    }

    void RegistrarFurgoneta()
    {
        try
        {
            Console.WriteLine("Matrícula: ");
            string matricula = Console.ReadLine();
            if (matricula is null || matricula == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo matrícula.");
            }

            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();
            if (marca is null || marca == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo marca.");
            }

            int volumenCarga;
            Console.WriteLine("Volúmen de la carga (en metros cúbicos): ");
            if (!int.TryParse(Console.ReadLine(), out volumenCarga))
            {
                throw new InvalidCastException("Error: Tipo de dato incorrecto.");
            }

            int gradosAperturaPuerta;
            Console.WriteLine("Apertura de la puerta (en grados): ");
            if (!int.TryParse(Console.ReadLine(), out gradosAperturaPuerta))
            {
                throw new InvalidCastException("Error: Tipo de dato incorrecto.");
            }

            Furgoneta furgoneta = new Furgoneta(matricula, marca, volumenCarga, gradosAperturaPuerta);

            vehiculos.Add(furgoneta);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
        catch (InvalidCastException ice)
        {
            Console.WriteLine(ice.ToString());
        }
    }

    void ListarVehiculos()
    {
        Console.WriteLine("===  Vehículos del Parking   ===");
        foreach (var vehiculo in vehiculos)
        {
            vehiculo.ObtenerDescripcion();
        }
    }

    void BuscarPorMatricula()
    {

        Console.Write("Introduce la matrícula: ");
        string matriculaTeclado = Console.ReadLine().ToUpper().Trim();

        bool encontrado = false;

        foreach (var vehiculo in vehiculos)
        {
            if (vehiculo.Matricula.Equals(matriculaTeclado))
            {
                vehiculo.ObtenerDescripcion();
                encontrado = true;
            }

            if (encontrado) break;
        }

        if (!encontrado)
        {
            Console.WriteLine("No se ha encontrado un vehículo con esa matrícula.");
        }
    }

    void MostrarSoloCoches()
    {
        int contadorCoches = 0;

        Console.WriteLine("===  Coches del Parking  ===");

        foreach (var vehiculo in vehiculos)
        {
            if (vehiculo is Coche)
            {
                vehiculo.ObtenerDescripcion();
                contadorCoches++;
            }
        }

        if (contadorCoches == 0)
        {
            Console.WriteLine("No hay coches registrados en el parking.");
        }
    }
}