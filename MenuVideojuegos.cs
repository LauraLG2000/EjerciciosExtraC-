using ModelsVideojuegos;
using ModelsUtils;

class MenuVideojuegos
{
    private List<Personaje> personajes;
    private const int OpcionSalida = 6;

    public MenuVideojuegos()
    {
        personajes = new List<Personaje>();
        personajes.Add(new Guerrero("Mu", 20, 9));
        personajes.Add(new Guerrero("Guzran", 21, 12));
        personajes.Add(new Mago("Olympa", 18, 10));
        personajes.Add(new Mago("Sirocco", 19, 10));
        personajes.Add(new Arquero("Virion", 19, 20));
        personajes.Add(new Arquero("Leda", 20, 20));
    }

    public void MostrarMenu()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("\n====== VIDEOJUEGOS ======\n");
            Console.WriteLine("1. Registrar Guerrero");
            Console.WriteLine("2. Registrar Mago");
            Console.WriteLine("3. Registrar Arquero");
            Console.WriteLine("4. Unidades de la campaña");
            Console.WriteLine("5. Guardar partida");
            Console.WriteLine("6. Volver atrás");
            Console.WriteLine("Elige una opción (1-5)");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalida)
            {
                Console.WriteLine("Error: Introduce una opción válida (1-5)");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarGuerrero();
                    break;

                case 2:
                    RegistrarMago();
                    break;

                case 3:
                    RegistrarArquero();
                    break;

                case 4:
                    ListarUnidades();
                    break;

                case 5:
                    GuardarFichero();
                    break;

                case OpcionSalida:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        } while (opcion != OpcionSalida);
    }

    void RegistrarGuerrero()
    {
        try
        {
            Console.WriteLine("Nombre del guerrero: ");
            string nombre = Console.ReadLine();

            if (nombre is null || nombre == "")
            {
                throw new NullReferenceException("Error: el campo nombre no puede estar vacío");
            }

            int vida;
            Console.WriteLine("Vida del guerrero: ");
            if (!int.TryParse(Console.ReadLine(), out vida) || vida < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido.");
            }

            int fuerza;
            Console.WriteLine("Fuerza del guerrero: ");
            if (!int.TryParse(Console.ReadLine(), out fuerza) || fuerza < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido.");
            }

            Guerrero guerrero = new Guerrero(nombre, vida, fuerza);

            personajes.Add(guerrero);
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

    void RegistrarMago()
    {
        try
        {
            Console.WriteLine("Nombre del mago: ");
            string nombre = Console.ReadLine();

            if (nombre is null || nombre == "")
            {
                throw new NullReferenceException("Error: el campo nombre no puede estar vacío");
            }

            int vida;
            Console.WriteLine("Vida del mago: ");
            if (!int.TryParse(Console.ReadLine(), out vida) || vida < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido.");
            }

            int mana;
            Console.WriteLine("Mana: ");
            if (!int.TryParse(Console.ReadLine(), out mana) || mana < 1)
            {
                throw new ArgumentOutOfRangeException("Error: Dato no válido.");
            }

            Mago mago = new Mago(nombre, vida, mana);

            personajes.Add(mago);
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

    void RegistrarArquero()
    {
        Console.WriteLine("Nombre del arquero: ");
        string nombre = Console.ReadLine();

        if (nombre is null || nombre == "")
            {
                throw new NullReferenceException("Error: el campo nombre no puede estar vacío");
            }

        int vida;
        Console.WriteLine("Vida del arquero: ");
        if (!int.TryParse(Console.ReadLine(), out vida) || vida < 1)
        {
            throw new ArgumentOutOfRangeException("Error: Dato no válido.");
        }

        int numeroFlechas;
        Console.WriteLine("Número de flechas: ");
        if (!int.TryParse(Console.ReadLine(), out numeroFlechas) || numeroFlechas < 1)
        {
            throw new ArgumentOutOfRangeException("Error: Dato no válido.");
        }

        Arquero arquero = new Arquero(nombre, vida, numeroFlechas);

        personajes.Add(arquero);
    }

    void ListarUnidades()
    {
        Console.WriteLine("\n====== UNIDADES ======\n");
        foreach (var personaje in personajes)
        {
            Console.Write(personaje.ObtenerDescripcion());
        }
    }

    void GuardarFichero()
    {
        string rutaFichero = "UnidadesVideojuego.txt";
        
        FicheroUtils.EliminarFichero(rutaFichero);

        foreach(var personaje in personajes)
        {
            FicheroUtils.EscrituraFichero(rutaFichero, personaje.ObtenerDescripcion());
        }
    }
}