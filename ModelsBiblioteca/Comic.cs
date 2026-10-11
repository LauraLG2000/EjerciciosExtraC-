namespace ModelsBiblioteca;

public class Comic : Publicacion
{
    public string Dibujante{get;set;}
    public Comic(string _titulo, int _anioPublicacion, string _dibujante) : base(_titulo, _anioPublicacion)
    {
        this.Dibujante = _dibujante;
    }

    public override void ObtenerDescripcion()
    {
        Console.WriteLine($"Comic {Titulo} - Dibujante: {Dibujante} - Año de Publicación: {AnioPublicacion}");
    }
}