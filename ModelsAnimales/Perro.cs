namespace ModelsAnimales;
public class Perro : Animal{
    public Perro (string _nombre) : base(_nombre) {

    }

    public override string HacerSonido(){
          return "Guau";
    }
}