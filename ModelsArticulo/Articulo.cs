using System.Text.Json.Serialization;

namespace ModelsArticulo;

[JsonPolymorphic (TypeDiscriminatorPropertyName = "$tipo")]
[JsonDerivedType (typeof(Articulo), "articulo")]
public class Articulo
{
    public string Nombre{get;set;}
    public decimal Precio{get;set;}
    public Articulo(string _nombre, decimal _precio)
    {
        this.Nombre = _nombre;
        this.Precio = _precio;
    }

    public Articulo()
    {
        
    }

    public string DescripcionArticulo()
    {
        return $"{this.Nombre} - Precio: {this.Precio}€ \n";
    }
}