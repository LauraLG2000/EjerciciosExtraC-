using System.Text.Json.Serialization;

namespace ModelsVideojuegos;

[JsonPolymorphic (TypeDiscriminatorPropertyName = "$tipo")]
[JsonDerivedType (typeof(Guerrero), "guerrero")]
[JsonDerivedType (typeof(Arquero), "arquero")]
[JsonDerivedType (typeof(Mago), "mago")]
public abstract class Personaje
{
    public string Nombre{get; set;}
    public int Vida{get;set;}
    public Personaje()
    {
        
    }
    public Personaje(string _nombre, int _vida)
    {
        this.Nombre = _nombre;
        this.Vida = _vida;
    }
    public abstract string ObtenerDescripcion();
}