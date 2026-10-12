using System.Text.Json.Serialization;

namespace ModelsStreaming;

[JsonPolymorphic (TypeDiscriminatorPropertyName = "$tipo")]
[JsonDerivedType (typeof(Documental), "documental")]
[JsonDerivedType (typeof(Serie), "serie")]
[JsonDerivedType (typeof(Pelicula), "pelicula")]
public abstract class Contenido
{
    public string Titulo{get; set;}
    public int Duracion{get;set;}

    public Contenido()
    {
        
    }
    public Contenido(string _Titulo, int _Duracion)
    {
        this.Titulo = _Titulo;
        this.Duracion = _Duracion;
    }
    public abstract string ObtenerDescripcion();
}