using System;

class Program
{
    static void Main(string[] args)
    {
        int giorno;
        Console.WriteLine("Inserisci il giorno:");
        giorno = int.Parse(Console.ReadLine());
        int mese;
        Console.WriteLine("Inserisci il mese:");
        mese = int.Parse(Console.ReadLine());
        int anno;
        Console.WriteLine("Inserisci l'anno:");
        anno = int.Parse(Console.ReadLine());

        AggiustaData(ref giorno, ref mese, ref anno);
        Console.WriteLine($"Nuova Data: {giorno}/{mese}/{anno}");
    }

    static void AggiustaData(ref int giorno, ref int mese, ref int anno)
    {
        if (giorno > 30)
        {
            mese++;
            giorno = 1;
        }
        if (mese >= 12)
        {
            anno++;
            mese = 1;
        }
    }
}