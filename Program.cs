using ModelsVideojuegos;
using ModelsStreaming;
using ModelsBiblioteca;

//1. Videojuegos
Guerrero guerreroMu = new Guerrero("Mu", 20, 9);
Guerrero guerreroGuzran = new Guerrero("Guzran", 21, 12);
Mago magaOlympa = new Mago("Olympa", 18, 10);
Mago magoSirocco = new Mago("Sirocco", 19, 10);
Arquero arqueroVirion = new Arquero("Virion", 19, 20);
Arquero arqueraLeda = new Arquero("Leda", 20, 20);

List<Personaje> listaPersonajes = [guerreroMu, guerreroGuzran, magaOlympa, magoSirocco, arqueroVirion, arqueraLeda];

Console.WriteLine("====== PERSONAJES ======");
foreach (var personaje in listaPersonajes)
{
    Console.WriteLine(personaje.ObtenerDescripcion());
}
Console.WriteLine("");

//2-3 Streaming
Pelicula Anastasia = new Pelicula("Anastasia", 94, "Don Bluth, Gary Goldman");
Pelicula Braveheart = new Pelicula("Braveheart", 177, "Mel Gibson");
Serie ANHQV = new Serie("Aquí No Hay Quien Viva", 90, 5);
Serie LQSA = new Serie("La que se Avecina", 90, 16);
Documental LaVidaEnNuestroPlaneta = new Documental("La Vida en Nuestro Planeta", 56, "Naturaleza y Ciencia");

List<Contenido> contenidoStreaming = [Anastasia, Braveheart, ANHQV, LQSA, LaVidaEnNuestroPlaneta];

//Ejecución métodos
buscarTituloDeStreaming(contenidoStreaming);
filtrarPeliculas(contenidoStreaming);

//Método para buscar título de la lista
void buscarTituloDeStreaming(List<Contenido> listaStreaming)
{
    Console.WriteLine("====== Contenido Streaming ======");
    foreach (var elementoStreaming in listaStreaming)
    {
        Console.WriteLine(elementoStreaming.ObtenerDescripcion());
    }
    Console.WriteLine("");

    //Buscar titulo de la lista
    Console.WriteLine("Introduce el título a buscar: ");
    string tituloBuscar = Console.ReadLine().ToLower().Trim();
    bool tituloEncontrado = false;

    foreach (var elementoStreaming in listaStreaming)
    {
        if (tituloBuscar == elementoStreaming.Titulo.ToLower().Trim())
        {
            Console.WriteLine(elementoStreaming.ObtenerDescripcion());
            tituloEncontrado = true;
        }
    }

    if (!tituloEncontrado)
    {
        Console.WriteLine("No se ha encontrado el contenido");
    }
    
    Console.WriteLine("");
}

//Método para filtrar la lista para mostrar solo las peliculas
void filtrarPeliculas(List<Contenido> listaStreaming)
{
    Console.WriteLine("====== Películas ======");
    foreach (var contenido in listaStreaming)
    {
        if (contenido is Pelicula)
        {
            Console.WriteLine(contenido.ObtenerDescripcion());
        }
    }
    Console.WriteLine("");
}

//5-6 Biblioteca
Libro AlasDeSangre = new Libro("Alas de Sangre", 2023, "Rebecca Yarros");
Libro UnaCorteDeLlamasPlateadas = new Libro("UnaCorteDeLlamasPlateadas", 2021, "Sarah J. Mass");
Revista Loka1 = new Revista("Revista Loka", 2000, 1);
Revista Loka2 = new Revista("Revista Loka", 2000, 2);
Comic TheWalkingDead1 = new Comic("The Walking Dead", 2003, "Charlie Adlard Tony Moore");
Comic TheWalkingDead2 = new Comic("The Walking Dead", 2004, "Charlie Adlard Tony Moore");

List<Publicacion> publicacionesBiblioteca = [AlasDeSangre, UnaCorteDeLlamasPlateadas, Loka1, Loka2, TheWalkingDead1, TheWalkingDead2];

Console.WriteLine("====== PUBLICACIONES BIBLIOTECA ======");
foreach (var publicacion in publicacionesBiblioteca)
{
    publicacion.ObtenerDescripcion();
}
Console.WriteLine("");

