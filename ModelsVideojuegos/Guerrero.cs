namespace ModelsVideojuegos;

public class Guerrero : Personaje
{
    public int Fuerza{get;set;}

    public Guerrero()
    {
        
    }
    public Guerrero(string _nombre, int _vida, int _fuerza) : base(_nombre, _vida)
    {
        this.Fuerza = _fuerza;
    }

    public override string ObtenerDescripcion()
    {
        return $"Guerrero {Nombre} - Vida: {Vida} - Fuerza: {Fuerza}\n";
    }
}