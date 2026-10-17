namespace ModelsUtils;

public class InputUtils
{
    public static string InputString(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine();

        if (entrada is null || entrada == "")
        {
            throw new NullReferenceException($"Error: {mensaje} no puede estar vacío");
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

    public static bool InputBoolOpcionSiNo(string mensaje)
    {
        bool entrada = false;

        Console.Write("¿Es una scooter? (si/no)");
        string respuesta = Console.ReadLine().ToLower().Trim();

        if (respuesta.Equals("si") || respuesta.Equals("sí"))
        {
            entrada = true;
        }

        return entrada;
    }

    public static decimal InputDecimalMayorQueCero(string mensaje)
    {
        decimal entrada;

        Console.Write(mensaje);

        if (!decimal.TryParse(Console.ReadLine(), out entrada) || entrada <= 0)
        {
            throw new ArgumentOutOfRangeException("Error: La cantidad a ingresar no puede ser 0 o negativa");
        }

        return entrada;
    }
}