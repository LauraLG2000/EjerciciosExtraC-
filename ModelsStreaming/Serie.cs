namespace ModelsStreaming;

public class Serie : Contenido
{
    public int NumeroTemporadas{get;set;}
    public Serie(string _titulo, int _duracion, int _NumeroTemporadas) : base(_titulo, _duracion)
    {
        this.NumeroTemporadas = _NumeroTemporadas;
    }

    public override string ObtenerDescripcion()
    {
        return $"Serie {Titulo} - Duración: {Duracion} min/capítulo - NumeroTemporadas: {NumeroTemporadas}\n";
    }
}