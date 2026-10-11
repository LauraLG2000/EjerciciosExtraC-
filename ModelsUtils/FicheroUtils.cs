namespace ModelsUtils;
class FicheroUtils
{
    public static void EscrituraFichero(string _rutaFichero, string _contenido)
    {
        File.AppendAllText(_rutaFichero, _contenido);
    }

    public static void EliminarFichero(string _rutaFichero)
    {
        File.Delete(_rutaFichero);
    }
}