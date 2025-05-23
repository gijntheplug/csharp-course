using System;

class Program
{
    static void Main(string[] args)
    {
        //! Input da tastiera
        Console.Write("Inserisci il tuo nome: ");
        string? nome = Console.ReadLine();
        Console.WriteLine($"Ciao, {nome}!");

        Console.Write("Inserisci un numero: ");
        string? n1 = Console.ReadLine();
        Console.WriteLine($"Hai inserito il numero: {n1}");

        Console.Write("Inserisci un altro numero: ");
        string? n2 = Console.ReadLine();
        Console.WriteLine($"Hai inserito il numero: {n2}");

        int numero1 = int.Parse(n1);
        int numero2 = int.Parse(n2);
        Console.WriteLine($"La somma dei numeri {numero1} e {numero2} è: {numero1 + numero2}");
    }
}