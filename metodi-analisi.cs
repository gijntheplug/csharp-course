using System;

class Program
{
    static void Main(string[] args)
    {
        int vocale = 0;
        int consonante = 0;
        int spazio = 0;

        Console.WriteLine("Inserisci una frase: ");
        string parola = Console.ReadLine();
        AnalizzaParola(parola, out vocale, out consonante, out spazio);

        Console.WriteLine($"Il numero delle vocali è : {vocale}\nIl numero delle consonanti è: {consonante}\nIl numero degli spazi è: {spazio}");
    }

    static void AnalizzaParola(string parola, out int vocale, out int consonante, out int spazio)
    {
        vocale = 0;
        consonante = 0;
        spazio = 0;
        string cercaVocali = "aeiouAEIOU";
        string cercaConsonanti = "bcdefghlmnpqrstvzBCDEFGHLMNPQRSTVZ";
        string cercaSpazi = " ";
        foreach (char c in parola)
        {
            if (cercaVocali.Contains(c))
            {
                vocale++;
            }
            if (cercaConsonanti.Contains(c)){
                consonante++;
            }
            if (cercaSpazi.Contains(c)){
                spazio++;
            }
        }
    }
}