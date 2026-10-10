using Models;

namespace ModelsGimnasio;

public class Spinning : Actividad
{
    public decimal Kilometros{get;set;}
    public int ResistenciaBase{get;set;}
    public ActividadTipoEnum tipo = ActividadTipoEnum.spinning;
    public Spinning(string _nombre, int _duracion, int _maximoParticipantes, decimal _kilometros, int _resitenciaBase) : base(_nombre, _duracion, _maximoParticipantes)
    {
        this.Kilometros = _kilometros;
        this.ResistenciaBase = _resitenciaBase;
    }

    public override string InformacionActividad()
    {
        return $"{Nombre}: Tipo de actividad - {tipo}; Duracion - {Duracion} mins; Máximo número de participantes: {MaximoParticipantes}; Kilometros: {Kilometros}; Resistencia base: {ResistenciaBase}";
    }
}