using ModelsStreaming;

class MenuStreaming
{
    private List<Contenido> listaStreaming;
    private const int OpcionFinal = 7;

    public MenuStreaming()
    {
        listaStreaming = new List<Contenido>();
        listaStreaming.Add(new Pelicula("Anastasia", 94, "Don Bluth, Gary Goldman"));
        listaStreaming.Add(new Pelicula("Braveheart", 177, "Mel Gibson"));
        listaStreaming.Add(new Serie("Aquí No Hay Quien Viva", 90, 5));
        listaStreaming.Add(new Serie("La que se Avecina", 90, 16));
        listaStreaming.Add(new Documental("La Vida en Nuestro Planeta", 56, "Naturaleza y Ciencia"));
    }

    public void MostrarMenu()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("\n====== PLATAFORMA DE STREAMING ======");
            Console.WriteLine("1. Añadir pelicula");
            Console.WriteLine("2. Añadir serie");
            Console.WriteLine("3. Añadir documental");
            Console.WriteLine("4. Listar contenido streaming");
            Console.WriteLine("5. Buscar título");
            Console.WriteLine("6. Mostrar solo las películas");
            Console.WriteLine("7. Volver al menú principal");
            Console.Write("Introduce el número de la opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionFinal)
            {
                Console.WriteLine("Error: Dato no válido, debe ser un valor de la lista (1-7)");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarPelicula();
                    break;

                case 2:
                    RegistrarSerie();
                    break;

                case 3:
                    RegistrarDocumental();
                    break;

                case 4:
                    ListarContenido();
                    break;

                case 5:
                    BuscarTituloDeStreaming();
                    break;

                case 6:
                    FiltrarPeliculas();
                    break;

                case OpcionFinal:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }

        } while (opcion != OpcionFinal);
    }

    void RegistrarPelicula()
    {
        try
        {
            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();
            if (titulo is null || titulo == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo título.");
            }

            int duracion;
            Console.WriteLine("Duración (en minutos): ");
            if (!int.TryParse(Console.ReadLine(), out duracion) || duracion < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido. No puede ser nulo o negativo");
            }

            string director;
            Console.WriteLine("Director(es): ");
            director = Console.ReadLine();
            if (director is null || director == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacio el campo director");
            }

            Pelicula pelicula = new Pelicula(titulo, duracion, director);

            listaStreaming.Add(pelicula);
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

    void RegistrarSerie()
    {
        try
        {
            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();
            if (titulo is null || titulo == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo título.");
            }

            int duracion;
            Console.WriteLine("Duración (en minutos): ");
            if (!int.TryParse(Console.ReadLine(), out duracion) || duracion < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido. No puede ser nulo o negativo");
            }

            int numeroTemporadas;
            Console.WriteLine("Cantidad temporadas: ");
            if (!int.TryParse(Console.ReadLine(), out numeroTemporadas) || numeroTemporadas < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido. No puede ser nulo o negativo");
            }

            Serie serie = new Serie(titulo, duracion, numeroTemporadas);

            listaStreaming.Add(serie);
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

    void RegistrarDocumental()
    {
        try
        {
            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();

            int duracion;
            Console.WriteLine("Duración (en minutos): ");
            if (!int.TryParse(Console.ReadLine(), out duracion) || duracion < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido. No puede ser nulo o negativo");
            }

            string tematica;
            Console.WriteLine("Temática: ");

            tematica = Console.ReadLine();
            if (titulo is null || titulo == "" || tematica is null || tematica == "")
            {
                throw new NullReferenceException("Error: Dato no válido. Título o temática están vacíos.");
            }

            Documental documental = new Documental(titulo, duracion, tematica);

            listaStreaming.Add(documental);
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

    void BuscarTituloDeStreaming()
    {
        Console.WriteLine("Introduce el título a buscar: ");
        string tituloBuscar = Console.ReadLine().ToLower().Trim();
        bool tituloEncontrado = false;

        foreach (var contenido in listaStreaming)
        {
            if (tituloBuscar == contenido.Titulo.ToLower().Trim())
            {
                Console.WriteLine(contenido.ObtenerDescripcion());
                tituloEncontrado = true;
            }
        }

        if (!tituloEncontrado)
        {
            Console.WriteLine("No se ha encontrado ningún elemento con ese título");
        }
    }

    void FiltrarPeliculas()
    {
        Console.WriteLine("\n====== PELÍCULAS ======\n");
        foreach (var contenido in listaStreaming)
        {
            if (contenido is Pelicula)
            {
                Console.WriteLine(contenido.ObtenerDescripcion());
            }
        }
    }

    void ListarContenido()
    {
        Console.WriteLine("\n====== CONTENIDO STREAMING ======\n");
        foreach (var contenido in listaStreaming)
        {
            Console.WriteLine(contenido.ObtenerDescripcion());
        }
        Console.WriteLine("");
    }
}