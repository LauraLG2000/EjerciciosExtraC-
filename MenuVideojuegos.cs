using ModelsVideojuegos;
using ModelsUtils;
using System.Text.Json;

class MenuVideojuegos
{
    private List<Personaje> personajes;
    private const int OpcionSalida = 6;
    string mensajeInput;

    public MenuVideojuegos()
    {
        personajes = new List<Personaje>();
        personajes.Add(new Guerrero("Mu", 20, 9));
        personajes.Add(new Guerrero("Guzran", 21, 12));
        personajes.Add(new Mago("Olympa", 18, 10));
        personajes.Add(new Mago("Sirocco", 19, 10));
        personajes.Add(new Arquero("Virion", 19, 20));
        personajes.Add(new Arquero("Leda", 20, 20));

        //personajes = CargarFicheroJson();
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
            Console.WriteLine("5. Guardar personajes de la partida en Json");
            Console.WriteLine($"{OpcionSalida}. Volver atrás");
            Console.WriteLine($"Elige una opción (1-{OpcionSalida})");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalida)
            {
                Console.WriteLine($"Error: Introduce una opción válida (1-{OpcionSalida})");
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
                    GuardarFicheroJson();
                    break;

                case OpcionSalida:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        } while (opcion != OpcionSalida);
    }

    public void RegistrarGuerrero()
    {
        try
        {
            mensajeInput = "Nombre del guerrero ";
            string nombre = InputUtils.InputString(mensajeInput);

            mensajeInput = "Vida del guerrero ";
            int vida = InputUtils.InputIntMayorQueUno(mensajeInput);

            mensajeInput = "Fuerza del guerrero ";
            int fuerza = InputUtils.InputIntMayorQueUno(mensajeInput);

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

    public void RegistrarMago()
    {
        try
        {
            mensajeInput = "Nombre del mago ";
            string nombre = InputUtils.InputString(mensajeInput);

            mensajeInput = "Vida del mago ";
            int vida = InputUtils.InputIntMayorQueUno(mensajeInput);

            mensajeInput = "Mana del mago ";
            int mana = InputUtils.InputIntMayorQueUno(mensajeInput);

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

    public void RegistrarArquero()
    {
        try
        {
            mensajeInput = "Nombre del mago ";
            string nombre = InputUtils.InputString(mensajeInput);

            mensajeInput = "Vida del mago ";
            int vida = InputUtils.InputIntMayorQueUno(mensajeInput);

            mensajeInput = "Mana del mago ";
            int numeroFlechas = InputUtils.InputIntMayorQueUno(mensajeInput);

            Arquero arquero = new Arquero(nombre, vida, numeroFlechas);
            personajes.Add(arquero);
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

    public void ListarUnidades()
    {
        Console.WriteLine("\n====== UNIDADES ======\n");
        foreach (var personaje in personajes)
        {
            Console.Write(personaje.ObtenerDescripcion());
        }
    }

    private void GuardarFicheroJson()
    {
        string rutaFichero = "UnidadesCampaña.json";
        string json = JsonSerializer.Serialize(personajes);

        FicheroUtils.EscrituraFicheroJSON(rutaFichero, json);
    }

    private List<Personaje> CargarFicheroJson()
    {
        string rutaFichero = "UnidadesCampaña.json";
        List<Personaje> personajesJson = FicheroUtils.CargarDatosFicheroJson<Personaje>(rutaFichero);

        return personajesJson;
    }
}