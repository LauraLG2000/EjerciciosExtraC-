using ModelsBiblioteca;
using ModelsParking;
using ModelsArticulo;


var menuVideojegos = new MenuVideojuegos();
var menuStreaming = new MenuStreaming();
var menuBiblioteca = new MenuBiblioteca();
var menuParking = new MenuParking();

//9, 10, 11 Artículos
Articulo microfono = new Articulo("Micrófono", 29.99m);
Articulo ratonInalambrico = new Articulo("Ratón Inalámbrico", 40.99m);
Articulo cascos = new Articulo("Cascos", 9.99m);

List<Articulo> listaArticulos = [microfono, ratonInalambrico, cascos];


//Menú ejercicios extra
int opcionMenuExtra = -1;
do
{
    Console.WriteLine("====== EJERCICIOS EXTRA C# ======\n");
    Console.WriteLine("1. Videojuegos");
    Console.WriteLine("2. Plataforma de Streaming");
    Console.WriteLine("3. Biblioteca");
    Console.WriteLine("4. Parking");
    Console.WriteLine("5. Artículos");
    Console.WriteLine("0. Salir");
    Console.WriteLine("");
    Console.Write("Introduce el número de la opción: ");

    if (int.TryParse(Console.ReadLine(), out opcionMenuExtra))
    {
        switch (opcionMenuExtra)
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

            //Ejercicios articulo
            case 5:
                int opcionMenuArticulo = -1;
                do
                {
                    Console.WriteLine("====== ARTÍCULOS ======");
                    Console.WriteLine("");
                    Console.WriteLine("1. Ver artículos");
                    Console.WriteLine("2. Artículo más barato");
                    Console.WriteLine("3. Precio Medio Artículos");
                    Console.WriteLine("4. Listar articulos por un precio máximo");
                    Console.WriteLine("0. Salir");
                    Console.WriteLine("");

                    Console.Write("Introduce el número de la opcion: ");

                    if (int.TryParse(Console.ReadLine(), out opcionMenuArticulo))
                    {

                        switch (opcionMenuArticulo)
                        {
                            case 0:
                                Console.WriteLine("Gracias por su visita");
                                break;

                            case 1:
                                ListarInformacionArticulos(listaArticulos);
                                break;

                            case 2:
                                ArticuloMasBarato(listaArticulos);
                                break;

                            case 3:
                                PrecioMedioArticulos(listaArticulos);
                                break;

                            case 4:
                                ArticulosPorPrecioMaximo(listaArticulos);
                                break;

                            default:
                                Console.WriteLine("Opción no válida.");
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                        opcionMenuArticulo = -1;
                    }

                } while (opcionMenuArticulo != 0);
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Opción no válida.");
        opcionMenuExtra = -1;
    }
} while (opcionMenuExtra != 0);





//Método para listar toda la información de los vehículos del parking
void ListarInformacionArticulos(List<Articulo> articulos)
{
    Console.WriteLine("======  Artículos   ======");
    foreach (var articulo in articulos)
    {
        articulo.DescripcionArticulo();
    }
}

//Método para mostrar el artículo más barato de la lista
void ArticuloMasBarato(List<Articulo> articulos)
{

    for (int i = 0; i < articulos.Count; i++)
    {
        for (int j = 0; j < articulos.Count; j++)
        {
            if (articulos[i].Precio < articulos[j].Precio)
            {
                Articulo articuloTemporal = articulos[i];
                articulos[i] = articulos[j];
                articulos[j] = articuloTemporal;
            }
        }
    }

    articulos[0].DescripcionArticulo();
}

//Método para calcular el precio medio de los articulos
void PrecioMedioArticulos(List<Articulo> articulos)
{
    decimal sumaPrecios = 0;
    int cantidadArticulos = articulos.Count;

    foreach (var articulo in articulos)
    {
        sumaPrecios += articulo.Precio;
    }

    decimal precioMedio = sumaPrecios / cantidadArticulos;

    Console.WriteLine($"Precio medio: {precioMedio}€");
}

//Método para buscar un rango de productos por un precio máximo introducido por teclado
void ArticulosPorPrecioMaximo(List<Articulo> articulos)
{
    Console.WriteLine("Precio máximo de la búsqueda:");

    decimal precioMaximo = 0;
    int contadorArticulos = 0;

    if (decimal.TryParse(Console.ReadLine(), out precioMaximo))
    {
        foreach (var articulo in articulos)
        {
            if (articulo.Precio <= precioMaximo)
            {
                articulo.DescripcionArticulo();
                contadorArticulos++;
            }
        }

        if (contadorArticulos == 0)
        {
            Console.WriteLine($"No hay artículos con un precio inferior o igual a {precioMaximo}€");
        }
    }
    else
    {
        Console.WriteLine("Valor no válido.");
    }
}