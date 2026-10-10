var menuVideojegos = new MenuVideojuegos();
var menuStreaming = new MenuStreaming();
var menuBiblioteca = new MenuBiblioteca();
var menuParking = new MenuParking();
var menuArticulo = new MenuArticulo();
var menuCajero = new MenuCajero();

const int OpcionSalir = 8;
int opcion;

do
{
    Console.WriteLine("\n====== EJERCICIOS EXTRA C# ======\n");
    Console.WriteLine("1. Videojuegos");
    Console.WriteLine("2. Plataforma de Streaming");
    Console.WriteLine("3. Biblioteca");
    Console.WriteLine("4. Parking");
    Console.WriteLine("5. Artículos");
    Console.WriteLine("6. Cajero");
    Console.WriteLine("7. Adivina el número");
    Console.WriteLine("8. Salir");
    Console.Write("Introduce el número de la opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > OpcionSalir)
    {
        Console.WriteLine("Error: Opción no válida. Introduce una opcion del menú (1-6)");
        continue;
    }

    switch (opcion)
    {
        case 0:
            Console.WriteLine("Programa terminado.");
            break;

        case 1:
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
            AdivinarNumero();
            break;

        case OpcionSalir:
            Console.WriteLine("Programa cerrado");
            break;
    }
} while (opcion != OpcionSalir);

void AdivinarNumero()
{
    int numeroAleatorio = GenerarNumeroAleatorio();
    int numero;
    int contador = 0;

    Console.WriteLine("\n====== ADIVINA EL NÚMERO ======");

    do
    {
        Console.WriteLine("Introduce un número (1-100):");
        if(!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Error: Introduce un número válido (1-100)");
            continue;
        }

        if(numero < numeroAleatorio)
        {
            Console.WriteLine("El número a adivinar es más grande.");
        }

        if(numero > numeroAleatorio)
        {
            Console.WriteLine("El número a adivinar es más pequeño.");
        }

        contador++;
    }while(numero != numeroAleatorio);

    Console.WriteLine($"Correcto. El número era {numeroAleatorio}. Has necesitado {contador} intentos.");
}

int GenerarNumeroAleatorio()
{
    Random random = new Random();
    return random.Next(1, 101);
}