using System.Text.Json;
using ModelsStreaming;
using ModelsUtils;

class MenuStreaming
{
    private List<Contenido> listaStreaming;
    private const int OpcionSalir = 8;
    private const int PrimeraOpcion = 1;
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
            Console.WriteLine($"{PrimeraOpcion}. Añadir pelicula");
            Console.WriteLine("2. Añadir serie");
            Console.WriteLine("3. Añadir documental");
            Console.WriteLine("4. Listar contenido streaming");
            Console.WriteLine("5. Buscar título");
            Console.WriteLine("6. Mostrar solo las películas");
            Console.WriteLine("7. Guardar lista de contenido en Json");
            Console.WriteLine($"{OpcionSalir}. Volver al menú principal");
            Console.Write($"Introduce el número de la opción ({PrimeraOpcion}-{OpcionSalir}): ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < PrimeraOpcion || opcion > OpcionSalir)
            {
                Console.WriteLine($"Error: Dato no válido, debe ser un valor de la lista ({PrimeraOpcion}-{OpcionSalir})");
                continue;
            }

            switch (opcion)
            {
                case PrimeraOpcion:
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
        mensajeInput = "Introduce el título a buscar ";
        string tituloBuscar = InputUtils.InputString(mensajeInput).ToLower().Trim();

        bool isTituloEncontrado = false;
        Contenido contenidoEncontrado;

        foreach (var contenido in listaStreaming)
        {
            if (tituloBuscar == contenido.Titulo.ToLower().Trim())
            {
                contenidoEncontrado = contenido;
                Console.WriteLine(contenidoEncontrado.ObtenerDescripcion());
                isTituloEncontrado = true;
            }

            if (isTituloEncontrado) break;
        }

        if (!isTituloEncontrado)
        {
            Console.WriteLine("No se ha encontrado ningún elemento con ese título");
        }
    }

    public void FiltrarPeliculas()
    {
        List<Contenido> filtradoPeliculas = new List<Contenido>();

        foreach (var contenido in listaStreaming)
        {
            if (contenido is Pelicula)
            {
                filtradoPeliculas.Add(contenido);
            }
        }

        if (filtradoPeliculas.Count == 0)
        {
            Console.WriteLine("No hay peliculas en el listado de streaming.");
        }
        else
        {
            Console.WriteLine("\n====== PELÍCULAS ======\n");
            foreach (var pelicula in filtradoPeliculas)
            {
                Console.WriteLine(pelicula.ObtenerDescripcion());
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
        List<Contenido> contenidoJson = FicheroUtils.CargarDatosFicheroJson<Contenido>(rutaFichero);
        return contenidoJson;
    }
}