solicitarPublicacionesAnterioresAANio(publicacionesBiblioteca);

//Método para solicitar publicaciones anteriores a un número introducido por teclado
void solicitarPublicacionesAnterioresAANio(List<Publicacion> listaPublicaciones)
{
    int anio;
    DateTime fechaActual = DateTime.Now;
    int anioActual = fechaActual.Year;
    int contador = 0;

    Console.WriteLine("Mostrar publicaciones anteriores al año (Introduce un número): ");

    if(int.TryParse(Console.ReadLine(), out anio))
    {

        if(anio <= anioActual)
        {
            Console.WriteLine($"Lista Publicaciones anteriores a {anio}");
            foreach(var publicacion in listaPublicaciones)
            {
                if(publicacion.AnioPublicacion < anio)
                {
                    publicacion.ObtenerDescripcion();
                    contador++;
                }
            }
            if(contador == 0)
            {
                Console.WriteLine($"No hay publicaciones previas al año {anio}");
            }
        }
        else
        {
            Console.WriteLine("No se admiten años futuros.");
        }
    }
}

//7-8 Parking
Coche cocheSeatIbiza = new Coche("Seat Ibiza", "1234BCD", 355, 5);
Coche cocheHundai = new Coche("Hyundai Tucson", "5678FGH", 620, 5);
Coche cochePeugeot = new Coche("Peugeot 5008", "9012JKL", 210, 7);

Furgoneta furgonetaMercedesBenz = new Furgoneta("Mercedes-Benz Sprinter", "1234BCD", 14.0, 270);
Furgoneta furgonetaFordTransit = new Furgoneta("Ford Transit", "5678FGH", 11.5, 180);

Moto motoVespa = new Moto("Vespa Primavera", "2468VWX", "Urbano Integrado", true);
Moto motoHonda = new Moto("Honda PCX 125", "5678FGH", "Estándar", true);

List<Vehiculo> listaVehiculosParking = [cocheSeatIbiza, cocheHundai, cochePeugeot, furgonetaMercedesBenz, furgonetaFordTransit, motoVespa, motoHonda];

int opcionMenuParking=-1;
do{
    Console.WriteLine("=== PARKING ===");
    Console.WriteLine("");
    Console.WriteLine("1. Ver vehículos");
    Console.WriteLine("2. Buscar por matrícula");
    Console.WriteLine("3. Mostrar coches");
    Console.WriteLine("0. Salir");
    Console.WriteLine("");

    Console.Write("Introduce el número de la opcion: ");

    if(int.TryParse(Console.ReadLine(), out opcionMenuParking)){

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
                Console.WriteLine("Opción no encontrada.");
                break;
        }

    }else
    {
        Console.WriteLine("Opción no válida.");
    }

}while(opcionMenuParking != 0);

//Método para listar toda la información de los vehículos del parking
void ListarInformacionVehiculos(List<Vehiculo> listaVehiculos){
    Console.WriteLine("===  Vehículos del Parking   ===");
    foreach (var vehiculo in listaVehiculos)
    {
        Console.WriteLine(vehiculo.ObtenerDescripcion());
    }
}

//Método para buscar un vehículo por su matrícula
void BuscarPorMatricula(List<Vehiculo> listaVehiculos){

    Console.Write("Introduce la matrícula: ");
    string matricula = Console.ReadLine().ToUpper().Trim();

    bool encontrado = false;

    for(int i=0; i<listaVehiculos.length && !encontrado; i++){
        if(listaVehiculos[i].Matricula.ToUpper().Trim() == matricula){
            Console.WriteLine(listaVehiculos[i].ObtenerDescripcion());
            encontrado = true;
        }
    }

    if(!encontrado){
        Console.WriteLine("No se ha encontrado un vehículo con esa matrícula.");
    }
}

//Método para mostrar solo los coches del parking
void MostrarSoloCoches(List<Vehiculo> listaVehiculos){
    int contadorCoches = 0;

    Console.WriteLine("===  Coches del Parking  ===");

    foreach(var vehiculo in listaVehiculos){
        if(vehiculo is Coche){
            vehiculo.ObtenerDescripcion();
            contador++;
        }
    }

    if(contador == 0){
        Consolw.Write("No hay coches registrados en el parking.");
    }
}