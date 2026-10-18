public class MenuAdivinarNumero
{
    private const int NumeroMinimo = 1;
    private const int NumeroMaximo = 100;
    public void AdivinarNumero()
    {
        int numeroAleatorio = new Random().Next(NumeroMinimo, NumeroMaximo+1);
        int numero;
        int contador = 0;

        Console.WriteLine("\n====== ADIVINA EL NÚMERO ======");

        do
        {
            Console.WriteLine($"Introduce un número ({NumeroMinimo}-{NumeroMaximo}):");
            if (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine($"Error: Introduce un número válido ({NumeroMinimo}-{NumeroMaximo})");
                continue;
            }

            if (numero < numeroAleatorio)
            {
                Console.WriteLine("El número a adivinar es más grande.");
            }

            if (numero > numeroAleatorio)
            {
                Console.WriteLine("El número a adivinar es más pequeño.");
            }

            contador++;
        } while (numero != numeroAleatorio);

        Console.WriteLine($"Correcto. El número era {numeroAleatorio}. Has necesitado {contador} intentos.");
    }
}