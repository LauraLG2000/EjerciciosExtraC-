namespace ModelsParking;

public class Moto : Vehiculo
{
    public string TipoManillar {get;set;}
    public bool isScooter {get;set;}

    public Moto()
    {
        
    }
    public Moto(string _matricula, string _marca, string _tipoManillar, bool _isScooter) : base(_matricula, _marca)
    {
        this.TipoManillar = _tipoManillar;
        this.isScooter = _isScooter;
    }

    public override string ObtenerDescripcion()
    {
        return $"Moto {Marca} - Matrícula: {Matricula} - Tipo de manillar: {TipoManillar} - Es scooter: {isScooter}\n";
    }
}