namespace ModelsAnimales;
public class Pajaro : Animal{
    public Pajaro (string _nombre) : base(_nombre) {

    }

    public override string HacerSonido(){
            return "Pio Pio";
    }
}
