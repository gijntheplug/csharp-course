using System;

public class Program
{
    static void Main(string[] args)
    {
        Esercizio1();
    }

    static void Esercizio1()
    {
        try
        {
            Console.Write("Inserisci il primo numero: ");
            int numero1 = int.Parse(Console.ReadLine());

            Console.Write("Inserisci il secondo numero: ");
            int numero2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hai inserito: {numero1} e {numero2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: Devi inserire dei numeri interi validi.");
        }
        finally
        {
            Console.WriteLine("Non preoccuparti, vengo eseguito comunque.");
        }
    }
}