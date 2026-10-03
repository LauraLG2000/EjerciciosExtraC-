namespace ModelsArticulo;

public class Articulo
{
    public string Nombre{get;set;}
    public decimal Precio{get;set;}
    public Articulo(string _nombre, decimal _precio)
    {
        this.Nombre = _nombre;
        this.Precio = _precio;
    }

    public void DescripcionArticulo()
    {
        Console.WriteLine($"{this.Nombre} - Precio: {this.Precio}€");
    }
}