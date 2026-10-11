using ModelsParking;

class MenuParking
{
    private List<Vehiculo> vehiculos;
    private const int OpcionSalir = 7;
    public MenuParking()
    {
        vehiculos = new List<Vehiculo>();

        vehiculos.Add(new Coche("Seat Ibiza", "1234BCD", 355, 5));
        vehiculos.Add(new Coche("Hyundai Tucson", "5678FGH", 620, 5));
        vehiculos.Add(new Coche("Peugeot 5008", "9012JKL", 210, 7));
        vehiculos.Add(new Furgoneta("Mercedes-Benz Sprinter", "1234BCD", 14.0m, 270));
        vehiculos.Add(new Furgoneta("Ford Transit", "5678FGH", 11.5m, 180));
        vehiculos.Add(new Moto("Vespa Primavera", "2468VWX", "Urbano Integrado", true));
        vehiculos.Add(new Moto("Honda PCX 125", "5678FGH", "Estándar", true));
    }
    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== PARKING ======\n");
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
                    Console.WriteLine("Volviendo al menú principal...");
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

            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();

            int volumenMaletero;
            Console.WriteLine("Volúmen del maletero (en litros): ");
            if (!int.TryParse(Console.ReadLine(), out volumenMaletero) || volumenMaletero < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido. El volumen no puede ser negativo o nulo.");
            }

            int capacidadPasajeros;
            Console.WriteLine("Cantidad de pasajeros: ");
            if (!int.TryParse(Console.ReadLine(), out capacidadPasajeros) || capacidadPasajeros < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido. El volumen no puede ser negativo o nulo.");
            }

            if (marca is null || marca == "" || matricula is null || matricula == "")
            {
                throw new NullReferenceException("Error: Dato no válido. Marca o Matricula están vacíos.");
            }


            Coche coche = new Coche(matricula, marca, volumenMaletero, capacidadPasajeros);

            vehiculos.Add(coche);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }

    void RegistrarMoto()
    {
        try
        {
            Console.WriteLine("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();

            Console.WriteLine("Tipo de manillar: ");
            string manillar = Console.ReadLine();

            bool isScooter = false;
            Console.WriteLine("¿Es una scooter? (si/no)");
            string scooter = Console.ReadLine().ToLower().Trim();

            if (marca is null || marca == "" || matricula is null || matricula == "")
            {
                throw new NullReferenceException("Error: Dato no válido. Marca, matricula están vacíos.");
            }

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

            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();

            int volumenCarga;
            Console.WriteLine("Volúmen de la carga (en metros cúbicos): ");
            if (!int.TryParse(Console.ReadLine(), out volumenCarga) || volumenCarga < 1)
            {
                throw new ArgumentOutOfRangeException("Error: No puede ser negativo o nulo.");
            }

            int gradosAperturaPuerta;
            Console.WriteLine("Apertura de la puerta (en grados): ");
            if (!int.TryParse(Console.ReadLine(), out gradosAperturaPuerta))
            {
                throw new ArgumentOutOfRangeException("Error: No puede ser negativo o nulo.");
            }

            if (marca is null || marca == "" || matricula is null || matricula == "")
            {
                throw new NullReferenceException("Error: Dato no válido. Marca, matricula o es scooter están vacíos.");
            }

            Furgoneta furgoneta = new Furgoneta(matricula, marca, volumenCarga, gradosAperturaPuerta);

            vehiculos.Add(furgoneta);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
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