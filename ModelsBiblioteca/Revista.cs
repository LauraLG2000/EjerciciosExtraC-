namespace ModelsBiblioteca;

public class Revista : Publicacion
{
    public int NumeroRevista{get;set;}
    public Revista(string _titulo, int _anioPublicacion, int _numeroRevista) : base(_titulo, _anioPublicacion)
    {
        this.NumeroRevista = _numeroRevista;
    }

    public override string ObtenerDescripcion()
    {
        return $"Revista {Titulo} - Número: {NumeroRevista} - Año de Publicación: {AnioPublicacion}\n";
    }
}