using System;

public class Prodotto
{
    public string? Nome;
    public double Prezzo;

    //HashCode coerente con i dati significativi
    public override int GetHashCode()
    {
        return HashCode.Combine(Nome, Prezzo);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Prodotto p1 = new Prodotto { Nome = "Penna", Prezzo = 1.50 };
        Prodotto p2 = new Prodotto { Nome = "Penna", Prezzo = 1.50 };

        Console.WriteLine(p1.GetHashCode());
        Console.WriteLine(p2.GetHashCode());
        //uguale se i valori sono gli stessi
    }
}