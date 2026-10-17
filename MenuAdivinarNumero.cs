public class MenuAdivinarNumero
{
    public void AdivinarNumero()
    {
        int numeroAleatorio = new Random().Next(1, 101);
        int numero;
        int contador = 0;

        Console.WriteLine("\n====== ADIVINA EL NÚMERO ======");

        do
        {
            Console.WriteLine("Introduce un número (1-100):");
            if (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Error: Introduce un número válido (1-100)");
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