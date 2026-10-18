var menuVideojegos = new MenuVideojuegos();
var menuStreaming = new MenuStreaming();
var menuBiblioteca = new MenuBiblioteca();
var menuParking = new MenuParking();
var menuArticulo = new MenuArticulo();
var menuCajero = new MenuCajero();
var menuGimnasio = new MenuGimnasio();
var menuAdivinarNumero = new MenuAdivinarNumero();

const int OpcionSalir = 9;
const int PrimeraOpcion = 1;

int opcion;

do
{
    Console.WriteLine("\n====== EJERCICIOS EXTRA C# ======\n");
    Console.WriteLine($"{PrimeraOpcion}. Videojuegos");
    Console.WriteLine("2. Plataforma de Streaming");
    Console.WriteLine("3. Biblioteca");
    Console.WriteLine("4. Parking");
    Console.WriteLine("5. Artículos");
    Console.WriteLine("6. Cajero");
    Console.WriteLine("7. Adivina el número");
    Console.WriteLine("8. Menú Gimnasio");
    Console.WriteLine($"{OpcionSalir}. Salir");
    Console.Write($"Introduce el número de la opción ({PrimeraOpcion}-{OpcionSalir}): ");

    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < PrimeraOpcion || opcion > OpcionSalir)
    {
        Console.WriteLine($"Error: Opción no válida. Introduce una opcion del menú ({PrimeraOpcion}-{OpcionSalir})");
        continue;
    }

    switch (opcion)
    {
        case PrimeraOpcion:
            menuVideojegos.MostrarMenu();
            break;

        case 2:
            menuStreaming.MostrarMenu();
            break;

        case 3:
            menuBiblioteca.MostrarMenu();
            break;

        case 4:
            menuParking.MostrarMenu();
            break;

        case 5:
            menuArticulo.MostrarMenu();
            break;

        case 6:
            menuCajero.MostrarMenu();
            break;

        case 7:
            menuAdivinarNumero.AdivinarNumero();
            break;

        case 8:
            menuGimnasio.MostrarMenu();
            break;

        case OpcionSalir:
            Console.WriteLine("Programa cerrado");
            break;
    }
} while (opcion != OpcionSalir);