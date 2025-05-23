using System;

class Program
{
    static void Main(string[] args)
    {
        //! Operatori aritmetici
        int a = 10;
        int b = 5;
        int somma = a + b;
        int differenza = a - b;
        int prodotto = a * b;
        int divisione = a / b;
        int resto = a % b;
        Console.WriteLine($"Somma: {somma}");
        Console.WriteLine($"Differenza: {differenza}");
        Console.WriteLine($"Prodotto: {prodotto}");
        Console.WriteLine($"Divisione: {divisione}");
        Console.WriteLine($"Resto: {resto}");
        Console.WriteLine($"Incremento: {++a}");
        Console.WriteLine($"Decremento: {--b}");
    }
}