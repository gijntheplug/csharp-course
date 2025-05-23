using System;

public class Program
{
    static void Main(string[] args)
    {
        Analizza("messaggio", true);
    }

    static void Analizza(string messaggio, bool contaVocali)
    {
        Console.WriteLine("Inserisci una frase:");
        messaggio = Console.ReadLine();
        int contatoreVocali = 0;
        int contatoreConsonanti = 0;
        contaVocali = false;
        string vocali = "aeiouàèéìíîòóùúAEIOUÀÈÉÌÍÎÒÓÙÚ";
        string consonanti = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ" +
                            "ḃċḋḟġṁṅṗṡṫẁẃẅỳŷźżž" + // alcune consonanti accentate minuscole
                            "ḂĊḊḞĠṀṄṖṠṪẀẂẄỲŶŹŻŽ"; // corrispettive maiuscole accentate
        if (messaggio is not null)
        {
            foreach (char carattere in messaggio)
            {
                if (!char.IsWhiteSpace(carattere))
                {
                    if (contaVocali)
                    {
                        if (vocali.Contains(char.ToLower(carattere)))
                            contatoreVocali++;
                    }
                    else
                    {
                        if (consonanti.Contains(char.ToLower(carattere)))
                            contatoreConsonanti++;
                    }
                }
            }
        }
        Console.WriteLine($"La frase contiene {contatoreVocali} vocali {contatoreConsonanti} consonanti");
    }
}