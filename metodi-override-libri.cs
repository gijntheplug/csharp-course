using System;

public class Libro
{
    public string? Titolo;
    public string? Autore;
    public int AnnoPubblicazione;

    //HashCode coerente con i dati significativi
    public override int GetHashCode()
    {
        return HashCode.Combine(Titolo, Autore, AnnoPubblicazione);
    }
    public override string ToString()
    {
        return $"'{Titolo}' di {Autore}, {AnnoPubblicazione}.";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Libro other)//se l'oggetto è un punto
        {
            return this.Titolo == other.Titolo && this.Autore == other.Autore && this.AnnoPubblicazione == other.AnnoPubblicazione;
        }
        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Libro l1 = new Libro { Titolo = "Il Signore degli Anelli", Autore = "J.R.R. Tolkien", AnnoPubblicazione = 1954 };
        Libro l2 = new Libro { Titolo = "Il Signore degli Anelli", Autore = "J.R.R. Tolkien", AnnoPubblicazione = 1954 };

        Console.WriteLine(l1.ToString);
        Console.WriteLine(l2.ToString);

        Console.WriteLine(l1.GetHashCode());
        Console.WriteLine(l2.GetHashCode());
        Console.WriteLine(l1.Equals(l2));

    }
}