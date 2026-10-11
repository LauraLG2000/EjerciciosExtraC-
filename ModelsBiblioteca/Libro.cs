namespace ModelsBiblioteca;

public class Libro : Publicacion
{
    public string Autor{get;set;}
    public Libro(string _titulo, int _anioPublicacion, string _autor) : base(_titulo, _anioPublicacion)
    {
        this.Autor = _autor;
    }

    public override string ObtenerDescripcion()
    {
        return $"Libro {Titulo} - Autor: {Autor} - Año de Publicación: {AnioPublicacion}\n";
    }
}