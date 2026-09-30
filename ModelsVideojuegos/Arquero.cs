namespace ModelsVideojuegos;

public class Arquero : Personaje
{
    public int NumeroFlechas{get;set;}
    public Arquero(string _nombre, int _vida, int _NumeroFlechas) : base(_nombre, _vida)
    {
        this.NumeroFlechas = _NumeroFlechas;
    }

    public override string ObtenerDescripcion()
    {
        return $"Arquero {Nombre} - Vida: {Vida} - NumeroFlechas: {NumeroFlechas}";
    }
}