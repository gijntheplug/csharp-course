using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Inserisci il primo numero: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero: ");
        int b = int.Parse(Console.ReadLine());

        int risultato = Dividi(a, b);
        Console.WriteLine($"Risultato: {risultato}");
    }

    static int Dividi(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Impossibile dividere per zero.");
        }
        return a / b;
    }
}