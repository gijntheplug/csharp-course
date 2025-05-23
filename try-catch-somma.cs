using System;

public class Program
{
    static void Main(string[] args)
    {
        Esercizio3();
    }

    static void Esercizio3()
    {
        int somma = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Inserisci il numero {i + 1}: ");
            string input = Console.ReadLine();

            try
            {
                int numero = int.Parse(input);
                somma += numero;
            }
            catch (FormatException)
            {
                Console.WriteLine("Valore non valido. Inserisci un numero intero.");
                i--; // Retry the same iteration
            }
        }

        Console.WriteLine($"Somma dei numeri validi: {somma}");
    }
}