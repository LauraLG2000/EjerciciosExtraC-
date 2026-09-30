using ModelsVideojuegos;

//1. Videojuegos
Guerrero guerreroMu = new Guerrero("Mu", 20, 9);
Guerrero guerreroGuzran = new Guerrero("Guzran", 21, 12); 
Mago magaOlympa = new Mago("Olympa", 18, 10);
Mago magoSirocco = new Mago("Sirocco", 19, 10);
Arquero arqueroVirion = new Arquero("Virion", 19, 20);
Arquero arqueraLeda = new Arquero("Leda", 20, 20);

List<Personaje> listaPersonajes = [guerreroMu, guerreroGuzran, magaOlympa, magoSirocco, arqueroVirion, arqueraLeda];

Console.WriteLine("====== PERSONAJES ======");
foreach(var personaje in listaPersonajes)
{
    Console.WriteLine(personaje.ObtenerDescripcion());
}