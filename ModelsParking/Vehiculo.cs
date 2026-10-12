using System.Text.Json.Serialization;

namespace ModelsParking;

[JsonPolymorphic (TypeDiscriminatorPropertyName = "$tipo")]
[JsonDerivedType (typeof(Coche), "coche")]
[JsonDerivedType (typeof(Moto), "moto")]
[JsonDerivedType (typeof(Furgoneta), "furgoneta")]
public abstract class Vehiculo
{
    public string Matricula{get;set;}
    public string Marca{get;set;}

    public Vehiculo()
    {
        
    }
    public Vehiculo(string _matricula, string _marca)
    {
        this.Matricula = _matricula;
        this.Marca = _marca;
    }

    public abstract string ObtenerDescripcion();
}