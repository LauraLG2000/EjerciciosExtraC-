using ModelsVideojuegos;
using ModelsStreaming;

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
buscarTituloDeStreaming(contenidoStreaming);

//Método para buscar título de la lista
void buscarTituloDeStreaming(List<Contenido> contenido)
{
    Console.WriteLine("====== Contenido Streaming ======");
    foreach (var elementoStreaming in contenido)
    {
        Console.WriteLine(elementoStreaming.ObtenerDescripcion());
    }
    Console.WriteLine("");

    //Buscar titulo de la lista
    Console.WriteLine("Introduce el título a buscar: ");
    string tituloBuscar = Console.ReadLine().ToLower().Trim();
    bool tituloEncontrado = false;

    foreach (var elementoStreaming in contenido)
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
}

