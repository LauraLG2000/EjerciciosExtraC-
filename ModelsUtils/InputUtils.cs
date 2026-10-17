namespace ModelsUtils;

public class InputUtils
{
    public static string InputString(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine();

        if (entrada is null || entrada == "")
        {
            throw new NullReferenceException("Error: El campo no puede estar vacío");
        }

        return entrada;
    }

    public static int InputIntMayorQueUno(string mensaje)
    {
        int entrada;
        Console.Write(mensaje);

        if (!int.TryParse(Console.ReadLine(), out entrada) || entrada < 1)
        {
            throw new ArgumentOutOfRangeException("Error: Tipo de dato no válido.");
        }

        return entrada;
    }
}