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