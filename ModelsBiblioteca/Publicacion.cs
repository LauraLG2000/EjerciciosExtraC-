namespace ModelsBiblioteca;

public abstract class Publicacion
{
    public string Titulo{get;set;}
    public int AnioPublicacion{get;set;}
    public Publicacion(string _titulo, int _anioPublicacion)
    {
        this.Titulo = _titulo;
        this.AnioPublicacion = _anioPublicacion;
    }

    public abstract string ObtenerDescripcion();
}