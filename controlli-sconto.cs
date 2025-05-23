using System;

class Program
{
    static void Main(string[] args)
    {
        float prezzo;
        float prezzoFinale;

        Console.WriteLine("Inserisci il prezzo del prodotto:");
        prezzo = float.Parse(Console.ReadLine());
        if(prezzo >= 100){
            prezzoFinale = prezzo - (prezzo * 10 / 100);
            Console.WriteLine($"Il prezzo finale è: {prezzoFinale}");
        }
        else{
            Console.WriteLine("Il prezzo è minore di 100€, lo sconto non è applicabile.");
        }
    }
}