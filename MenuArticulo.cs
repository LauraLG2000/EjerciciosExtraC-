using ModelsArticulo;

class MenuArticulo
{
    private List<Articulo> articulos;
    private const int OpcionSalir = 6;
    public MenuArticulo()
    {
        articulos = new List<Articulo>();

        articulos.Add(new Articulo("Micrófono", 29.99m));
        articulos.Add(new Articulo("Ratón Inalámbrico", 40.99m));
        articulos.Add(new Articulo("Cascos", 9.99m));
    }

    public void MostrarMenu()
    {
        int opcion;


        do
        {
            Console.WriteLine("\n====== ARTÍCULOS ======");
            Console.WriteLine("1. Añadir artículo");
            Console.WriteLine("2. Ver artículos");
            Console.WriteLine("3. Artículo más barato");
            Console.WriteLine("4. Precio Medio Artículos");
            Console.WriteLine("5. Listar articulos por un precio máximo");
            Console.WriteLine("6. Salir");
            Console.Write("Introduce el número de la opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
            {
                Console.WriteLine("Error: Opción no válida. Introduce una opcion del menú (1-6)");
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

            Console.WriteLine("Año de publicación: ");
            if (!decimal.TryParse(Console.ReadLine(), out precio) || precio < 0)
            {
                throw new InvalidCastException("Error: Dato no válido.");
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
        Console.WriteLine("\n======  Artículos   ======");
        foreach (var articulo in articulos)
        {
            articulo.DescripcionArticulo();
        }
    }

    void ArticuloMasBarato()
    {

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

        articulos[0].DescripcionArticulo();
    }

    void PrecioMedioArticulos()
    {
        decimal sumaPrecios = 0;
        int cantidadArticulos = articulos.Count;

        foreach (var articulo in articulos)
        {
            sumaPrecios += articulo.Precio;
        }

        decimal precioMedio = sumaPrecios / cantidadArticulos;

        Console.WriteLine($"Precio medio: {precioMedio}€");
    }

    void ArticulosPorPrecioMaximo()
    {
        Console.WriteLine("Precio máximo de la búsqueda:");

        decimal precioMaximo = 0;
        int contadorArticulos = 0;

        if (decimal.TryParse(Console.ReadLine(), out precioMaximo))
        {
            foreach (var articulo in articulos)
            {
                if (articulo.Precio <= precioMaximo)
                {
                    articulo.DescripcionArticulo();
                    contadorArticulos++;
                }
            }

            if (contadorArticulos == 0)
            {
                Console.WriteLine($"No hay artículos con un precio inferior o igual a {precioMaximo}€");
            }
        }
        else
        {
            Console.WriteLine("Valor no válido.");
        }
    }
}