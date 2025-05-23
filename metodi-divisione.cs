using System;

class Program
{
    static void Main(string[] args)
    {
        int quoziente;
        int resto;
        Console.WriteLine("Inserisci il dividendo:");
        int dividendo = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il divisore:");
        int divisore = int.Parse(Console.ReadLine());

        Dividi(dividendo, divisore, out quoziente, out resto);

        Console.WriteLine($"Quoziente: {quoziente}, Resto: {resto}");
    }

    static void Dividi(int dividendo, int divisore, out int quoziente, out int resto)
    {
        quoziente = dividendo / divisore;
        resto = dividendo % divisore;
    }
}