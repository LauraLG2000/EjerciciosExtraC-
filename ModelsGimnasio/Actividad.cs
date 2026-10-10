namespace ModelsGimnasio;

public abstract class Actividad
{
    public string Nombre{get;set;}
    public int Duracion{get;set;}
    public int MaximoParticipantes{get;set;}

    public Actividad(string _nombre, int _duracion, int _maximoParticipantes)
    {
        this.Nombre = _nombre;
        this.Duracion = _duracion;
        this.MaximoParticipantes = _maximoParticipantes;
    }

    public abstract string InformacionActividad();
}