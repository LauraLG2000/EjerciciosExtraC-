namespace ModelsStreaming;

public class Pelicula : Contenido
{
    public string Director{get;set;}

    public Pelicula()
    {
        
    }
    public Pelicula(string _titulo, int _duracion, string _Director) : base(_titulo, _duracion)
    {
        this.Director = _Director;
    }

    public override string ObtenerDescripcion()
    {
        return $"Película {Titulo} - Duración: {Duracion} min - Director: {Director}\n";
    }
}