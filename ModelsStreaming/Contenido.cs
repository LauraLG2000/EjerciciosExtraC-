namespace ModelsStreaming;

public abstract class Contenido
{
    public string Titulo{get; set;}
    public int Duracion{get;set;}
    public Contenido(string _Titulo, int _Duracion)
    {
        this.Titulo = _Titulo;
        this.Duracion = _Duracion;
    }
    public abstract string ObtenerDescripcion();
}