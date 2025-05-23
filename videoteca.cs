using System;
using System.Collections.Generic;

public class Film
{
    public string Titolo;
    public string Regista;
    public int Anno;
    public string Genere;

    //costruttore per inizializzare un film
    public Film(string titolo, string regista, int anno, string genere)
    {
        Titolo = titolo;
        Regista = regista;
        Anno = anno;
        Genere = genere;
    }

    //metodo per stampare le informazioni del film
    public void StampaInfo()
    {
        Console.WriteLine($"{Titolo} ({Anno}) - Regia: {Regista}, Genere: {Genere}");
    }
}

public class Program
{
    public static void Main()
    {
        List<Film> videoteca = new List<Film>();

        //inserimento film
        Console.WriteLine("Quanti film vuoi inserire?");
        int c = int.Parse(Console.ReadLine());
        for (int i = 1; i < c; i++)
        {
            Console.WriteLine($"\nInserisci i dati del film #{i}");

            Console.Write("Titolo: ");
            string titolo = Console.ReadLine();

            Console.Write("Regista: ");
            string regista = Console.ReadLine();

            Console.Write("Anno: ");
            int anno = int.Parse(Console.ReadLine());

            Console.Write("Genere: ");
            string genere = Console.ReadLine();

            Film film = new Film(titolo, regista, anno, genere);
            videoteca.Add(film); //aggiunge il film alla lista
        }

        //stampa dei film inseriti
        Console.WriteLine("\nFilm inseriti:");
        foreach (Film f in videoteca)
        {
            f.StampaInfo();
        }

        //ricerca film
        Console.Write("\nInserisci un genere per cercare film: ");
        string ricercaGenere = Console.ReadLine();

        Console.WriteLine($"Film trovati nel genere '{ricercaGenere}'");
        foreach (Film f in videoteca)
        {
            if (f.Genere.ToLower() == ricercaGenere.ToLower())
            {
                f.StampaInfo();
            }
        }
    }
}