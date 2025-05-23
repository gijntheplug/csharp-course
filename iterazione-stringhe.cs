using System;
class Program
{
    static void Main(string[] args)
    {
        // Esercizio 1 - Conta cifre
        Console.WriteLine("Inserisci una frase con simboli e cifre");
        string frase = Console.ReadLine();
        int numero = 0;
        foreach (char c in frase)
        {
            if (char.IsDigit(c))
            {
                numero++;
            }
        }
        Console.WriteLine($"Numero di cifre nella frase: {numero}");

        // Esercizio 2 - Rimuovi spazi
        Console.Write("Inserisci qui una frase: ");
        string fraseInput = Console.ReadLine();
        string frasePost = "";
        foreach (char c in fraseInput)
        {
            if (c != ' ')
            {
                frasePost += c;
            }
        }
        Console.WriteLine($"Frase Finale= {frasePost}");

        // Esercizio 3 - Conta vocali
        Console.Write("Inserisci una frase: ");
        string fraseVocali = Console.ReadLine();
        string vocali = "aàáâäãåeèéêëiìíîïoòóôöõuùúûüAÀÁÂÄÃÅEÈÉÊËIÌÍÎÏOÒÓÔÖÕUÙÚÛÜ";
        int contatore = 0;
        foreach (char c in fraseVocali)
        {
            if (vocali.Contains(c))
            {
                contatore++;
            }
        }
        Console.WriteLine($"Il numero di vocali nella frase è: {contatore}");
    }
}