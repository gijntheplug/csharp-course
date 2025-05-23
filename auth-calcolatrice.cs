using System;

public class Utente
{
    public string? Password;
    public int Eta;
    public string? Nickname;
}

public class Calcolatrice
{
    public double NumeroUno;
    public double NumeroDue;

    public static double Somma(double a, double b)
    {
        return a + b;//effettua somma
    }
    public static double Moltiplicazione(double a, double b)
    {
        return a * b;//effettua moltiplicazione
    }
    public static double Divisione(double a, double b)
    {
        try
        {
            if (b != 0)//se il secondo numero non corrisponde a zero
            {
                return a / b;//effettua divisione
            }
            Console.WriteLine("Impossibile dividere per zero.");
            return 0;//valore di default in caso ci sia la divisione per 0
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore durante la divisione: {ex.Message}");
            return 0;
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto nella calcolatrice");
        Console.WriteLine("Registrati.");
        Console.Write("Nome Utente: ");
        string NomeUtente = Console.ReadLine();
        Console.WriteLine("Password:");
        string Password = Console.ReadLine();
        Console.WriteLine("Età: ");
        int Eta = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine("Bentornato nella calcolatrice");
            Console.WriteLine("Effettua il login:");
        }

    }
}