namespace ModelsParking;

public class Furgoneta : Vehiculo
{
    public decimal volumenCarga{get;set;}
    public int gradosAperturaPuertaTrasera{get;set;}
    public Furgoneta(string _matricula, string _marca, decimal _volumenCarga, int _gradosAperturaPuertaTrasera) : base(_matricula, _marca)
    {
        this.volumenCarga = _volumenCarga;
        this.gradosAperturaPuertaTrasera = _gradosAperturaPuertaTrasera;
    }

    public override string ObtenerDescripcion()
    {
        return $"Furgoneta {Marca} - Matrícula: {Matricula} - Volumen de carga: {volumenCarga} m³ - Grados de apertura de la puerta trasera: {gradosAperturaPuertaTrasera}º\n";
    }
}