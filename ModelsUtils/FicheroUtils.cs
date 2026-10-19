using System.Text.Json;

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

    public static List<T> CargarDatosFicheroJson<T>(string rutaFichero)
    {
        List<T> contenidoJson = new List<T>();

        try
        {
            if (!File.Exists(rutaFichero))
            {
                throw new FileNotFoundException("No se ha encontrado la ruta del fichero");
            }

            string json = LecturaFichero(rutaFichero);
            contenidoJson = JsonSerializer.Deserialize<List<T>>(json);

            return contenidoJson;
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.ToString());
            return contenidoJson;
        }
    }
}