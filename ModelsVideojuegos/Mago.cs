namespace ModelsVideojuegos;

public class Mago : Personaje
{
    public int Mana{get;set;}
    public Mago(string _nombre, int _vida, int _mana) : base(_nombre, _vida)
    {
        this.Mana = _mana;
    }

    public override string ObtenerDescripcion()
    {
        return $"Mago {Nombre} - Vida: {Vida} - Mana: {Mana}";
    }
}