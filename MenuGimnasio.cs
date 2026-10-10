using ModelsGimnasio;

class MenuGimnasio
{
    private List<Actividad> actividades;
    private const int OpcionSalir = 5;

    public MenuGimnasio()
    {
        actividades = new List<Actividad>();

        actividades.Add(new Yoga("Yoga Matinal", 60, 15, "Vinyasa", true));
        actividades.Add(new Yoga("Relajación Profunda", 45, 20, "Hatha", false));
        actividades.Add(new Spinning("Ciclo Indoor Pro", 45, 30, 22.5m, 3));
        actividades.Add(new Spinning("Spinning Resistencia", 60, 25, 30, 5));
        actividades.Add(new CrossTraining("WOD Fuerza", 50, 12, 80, 5));
        actividades.Add(new CrossTraining("Cross Funcional", 45, 16, 40, 8));
    }

    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== GIMNASIO ======\n");
            Console.WriteLine("1. Ver actividades");
            Console.WriteLine("2. Buscar actividad");
            Console.WriteLine("3. Ver actividades por duración máxima");
            Console.WriteLine("4. Ver actividades por tipo");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Introduce el número de una opción (1-5)");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
            {
                Console.WriteLine("Error: Opción no listada. Seleccione una válida (1-5)");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    VerActividades();
                    break;

                case 2:
                    BuscarActividad();
                    break;

                case 3:
                    BuscarActividadesPorDuracionMaxima();
                    break;

                case 4:
                    BuscarActividadPorTipo();
                    break;

                case OpcionSalir:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        } while (opcion != OpcionSalir);
    }

    void VerActividades()
    {
        Console.WriteLine("\n====== ACTIVIDADES DEL GIMNASIO ======\n");
        foreach (var actividad in actividades)
        {
            Console.WriteLine(actividad.InformacionActividad());
        }
    }

    void BuscarActividad()
    {
        try
        {
            Console.WriteLine("Introduce el nombre de la actividad: ");
            string buscarActividad = Console.ReadLine();
            bool actividadEncontrada = false;

            if (buscarActividad is null || buscarActividad == "")
            {
                throw new NullReferenceException("Error: El nombre de la actividad no puede estar vacío");
            }

            foreach (var actividad in actividades)
            {
                if (actividad.Nombre.ToLower().Trim().Equals(buscarActividad.ToLower().Trim()))
                {
                    Console.WriteLine(actividad.InformacionActividad());
                    actividadEncontrada = true;
                    continue;
                }
            }

            if (!actividadEncontrada)
            {
                Console.WriteLine($"No se ha encontrado ninguna actividad con el nombre {buscarActividad}");
            }
        }catch(NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
    }

    void BuscarActividadesPorDuracionMaxima()
    {
        try
        {
            int duracion;
            int contador = 0;
            Console.WriteLine("Introduce la duración en minutos: ");

            if(!int.TryParse(Console.ReadLine(), out duracion) || duracion <= 0)
            {
                throw new ArgumentOutOfRangeException("Error: La duración no puede ser 0 o negativa");
            }

            foreach(var actividad in actividades)
            {
                if(actividad.Duracion <= duracion)
                {
                    Console.WriteLine(actividad.InformacionActividad());
                    contador++;
                }
            }

            if(contador == 0)
            {
                Console.WriteLine("No hay actividades con esa duración");
            }

        }catch(ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }

    void BuscarActividadPorTipo()
    {
        try
        {
            int contador = 0;

            Console.WriteLine("Introduce el tipo de actividad a buscar (yoga, crosstraining...): ");
            string tipo = Console.ReadLine().ToLower().Trim();

            if(tipo is null || tipo == "")
            {
                throw new NullReferenceException("Error: El tipo no puede estar vacío.");
            }

            foreach(var actividad in actividades)
            {

                if (actividad.Tipo.ToString().Equals(tipo))
                {
                    Console.WriteLine(actividad.InformacionActividad());
                    contador++;
                }
            }

            if(contador == 0)
            {
                Console.WriteLine($"No hay actividades registrar de tipo {tipo}");
            }

        }catch(NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
    }
}