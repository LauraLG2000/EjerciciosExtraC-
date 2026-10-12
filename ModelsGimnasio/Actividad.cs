using System.Text.Json.Serialization;
using Models;

namespace ModelsGimnasio;

[JsonPolymorphic (TypeDiscriminatorPropertyName = "$tipo")]
[JsonDerivedType (typeof(Yoga), "yoga")]
[JsonDerivedType (typeof(CrossTraining), "crosstraining")]
[JsonDerivedType (typeof(Spinning), "spinning")]

public abstract class Actividad
{
    public string Nombre{get;set;}
    public int Duracion{get;set;}
    public int MaximoParticipantes{get;set;}

    public ActividadTipoEnum Tipo{get; set;}

    public Actividad()
    {
        
    }

    public Actividad(string _nombre, int _duracion, int _maximoParticipantes)
    {
        this.Nombre = _nombre;
        this.Duracion = _duracion;
        this.MaximoParticipantes = _maximoParticipantes;
    }

    public abstract string InformacionActividad();
}