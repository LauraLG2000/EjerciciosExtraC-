using ModelsVideojuegos;

class MenuVideojuegos
{
    private List<Personaje> personajes;
    private const int OpcionSalida = 5;

    public MenuVideojuegos()
    {
        personajes = new List<Personaje>();
    }

    public void MostrarMenu()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("====== VIDEOJUEGOS ======\r\n\r\n");
            Console.WriteLine("1. Registrar Guerrero");
            Console.WriteLine("2. Registrar Mago");
            Console.WriteLine("3. Registrar Arquero");
            Console.WriteLine("4. Unidades de la campaña");
            Console.WriteLine("5. Volver atrás");
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

                case OpcionSalida:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        }while(opcion != OpcionSalida);
    }

    void RegistrarGuerrero()
    {
        Console.WriteLine("Nombre del guerrero: ");
        string nombre = Console.ReadLine();

        int vida = 1;
        Console.WriteLine("Vida del guerrero: ");
        if(!int.TryParse(Console.ReadLine(), out vida) || vida < 1)
        {
            throw new IndexOutOfRangeException("Error: Dato no válido. Se pondrá por defecto 1.");
        }

        int fuerza = 1;
        Console.WriteLine("Fuerza del guerrero: ");
        if(!int.TryParse(Console.ReadLine(), out fuerza) || fuerza < 1)
        {
            throw new IndexOutOfRangeException("Error: Dato no válido. Se pondrá por defecto 1.");
        }

        Guerrero guerrero = new Guerrero(nombre, vida, fuerza);

        personajes.Add(guerrero);
    }

    void RegistrarMago()
    {
        Console.WriteLine("Nombre del mago: ");
        string nombre = Console.ReadLine();

        int vida = 1;
        Console.WriteLine("Vida del mago: ");
        if(!int.TryParse(Console.ReadLine(), out vida) || vida < 1)
        {
            throw new IndexOutOfRangeException("Error: Dato no válido. Se pondrá por defecto 1.");
        }

        int mana = 1;
        Console.WriteLine("Mana: ");
        if(!int.TryParse(Console.ReadLine(), out mana) || mana < 1)
        {
            throw new IndexOutOfRangeException("Error: Dato no válido. Se pondrá por defecto 1.");
        }

        Mago mago = new Mago(nombre, vida, mana);

        personajes.Add(mago);
    }

    void RegistrarArquero()
    {
        Console.WriteLine("Nombre del arquero: ");
        string nombre = Console.ReadLine();

        int vida = 1;
        Console.WriteLine("Vida del arquero: ");
        if(!int.TryParse(Console.ReadLine(), out vida) || vida < 1)
        {
            throw new IndexOutOfRangeException("Error: Dato no válido. Se pondrá por defecto 1.");
        }

        int numeroFlechas = 1;
        Console.WriteLine("Número de flechas: ");
        if(!int.TryParse(Console.ReadLine(), out numeroFlechas) || numeroFlechas < 1)
        {
            throw new IndexOutOfRangeException("Error: Dato no válido. Se pondrá por defecto 1.");
        }

        Arquero arquero = new Arquero(nombre, vida, numeroFlechas);

        personajes.Add(arquero);
    }

    void ListarUnidades()
    {
        Console.WriteLine("====== UNIDADES ======\r\n\r\n");
        foreach(var personaje in personajes)
        {
            Console.WriteLine(personaje.ObtenerDescripcion());
        }
    }
}