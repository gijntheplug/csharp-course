using System;

public class Program
{
    static void Main(string[] args)
    {
        //punteggi + bonus
        int punteggio1 = 50;
        int punteggio2 = 100;
        int punteggio3 = 200;

        int bonus = 50;

        //variabili risultati
        int totale, media;

        AggiornaPunteggio(ref punteggio1, ref punteggio2, ref punteggio3, bonus, out totale, out media);

        //output titoli
        Console.WriteLine($"Punteggi aggiornati: {punteggio1}, {punteggio2}, {punteggio3}");
        Console.WriteLine($"Totale: {totale}");
        Console.WriteLine($"Media: {media}");
    }

    static void AggiornaPunteggio(ref int punteggio1, ref int punteggio2, ref int punteggio3, int bonus, out int totale, out int media)
    {
        //aggiunge punti bonus al punteggio 
        punteggio1 += bonus;
        punteggio2 += bonus;
        punteggio3 += bonus;

        //calcola totale e media
        totale = punteggio1 + punteggio2 + punteggio3;
        media = totale / 3;
    }
}