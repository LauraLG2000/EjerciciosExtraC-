using Models;

namespace ModelsGimnasio;

public class Yoga : Actividad
{
    public string EstiloYoga{get;set;}
    public bool UsaAccesorios {get;set;}
    public Yoga(string _nombre, int _duracion, int _maximoParticipantes, string _estiloYoga, bool _usaAccesorios) : base(_nombre, _duracion, _maximoParticipantes)
    {
        this.EstiloYoga = _estiloYoga;
        this.UsaAccesorios = _usaAccesorios;
        this.Tipo = ActividadTipoEnum.yoga;
    }

    public override string InformacionActividad()
    {
        string accesorios;
        if (UsaAccesorios)
        {
            accesorios = "si";
        }
        else
        {
            accesorios = "no";
        }
        return $"{Nombre}: Tipo de actividad - {Tipo}; Duracion - {Duracion} mins; Máximo número de participantes: {MaximoParticipantes}; Estilo de Yoga: {EstiloYoga}; ¿Requiere accesorios?: {accesorios}";
    }
}