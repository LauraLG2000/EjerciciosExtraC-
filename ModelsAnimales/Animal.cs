
namespace ModelsAnimales;
public abstract class Animal{
    public string Nombre{get; set;}

    public Animal (string _nombre){
            this.Nombre = _nombre;
    }

     public abstract string HacerSonido();

}