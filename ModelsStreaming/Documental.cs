namespace ModelsStreaming;

public class Documental : Contenido
{
    public string Tematica{get;set;}
    public Documental(string _titulo, int _duracion, string _Tematica) : base(_titulo, _duracion)
    {
        this.Tematica = _Tematica;
    }

    public override string ObtenerDescripcion()
    {
        return $"Documental {Titulo} - Duración: {Duracion} min - Tematica: {Tematica}\n";
    }
}