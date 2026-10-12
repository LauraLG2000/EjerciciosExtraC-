using System.Text.Json;
using ModelsArticulo;
using ModelsUtils;

class MenuArticulo
{
    private List<Articulo> articulos;
    private const int OpcionSalir = 8;
    public MenuArticulo()
    {
        articulos = new List<Articulo>();

        /*articulos.Add(new Articulo("Micrófono", 29.99m));
        articulos.Add(new Articulo("Ratón Inalámbrico", 40.99m));
        articulos.Add(new Articulo("Cascos", 9.99m));*/

        articulos = CargarFicheroJson();
    }

    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== ARTÍCULOS ======\n");
            Console.WriteLine("1. Añadir artículo");
            Console.WriteLine("2. Ver artículos");
            Console.WriteLine("3. Artículo más barato");
            Console.WriteLine("4. Precio Medio Artículos");
            Console.WriteLine("5. Listar articulos por un precio máximo");
            Console.WriteLine("6. Guardar listado articulos");
            Console.WriteLine("7. Guardar fichero JSON");
            Console.WriteLine("8. Salir");
            Console.Write("Introduce el número de la opcion (1-8): ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
            {
                Console.WriteLine("Error: Opción no válida. Introduce una opcion del menú (1-7)");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AñadirArticulo();
                    break;

                case 2:
                    ListarArticulos();
                    break;

                case 3:
                    ArticuloMasBarato();
                    break;

                case 4:
                    PrecioMedioArticulos();
                    break;

                case 5:
                    ArticulosPorPrecioMaximo();
                    break;

                case 6:
                    GuardarFichero();
                    break;

                case 7:
                    GuardarFicheroJson();
                    break;

                case OpcionSalir:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        } while (opcion != OpcionSalir);
    }

    void AñadirArticulo()
    {
        try
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            if (nombre is null || nombre == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo nombre.");
            }

            decimal precio;

            Console.WriteLine("Precio: ");
            if (!decimal.TryParse(Console.ReadLine(), out precio) || precio < 0)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido. El precio no puede ser negativo");
            }
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

    void ListarArticulos()
    {
        Console.WriteLine("\n====== ARTÍCULOS ======\n");
        foreach (var articulo in articulos)
        {
            Console.Write(articulo.DescripcionArticulo());
        }
    }

    void ArticuloMasBarato()
    {
        try
        {
            if (articulos is null || articulos.Count == 0)
            {
                throw new NullReferenceException("No hay articulos registrados");
            }

            for (int i = 0; i < articulos.Count; i++)
            {
                for (int j = 0; j < articulos.Count; j++)
                {
                    if (articulos[i].Precio < articulos[j].Precio)
                    {
                        Articulo articuloTemporal = articulos[i];
                        articulos[i] = articulos[j];
                        articulos[j] = articuloTemporal;
                    }
                }
            }

            Console.Write(articulos[0].DescripcionArticulo());
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
    }

    void PrecioMedioArticulos()
    {
        try
        {
            if (articulos is null || articulos.Count == 0)
            {
                throw new NullReferenceException("No hay articulos registrados");
            }

            decimal sumaPrecios = 0;
            int cantidadArticulos = articulos.Count;

            foreach (var articulo in articulos)
            {
                sumaPrecios += articulo.Precio;
            }

            decimal precioMedio = sumaPrecios / cantidadArticulos;

            Console.WriteLine($"Precio medio: {precioMedio}€");
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }

    }

    void ArticulosPorPrecioMaximo()
    {
        try
        {

            if (articulos is null || articulos.Count == 0)
            {
                throw new NullReferenceException("No hay articulos registrados");
            }

            Console.WriteLine("Precio máximo de la búsqueda:");

            decimal precioMaximo = 0;
            int contadorArticulos = 0;

            if (!decimal.TryParse(Console.ReadLine(), out precioMaximo))
            {
                throw new InvalidCastException("Dato erroneo");
            }
            foreach (var articulo in articulos)
            {
                if (articulo.Precio <= precioMaximo)
                {
                    Console.Write(articulo.DescripcionArticulo());
                    contadorArticulos++;
                }
            }

            if (contadorArticulos == 0)
            {
                Console.WriteLine($"No hay artículos con un precio inferior o igual a {precioMaximo}€");
            }
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

    private void GuardarFichero()
    {
        string rutaFichero = "Artículos.txt";

        FicheroUtils.EliminarFichero(rutaFichero);

        foreach (var articulo in articulos)
        {
            FicheroUtils.EscrituraFichero(rutaFichero, articulo.DescripcionArticulo());
        }
    }

    private void GuardarFicheroJson()
    {
        string json = JsonSerializer.Serialize(articulos);
        FicheroUtils.EscrituraFicheroJSON("articulos.json", json);
    }

    private List<Articulo> CargarFicheroJson()
    {
        string rutaFichero = "articulos.json";
        List<Articulo> articulosJson = new List<Articulo>();

        try
        {
            if (!File.Exists(rutaFichero))
            {
                throw new FileNotFoundException("No se encuentra la ruta");
            }

            string json = FicheroUtils.LecturaFichero(rutaFichero);
            articulosJson = JsonSerializer.Deserialize<List<Articulo>>(json);

            return articulosJson;


        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.ToString());
            return articulosJson;
        }
    }
}