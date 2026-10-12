namespace ModelsParking;

public class Coche : Vehiculo
{
    public decimal volumenMaletero {get;set;}
    public int CapacidadPasajeros {get;set;}

    public Coche()
    {
        
    }
    
    public Coche(string _matricula, string _marca, decimal _volumenMaletero, int _capacidadPasajeros) : base(_matricula, _marca)
    {
        this.volumenMaletero = _volumenMaletero;
        this.CapacidadPasajeros = _capacidadPasajeros;
    }

    public override string ObtenerDescripcion()
    {
        return $"Coche {Marca} - Matrícula: {Matricula} - Volumen del maletero: {volumenMaletero} litros - Número de pasajeros: {CapacidadPasajeros}\n";
    }
}