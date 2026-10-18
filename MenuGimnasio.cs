using System.Text.Json;
using ModelsGimnasio;
using ModelsUtils;

class MenuGimnasio
{
    private List<Actividad> actividades;
    private const int OpcionSalir = 6;
    private const int PrimeraOpcion = 1;
    string mensajeInput;

    public MenuGimnasio()
    {
        actividades = new List<Actividad>();

        actividades.Add(new Yoga("Yoga Matinal", 60, 15, "Vinyasa", true));
        actividades.Add(new Yoga("Relajación Profunda", 45, 20, "Hatha", false));
        actividades.Add(new Spinning("Ciclo Indoor Pro", 45, 30, 22.5m, 3));
        actividades.Add(new Spinning("Spinning Resistencia", 60, 25, 30, 5));
        actividades.Add(new CrossTraining("WOD Fuerza", 50, 12, 80, 5));
        actividades.Add(new CrossTraining("Cross Funcional", 45, 16, 40, 8));

        //actividades = CargarFicheroJSON();
    }

    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== GIMNASIO ======\n");
            Console.WriteLine($"{PrimeraOpcion}. Ver actividades");
            Console.WriteLine("2. Buscar actividad");
            Console.WriteLine("3. Ver actividades por duración máxima");
            Console.WriteLine("4. Ver actividades por tipo");
            Console.WriteLine("5. Guardar actividades en Json");
            Console.WriteLine($"{OpcionSalir}. Salir");
            Console.WriteLine($"Introduce el número de una opción ({PrimeraOpcion}-{OpcionSalir})");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < PrimeraOpcion || opcion > OpcionSalir)
            {
                Console.WriteLine("Error: Opción no listada. Seleccione una válida (1-6)");
                continue;
            }

            switch (opcion)
            {
                case PrimeraOpcion:
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

                case 5:
                    GuardarFicheroJSON();
                    break;

                case OpcionSalir:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        } while (opcion != OpcionSalir);
    }

    public void VerActividades()
    {
        Console.WriteLine("\n====== ACTIVIDADES DEL GIMNASIO ======\n");
        foreach (var actividad in actividades)
        {
            Console.WriteLine(actividad.InformacionActividad());
        }
    }

    public void BuscarActividad()
    {
        try
        {
            mensajeInput = "Introduce el nombre de la actividad ";
            string buscarActividad = InputUtils.InputString(mensajeInput);

            bool isActividadEncontrada = false;
            Actividad actividadEncontrada;

            foreach (var actividad in actividades)
            {
                if (actividad.Nombre.ToLower().Trim().Equals(buscarActividad.ToLower().Trim()))
                {
                    actividadEncontrada = actividad;
                    Console.WriteLine(actividadEncontrada);
                    isActividadEncontrada = true;
                }

                if(isActividadEncontrada) break;
            }

            if (!isActividadEncontrada)
            {
                Console.WriteLine($"No se ha encontrado ninguna actividad con el nombre {buscarActividad}");
            }
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
    }

    public void BuscarActividadesPorDuracionMaxima()
    {
        try
        {
            mensajeInput = "Introduce la duración en minutos ";
            int duracion = InputUtils.InputIntMayorQueUno(mensajeInput);

            List<Actividad> actividadesPorDuracion = new List<Actividad>();

            foreach (var actividad in actividades)
            {
                if (actividad.Duracion <= duracion)
                {
                    actividadesPorDuracion.Add(actividad);
                }
            }

            if (actividadesPorDuracion.Count == 0)
            {
                Console.WriteLine($"No hay actividades con una duración máxima de {duracion}");
            }
            else
            {
                foreach (var actividad in actividadesPorDuracion)
                {
                    Console.WriteLine(actividad.InformacionActividad());
                }
            }
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }

    public void BuscarActividadPorTipo()
    {
        try
        {
            mensajeInput = "Introduce el tipo de actividad a buscar (yoga, crosstraining...) ";
            string tipo = InputUtils.InputString(mensajeInput);

            List<Actividad> actividadesPorTipo = new List<Actividad>();

            foreach (var actividad in actividades)
            {
                if (actividad.Tipo.ToString().Equals(tipo.ToLower().Trim()))
                {
                    actividadesPorTipo.Add(actividad);
                }
            }

            if (actividades.Count == 0)
            {
                Console.WriteLine($"No hay actividades registradas de tipo {tipo}");
            }
            else
            {
                foreach (var actividad in actividadesPorTipo)
                {
                    Console.WriteLine(actividad.InformacionActividad());
                }
            }
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine(nre.ToString());
        }
    }

    private void GuardarFicheroJSON()
    {
        string rutaFichero = "clasesGimnasio.json";
        string json = JsonSerializer.Serialize(actividades);

        FicheroUtils.EscrituraFicheroJSON(rutaFichero, json);
    }

    private List<Actividad> CargarFicheroJSON()
    {
        string rutaFichero = "clasesGimnasio.json";
        List<Actividad> actividadesJson = FicheroUtils.CargarDatosFicheroJson<Actividad>(rutaFichero);
        return actividadesJson;
    }
}