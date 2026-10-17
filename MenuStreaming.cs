using System.Text.Json;
using ModelsStreaming;
using ModelsUtils;

class MenuStreaming
{
    private List<Contenido> listaStreaming;
    private const int OpcionSalir = 8;

    string mensajeInput;

    public MenuStreaming()
    {
        listaStreaming = new List<Contenido>();
        listaStreaming.Add(new Pelicula("Anastasia", 94, "Don Bluth, Gary Goldman"));
        listaStreaming.Add(new Pelicula("Braveheart", 177, "Mel Gibson"));
        listaStreaming.Add(new Serie("Aquí No Hay Quien Viva", 90, 5));
        listaStreaming.Add(new Serie("La que se Avecina", 90, 16));
        listaStreaming.Add(new Documental("La Vida en Nuestro Planeta", 56, "Naturaleza y Ciencia"));

        //listaStreaming = CargarFicheroJson();
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
            Console.WriteLine("7. Guardar lista de contenido en Json");
            Console.WriteLine($"{OpcionSalir}. Volver al menú principal");
            Console.Write($"Introduce el número de la opción (1-{OpcionSalir}): ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
            {
                Console.WriteLine($"Error: Dato no válido, debe ser un valor de la lista (1-{OpcionSalir})");
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

                case 7:
                    GuardarFicheroJson();
                    break;

                case OpcionSalir:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }

        } while (opcion != OpcionSalir);
    }

    public void RegistrarPelicula()
    {
        try
        {
            mensajeInput = "Título ";
            string titulo = InputUtils.InputString(mensajeInput);

            mensajeInput = "Duración (en minutos) ";
            int duracion = InputUtils.InputIntMayorQueUno(mensajeInput);

            mensajeInput = "Director(es) ";
            string director = InputUtils.InputString(mensajeInput);

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

    public void RegistrarSerie()
    {
        try
        {
            mensajeInput = "Título ";
            string titulo = InputUtils.InputString(mensajeInput);

            mensajeInput = "Duración (en minutos) ";
            int duracion = InputUtils.InputIntMayorQueUno(mensajeInput);

            mensajeInput = "Duración (en minutos) ";
            int numeroTemporadas = InputUtils.InputIntMayorQueUno(mensajeInput);

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

    public void RegistrarDocumental()
    {
        try
        {
            mensajeInput = "Título ";
            string titulo = InputUtils.InputString(mensajeInput);

            mensajeInput = "Duración (en minutos) ";
            int duracion = InputUtils.InputIntMayorQueUno(mensajeInput);

            mensajeInput = "Temática ";
            string tematica = InputUtils.InputString(mensajeInput);

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

    public void BuscarTituloDeStreaming()
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

    public void FiltrarPeliculas()
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

    public void ListarContenido()
    {
        Console.WriteLine("\n====== CONTENIDO STREAMING ======\n");
        foreach (var contenido in listaStreaming)
        {
            Console.Write(contenido.ObtenerDescripcion());
        }
    }

    private void GuardarFicheroJson()
    {
        string rutaFichero = "ContenidoStreaming.json";
        string json = JsonSerializer.Serialize(listaStreaming);

        FicheroUtils.EscrituraFicheroJSON(rutaFichero, json);
    }

    private List<Contenido> CargarFicheroJson()
    {
        string rutaFichero = "ContenidoStreaming.json";
        List<Contenido> contenidoJson = new List<Contenido>();

        try
        {
            if (!File.Exists(rutaFichero))
            {
                throw new FileNotFoundException("No se ha encontrado la ruta del fichero");
            }

            string json = FicheroUtils.LecturaFichero(rutaFichero);
            contenidoJson = JsonSerializer.Deserialize<List<Contenido>>(json);

            return contenidoJson;
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.ToString());
            return contenidoJson;
        }
    }
}