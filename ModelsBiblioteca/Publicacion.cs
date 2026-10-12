using System.Text.Json.Serialization;

namespace ModelsBiblioteca;

[JsonPolymorphic (TypeDiscriminatorPropertyName = "$tipo")]
[JsonDerivedType (typeof(Libro), "libro")]
[JsonDerivedType (typeof(Comic), "comic")]
[JsonDerivedType (typeof(Revista), "revista")]
public abstract class Publicacion
{
    public string Titulo{get;set;}
    public int AnioPublicacion{get;set;}
    public Publicacion(string _titulo, int _anioPublicacion)
    {
        this.Titulo = _titulo;
        this.AnioPublicacion = _anioPublicacion;
    }

    public Publicacion()
    {
        
    }

    public abstract string ObtenerDescripcion();
}