using ModelsBiblioteca;

class MenuBiblioteca
{
    private List<Publicacion> publicaciones;
    private const int OpcionSalir = 6;

    public MenuBiblioteca()
    {
        publicaciones = new List<Publicacion>();

        publicaciones.Add(new Libro("Alas de Sangre", 2023, "Rebecca Yarros"));
        publicaciones.Add(new Libro("UnaCorteDeLlamasPlateadas", 2021, "Sarah J. Mass"));
        publicaciones.Add(new Revista("Revista Loka", 2000, 1));
        publicaciones.Add(new Revista("Revista Loka", 2000, 2));
        publicaciones.Add(new Comic("The Walking Dead", 2003, "Charlie Adlard Tony Moore"));
        publicaciones.Add(new Comic("The Walking Dead", 2004, "Charlie Adlard Tony Moore"));
    }

    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== BIBLIOTECA ======");
            Console.WriteLine("1. Añadir Libro");
            Console.WriteLine("2. Añadir Comic");
            Console.WriteLine("3. Añadir Revista");
            Console.WriteLine("4. Listar publicaciones");
            Console.WriteLine("5. Mostrar publicaciones posteriores a un año");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Introduce el número de la opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
            {
                Console.WriteLine("Error: Opción no válida. Introduce una opcion del menú (1-6)");
                continue;
            }
            switch (opcion)
            {
                case 1:
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

                case OpcionSalir:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }

        } while (opcion != OpcionSalir);
    }

    void RegistrarLibro()
    {
        try
        {
            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();
            if (titulo is null || titulo == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo título.");
            }

            int año;
            DateTime dateTime = DateTime.Now;
            int añoActual = dateTime.Year;

            Console.WriteLine("Año de publicación: ");
            if (!int.TryParse(Console.ReadLine(), out año) || año > añoActual)
            {
                throw new IndexOutOfRangeException("Error: Dato no válido. El año no puede ser posterior al actual.");
            }

            string autor;
            Console.WriteLine("Director(es): ");
            autor = Console.ReadLine();
            if (autor is null || autor == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacio el campo autor");
            }

            Libro libro = new Libro(titulo, año, autor);

            publicaciones.Add(libro);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
        catch (IndexOutOfRangeException iofre)
        {
            Console.WriteLine(iofre.ToString());
        }
    }

    void RegistrarComic()
    {
        try
        {
            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();
            if (titulo is null || titulo == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo título.");
            }

            int año;
            DateTime dateTime = DateTime.Now;
            int añoActual = dateTime.Year;

            Console.WriteLine("Año de publicación: ");
            if (!int.TryParse(Console.ReadLine(), out año) || año > añoActual)
            {
                throw new IndexOutOfRangeException("Error: Dato no válido. El año no puede ser posterior al actual.");
            }

            string dibujante;
            Console.WriteLine("Director(es): ");
            dibujante = Console.ReadLine();
            if (dibujante is null || dibujante == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacio el campo dibujante");
            }

            Comic comic = new Comic(titulo, año, dibujante);

            publicaciones.Add(comic);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
        catch (IndexOutOfRangeException iofre)
        {
            Console.WriteLine(iofre.ToString());
        }
    }

    void RegistrarRevista()
    {
        try
        {
            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();
            if (titulo is null || titulo == "")
            {
                throw new NullReferenceException("Error: Dato no válido. No puede estar vacío el campo título.");
            }

            int año;
            DateTime dateTime = DateTime.Now;
            int añoActual = dateTime.Year;

            Console.WriteLine("Año de publicación: ");
            if (!int.TryParse(Console.ReadLine(), out año) || año > añoActual)
            {
                throw new IndexOutOfRangeException("Error: Dato no válido. El año no puede ser posterior al actual.");
            }

            int numeroRevista;
            Console.WriteLine("Año de publicación: ");
            if (!int.TryParse(Console.ReadLine(), out numeroRevista) || numeroRevista < 1)
            {
                throw new IndexOutOfRangeException("Error: Dato no válido. El número no puede ser 0 o negativo.");
            }

            Revista revista = new Revista(titulo, año, numeroRevista);

            publicaciones.Add(revista);
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
        catch (IndexOutOfRangeException iofre)
        {
            Console.WriteLine(iofre.ToString());
        }
    }

    //Método para mostrar la información de todas las publicaciones de la biblioteca
    void MostrarPublicaciones()
    {
        Console.WriteLine("\n====== PUBLICACIONES BIBLIOTECA ======");
        foreach (var publicacion in publicaciones)
        {
            publicacion.ObtenerDescripcion();
        }
        Console.WriteLine("");
    }

    //Método para solicitar publicaciones anteriores a un número introducido por teclado
    void SolicitarPublicacionesAnterioresAANio()
    {
        int anio;
        DateTime fechaActual = DateTime.Now;
        int anioActual = fechaActual.Year;
        int contador = 0;

        Console.WriteLine("Mostrar publicaciones posteriores al año (Introduce un número): ");

        if (int.TryParse(Console.ReadLine(), out anio))
        {

            if (anio <= anioActual)
            {
                Console.WriteLine($"Lista Publicaciones anteriores a {anio}");
                foreach (var publicacion in publicaciones)
                {
                    if (publicacion.AnioPublicacion > anio)
                    {
                        publicacion.ObtenerDescripcion();
                        contador++;
                    }
                }
                if (contador == 0)
                {
                    Console.WriteLine($"No hay publicaciones posteriores al año {anio}");
                }
            }
            else
            {
                Console.WriteLine("No se admiten años futuros.");
            }
        }
    }
}