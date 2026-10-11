namespace ModelsParking;

public abstract class Vehiculo
{
    public string Matricula{get;set;}
    public string Marca{get;set;}
    public Vehiculo(string _matricula, string _marca)
    {
        this.Matricula = _matricula;
        this.Marca = _marca;
    }

    public abstract void ObtenerDescripcion();
}