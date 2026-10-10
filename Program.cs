using ModelsBiblioteca;
using ModelsParking;
using ModelsArticulo;

var menuVideojegos = new MenuVideojuegos();
var menuStreaming = new MenuStreaming();

//5-6 Biblioteca
Libro AlasDeSangre = new Libro("Alas de Sangre", 2023, "Rebecca Yarros");
Libro UnaCorteDeLlamasPlateadas = new Libro("UnaCorteDeLlamasPlateadas", 2021, "Sarah J. Mass");
Revista Loka1 = new Revista("Revista Loka", 2000, 1);
Revista Loka2 = new Revista("Revista Loka", 2000, 2);
Comic TheWalkingDead1 = new Comic("The Walking Dead", 2003, "Charlie Adlard Tony Moore");
Comic TheWalkingDead2 = new Comic("The Walking Dead", 2004, "Charlie Adlard Tony Moore");

List<Publicacion> publicacionesBiblioteca = [AlasDeSangre, UnaCorteDeLlamasPlateadas, Loka1, Loka2, TheWalkingDead1, TheWalkingDead2];

//7-8 Parking
Coche cocheSeatIbiza = new Coche("1234BCD", "Seat Ibiza", 355, 5);
Coche cocheHundai = new Coche("5678FGH", "Hyundai Tucson", 620, 5);
Coche cochePeugeot = new Coche("9012JKL", "Peugeot 5008", 210, 7);
Furgoneta furgonetaMercedesBenz = new Furgoneta("1234XYZ", "Mercedes-Benz Sprinter", 14.0m, 270);
Furgoneta furgonetaFordTransit = new Furgoneta("5678IJK", "Ford Transit", 11.5m, 180);
Moto motoVespa = new Moto("2468ZAB", "Vespa Primavera", "Urbano Integrado", true);
Moto motoHonda = new Moto("5678EFG", "Honda PCX 125", "Estándar", true);

List<Vehiculo> listaVehiculosParking = [cocheSeatIbiza, cocheHundai, cochePeugeot, furgonetaMercedesBenz, furgonetaFordTransit, motoVespa, motoHonda];

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

            //Ejercicios videojuego
            case 1:
                menuVideojegos.MostrarMenu();
                break;

            //Ejercicios Streaming
            case 2:
                menuStreaming.MostrarMenu();
                break;

            //Ejercicios biblioteca
            case 3:
                int opcionMenuBiblioteca = -1;
                do
                {
                    Console.WriteLine("====== BIBLIOTECA ======");
                    Console.WriteLine("");
                    Console.WriteLine("1. Listar publicaciones");
                    Console.WriteLine("2. Mostrar publicaciones posteriores a un año");
                    Console.WriteLine("0. Volver al menú principal");
                    Console.WriteLine("");
                    Console.Write("Introduce el número de la opción: ");

                    if (int.TryParse(Console.ReadLine(), out opcionMenuBiblioteca))
                    {
                        switch (opcionMenuBiblioteca)
                        {
                            case 0:
                                Console.WriteLine("Volviendo al menú principal");
                                break;

                            case 1:
                                MostrarPublicacionesBiblioteca(publicacionesBiblioteca);
                                break;

                            case 2:
                                SolicitarPublicacionesAnterioresAANio(publicacionesBiblioteca);
                                break;

                            default:
                                Console.WriteLine("Opción no válida");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida");
                        opcionMenuBiblioteca = -1;
                    }
                } while (opcionMenuBiblioteca != 0);
                break;

            //Ejercicios parking
            case 4:
                int opcionMenuParking = -1;
                do
                {
                    Console.WriteLine("=== PARKING ===");
                    Console.WriteLine("");
                    Console.WriteLine("1. Ver vehículos");
                    Console.WriteLine("2. Buscar por matrícula");
                    Console.WriteLine("3. Mostrar coches");
                    Console.WriteLine("0. Salir");
                    Console.WriteLine("");

                    Console.Write("Introduce el número de la opcion: ");

                    if (int.TryParse(Console.ReadLine(), out opcionMenuParking))
                    {

                        switch (opcionMenuParking)
                        {
                            case 0:
                                Console.WriteLine("Gracias por su visita");
                                break;

                            case 1:
                                ListarInformacionVehiculos(listaVehiculosParking);
                                break;

                            case 2:
                                BuscarPorMatricula(listaVehiculosParking);
                                break;

                            case 3:
                                MostrarSoloCoches(listaVehiculosParking);
                                break;

                            default:
                                Console.WriteLine("Opción no válida.");
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                        opcionMenuParking = -1;
                    }

                } while (opcionMenuParking != 0);
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

//Método para mostrar la información de todas las publicaciones de la biblioteca
void MostrarPublicacionesBiblioteca(List<Publicacion> publicaciones)
{
    Console.WriteLine("====== PUBLICACIONES BIBLIOTECA ======");
    foreach (var publicacion in publicaciones)
    {
        publicacion.ObtenerDescripcion();
    }
    Console.WriteLine("");
}

//Método para solicitar publicaciones anteriores a un número introducido por teclado
void SolicitarPublicacionesAnterioresAANio(List<Publicacion> listaPublicaciones)
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
            foreach (var publicacion in listaPublicaciones)
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

//Método para listar toda la información de los vehículos del parking
void ListarInformacionVehiculos(List<Vehiculo> listaVehiculos)
{
    Console.WriteLine("===  Vehículos del Parking   ===");
    foreach (var vehiculo in listaVehiculos)
    {
        vehiculo.ObtenerDescripcion();
    }
}

//Método para buscar un vehículo por su matrícula
void BuscarPorMatricula(List<Vehiculo> listaVehiculos)
{

    Console.Write("Introduce la matrícula: ");
    string matriculaTeclado = Console.ReadLine().ToUpper().Trim();

    bool encontrado = false;

    foreach (var vehiculo in listaVehiculos)
    {
        if (vehiculo.Matricula.Equals(matriculaTeclado))
        {
            vehiculo.ObtenerDescripcion();
            encontrado = true;
        }

        if (encontrado) break;
    }

    if (!encontrado)
    {
        Console.WriteLine("No se ha encontrado un vehículo con esa matrícula.");
    }
}

//Método para mostrar solo los coches del parking
void MostrarSoloCoches(List<Vehiculo> listaVehiculos)
{
    int contadorCoches = 0;

    Console.WriteLine("===  Coches del Parking  ===");

    foreach (var vehiculo in listaVehiculos)
    {
        if (vehiculo is Coche)
        {
            vehiculo.ObtenerDescripcion();
            contadorCoches++;
        }
    }

    if (contadorCoches == 0)
    {
        Console.WriteLine("No hay coches registrados en el parking.");
    }
}

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