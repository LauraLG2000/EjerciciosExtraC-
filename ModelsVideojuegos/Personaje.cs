namespace ModelsVideojuegos;

public abstract class Personaje
{
    public string Nombre{get; set;}
    public int Vida{get;set;}
    public Personaje(string _nombre, int _vida)
    {
        this.Nombre = _nombre;
        this.Vida = _vida;
    }
    public abstract string ObtenerDescripcion();
}