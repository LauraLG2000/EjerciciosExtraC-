using System.Text.Json;
using ModelsBiblioteca;
using ModelsUtils;

class MenuBiblioteca
{
    private List<Publicacion> publicaciones;
    private const int OpcionSalir = 7;
    private const int PrimeraOpcion = 1;
    string mensajeInput;
    DateTime fechaActual = DateTime.Now;

    public MenuBiblioteca()
    {
        publicaciones = new List<Publicacion>();

        publicaciones.Add(new Libro("Alas de Sangre", 2023, "Rebecca Yarros"));
        publicaciones.Add(new Libro("UnaCorteDeLlamasPlateadas", 2021, "Sarah J. Mass"));
        publicaciones.Add(new Revista("Revista Loka", 2000, 1));
        publicaciones.Add(new Revista("Revista Loka", 2000, 2));
        publicaciones.Add(new Comic("The Walking Dead", 2003, "Charlie Adlard Tony Moore"));
        publicaciones.Add(new Comic("The Walking Dead", 2004, "Charlie Adlard Tony Moore"));

        //publicaciones = CargarFicheroJSON();
    }

    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== BIBLIOTECA ======\n");
            Console.WriteLine($"{PrimeraOpcion}. Añadir Libro");
            Console.WriteLine("2. Añadir Comic");
            Console.WriteLine("3. Añadir Revista");
            Console.WriteLine("4. Listar publicaciones");
            Console.WriteLine("5. Mostrar publicaciones posteriores a un año");
            Console.WriteLine("6. Guardar publicaciones archivo Json");
            Console.WriteLine($"{OpcionSalir}. Volver al menú principal");
            Console.Write($"Introduce el número de la opción ({PrimeraOpcion}-{OpcionSalir}): ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < PrimeraOpcion || opcion > OpcionSalir)
            {
                Console.WriteLine($"Error: Opción no válida. Introduce una opcion del menú ({PrimeraOpcion}-{OpcionSalir})");
                continue;
            }
            switch (opcion)
            {
                case PrimeraOpcion:
                    RegistrarLibro();
                    break;

                case 2:
                    RegistrarComic();
                    break;

                case 3:
                    RegistrarRevista();
                    break;

                case 4:
                    MostrarPublicaciones();
                    break;

                case 5:
                    SolicitarPublicacionesAnterioresAANio();
                    break;

                case 6:
                    GuardarFicheroJSON();
                    break;

                case OpcionSalir:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }

        } while (opcion != OpcionSalir);
    }

    public void RegistrarLibro()
    {
        try
        {
            mensajeInput = "Título ";
            string titulo = InputUtils.InputString(mensajeInput);

            mensajeInput = "Año de publicación ";
            int año = InputUtils.ComparacionAñoConAñoFechaActual(mensajeInput);

            mensajeInput = "Título ";
            string autor = InputUtils.InputString(mensajeInput);

            Libro libro = new Libro(titulo, año, autor);
            publicaciones.Add(libro);
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

    public void RegistrarComic()
    {
        try
        {
            mensajeInput = "Título ";
            string titulo = InputUtils.InputString(mensajeInput);

            mensajeInput = "Año de publicación ";
            int año = InputUtils.ComparacionAñoConAñoFechaActual(mensajeInput);

            mensajeInput = "Dibujante(s) ";
            string dibujante = InputUtils.InputString(mensajeInput);

            Comic comic = new Comic(titulo, año, dibujante);
            publicaciones.Add(comic);
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

    public void RegistrarRevista()
    {
        try
        {
            mensajeInput = "Título ";
            string titulo = InputUtils.InputString(mensajeInput);

            mensajeInput = "Año de publicación ";
            int año = InputUtils.ComparacionAñoConAñoFechaActual(mensajeInput);

            mensajeInput = "Número de la revista ";

            int numeroRevista = InputUtils.InputIntMayorQueCero(mensajeInput);

            Revista revista = new Revista(titulo, año, numeroRevista);
            publicaciones.Add(revista);
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

    public void MostrarPublicaciones()
    {
        Console.WriteLine("\n====== PUBLICACIONES BIBLIOTECA ======\n");
        foreach (var publicacion in publicaciones)
        {
            Console.Write(publicacion.ObtenerDescripcion());
        }
    }

    public void SolicitarPublicacionesAnterioresAANio()
    {
        List<Publicacion> publicacionesFiltradas = new List<Publicacion>();
        int añoActual = fechaActual.Year;

        mensajeInput = "Mostrar publicaciones posteriores al año (Introduce un número) ";
        int añoTeclado = InputUtils.ComparacionAñoConAñoFechaActual(mensajeInput);

        foreach (var publicacion in publicaciones)
        {
            if (añoTeclado <= añoActual)
            {
                publicaciones.Add(publicacion);
            }
        }

        foreach (var publicacion in publicacionesFiltradas)
        {
            Console.Write(publicacion.ObtenerDescripcion());
        }

        if (publicacionesFiltradas.Count == 0)
        {
            Console.WriteLine($"No hay publicaciones posteriores al año {añoTeclado}");
        }
    }

    private void GuardarFichero()
    {
        string rutaFichero = "Publicaciones.txt";

        FicheroUtils.EliminarFichero(rutaFichero);

        foreach (var publicacion in publicaciones)
        {
            FicheroUtils.EscrituraFichero(rutaFichero, publicacion.ObtenerDescripcion());
        }
    }

    private void GuardarFicheroJSON()
    {
        string json = JsonSerializer.Serialize(publicaciones);
        string rutaFichero = "publicaciones.json";

        FicheroUtils.EscrituraFicheroJSON(rutaFichero, json);
    }

    private List<Publicacion> CargarFicheroJSON()
    {
        string rutaFichero = "publicaciones.json";
        List<Publicacion> publicacionesJson = FicheroUtils.CargarDatosFicheroJson<Publicacion>(rutaFichero);
        return publicacionesJson;
    }
}