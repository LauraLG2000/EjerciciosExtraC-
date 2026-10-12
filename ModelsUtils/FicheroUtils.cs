namespace ModelsUtils;
class FicheroUtils
{
    public static void EscrituraFichero(string _rutaFichero, string _contenido)
    {
        File.AppendAllText(_rutaFichero, _contenido);
    }

    public static void EscrituraFicheroJSON(string _rutaFichero, string _contenido)
    {
        File.WriteAllText(_rutaFichero, _contenido);
    }

    public static void EliminarFichero(string _rutaFichero)
    {
        File.Delete(_rutaFichero);
    }

    public static string[] LecturaLineasFichero(string _rutaFichero)
    {
        return File.ReadAllLines(_rutaFichero);
    }

    public static string LecturaFichero(string _rutaFichero)
    {
        return File.ReadAllText(_rutaFichero);
    }
}