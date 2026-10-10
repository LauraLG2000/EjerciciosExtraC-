using ModelsGimnasio;

class MenuGimnasio
{
    private List<Actividad> actividades;
    private const int OpcionSalir = 5;

    public MenuGimnasio()
    {
        actividades.Add(new Yoga("Yoga Matinal", 60, 15, "Vinyasa", true));
        actividades.Add(new Yoga("Relajación Profunda", 45, 20, "Hatha", false));
        actividades.Add(new Spinning("Ciclo Indoor Pro", 45, 30, 22.5m, 3));
        actividades.Add(new Spinning("Spinning Resistencia", 60, 25, 30, 5));
        actividades.Add(new CrossTraining("WOD Fuerza", 50, 12, 80, 5));
        actividades.Add(new CrossTraining("Cross Funcional", 45, 16, 40, 8));
    }

    void MostrarMenu()
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

            if(!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
            {
                Console.WriteLine("Error: Opción no listada. Seleccione una válida (1-5)");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;
                
                case OpcionSalir:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
            }
        }while(opcion != OpcionSalir);
    }

    void VerActividades()
    {
        
    }

    void BuscarActividad()
    {
        
    }

    void BuscarActividadesPorDuracionMaxima()
    {
        
    }

    void BuscarActividadPorTipo()
    {
        
    }
}