using System.Text.Json;
using ModelsParking;
using ModelsUtils;

class MenuParking
{
    private List<Vehiculo> vehiculos;
    private const int OpcionSalir = 8;
    private const int PrimeraOpcion = 1;
    string mensajeInput;
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

        //vehiculos = CargarFicheroJson();
    }
    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== PARKING ======\n");
            Console.WriteLine($"{PrimeraOpcion}. Registrar Coche");
            Console.WriteLine("2. Registrar Moto");
            Console.WriteLine("3. Registrar Furgoneta");
            Console.WriteLine("4. Ver vehículos");
            Console.WriteLine("5. Buscar por matrícula");
            Console.WriteLine("6. Mostrar coches");
            Console.WriteLine("7. Guardar registro vehículos Json");
            Console.WriteLine($"{OpcionSalir}. Volver al menú principal");
            Console.Write($"Introduce el número de la opcion ({PrimeraOpcion}-{OpcionSalir}): ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < PrimeraOpcion || opcion > OpcionSalir)
            {
                Console.WriteLine($"Error: Opción no válida. Introduce una opcion del menú ({PrimeraOpcion}-{OpcionSalir})");
                continue;
            }
            switch (opcion)
            {
                case PrimeraOpcion:
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

                case 7:
                    GuardarFicheroJSON();
                    break;

                case OpcionSalir:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        } while (opcion != OpcionSalir);
    }

    public void RegistrarCoche()
    {
        try
        {
            mensajeInput = "Matrícula ";
            string matricula = InputUtils.InputString(mensajeInput);

            mensajeInput = "Marca ";
            string marca = InputUtils.InputString(mensajeInput);

            mensajeInput = "Volúmen del maletero (en litros): ";
            int volumenMaletero = InputUtils.InputIntMayorQueUno(mensajeInput);

            mensajeInput = "Volúmen del maletero (en litros): ";
            int capacidadPasajeros = InputUtils.InputIntMayorQueUno(mensajeInput);

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

    public void RegistrarMoto()
    {
        try
        {
            mensajeInput = "Matrícula ";
            string matricula = InputUtils.InputString(mensajeInput);

            mensajeInput = "Marca ";
            string marca = InputUtils.InputString(mensajeInput);

            mensajeInput = "Tipo de manillar ";
            string manillar = InputUtils.InputString(mensajeInput);

            mensajeInput = "¿Es una scooter? (si/no) ";
            bool isScooter = InputUtils.InputBoolOpcionSiNo(mensajeInput);

            Moto moto = new Moto(matricula, marca, manillar, isScooter);
            vehiculos.Add(moto);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
    }

    public void RegistrarFurgoneta()
    {
        try
        {
            mensajeInput = "Matrícula ";
            string matricula = InputUtils.InputString(mensajeInput);

            mensajeInput = "Marca ";
            string marca = InputUtils.InputString(mensajeInput);

            mensajeInput = "Volúmen de la carga (en metros cúbicos) ";
            int volumenCarga = InputUtils.InputIntMayorQueUno(mensajeInput);

            mensajeInput = "Apertura de la puerta (en grados) ";
            int gradosAperturaPuerta = InputUtils.InputIntMayorQueUno(mensajeInput);

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

    public void ListarVehiculos()
    {
        Console.WriteLine("===  Vehículos del Parking   ===");
        foreach (var vehiculo in vehiculos)
        {
            Console.Write(vehiculo.ObtenerDescripcion());
        }
    }

    public void BuscarPorMatricula()
    {

        Console.Write("Introduce la matrícula: ");
        string matriculaTeclado = Console.ReadLine().ToUpper().Trim();

        bool encontrado = false;

        foreach (var vehiculo in vehiculos)
        {
            if (vehiculo.Matricula.Equals(matriculaTeclado))
            {
                Console.Write(vehiculo.ObtenerDescripcion());
                encontrado = true;
            }

            if (encontrado) break;
        }

        if (!encontrado)
        {
            Console.WriteLine("No se ha encontrado un vehículo con esa matrícula.");
        }
    }

    public void MostrarSoloCoches()
    {
        List<Vehiculo> listaCoches = new List<Vehiculo>();

        foreach (var vehiculo in vehiculos)
        {
            if (vehiculo is Coche)
            {
                listaCoches.Add(vehiculo);
            }
        }

        Console.WriteLine("\n======  COCHES DEL PARKING  ======\n");

        foreach (var coche in listaCoches)
        {
            Console.Write(coche.ObtenerDescripcion());
        }

        if (listaCoches.Count == 0)
        {
            Console.WriteLine("No hay coches registrados en el parking.");
        }
    }

    private void GuardarFicheroJSON()
    {
        string rutaFichero = "vehiculosRegistrados.json";
        string json = JsonSerializer.Serialize(vehiculos);

        FicheroUtils.EscrituraFicheroJSON(rutaFichero, json);
    }

    private List<Vehiculo> CargarFicheroJson()
    {
        string rutaFichero = "vehiculosRegistrados.json";
        List<Vehiculo> vehiculosJson = new List<Vehiculo>();

        try
        {
            if (!File.Exists(rutaFichero))
            {
                throw new FileNotFoundException("No se ha encontrado la ruta del fichero");
            }

            string json = FicheroUtils.LecturaFichero(rutaFichero);
            vehiculosJson = JsonSerializer.Deserialize<List<Vehiculo>>(json);

            return vehiculosJson;
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.ToString());
            return vehiculosJson;
        }
    }
}