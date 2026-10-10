namespace ModelsAnimales;
public class Gato : Animal{
    public Gato (string _nombre) : base(_nombre) {

    }

    public override string HacerSonido(){
           return "Miau";
    }
}