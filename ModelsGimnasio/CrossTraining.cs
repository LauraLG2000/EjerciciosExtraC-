namespace ModelsGimnasio;

public class CrossTraining : Actividad
{
    public decimal CargaMaxima{get;set;}
    public int CantidadEstaciones{get;set;}
    public CrossTraining(string _nombre, int _duracion, int _maximoParticipantes, decimal _cargaMaxima, int _cantidadEstaciones) : base(_nombre, _duracion, _maximoParticipantes)
    {
        this.CargaMaxima = _cargaMaxima;
        this.CantidadEstaciones = _cantidadEstaciones;
    }

    public override string InformacionActividad()
    {
        return $"{Nombre}: Duracion - {Duracion} mins; Máximo número de participantes: {MaximoParticipantes}; Carga Máxima: {CargaMaxima}; Número de estaciones: {CantidadEstaciones}";
    }
}