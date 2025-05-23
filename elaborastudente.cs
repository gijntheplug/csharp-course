using System;

public class Program
{
    static void Main(string[] args)
    {
        int voto1;
        int voto2;
        string nome = "Andrea";

        int mediaVoti;

        ElaboraStudente(ref voto1, ref voto2, ref nome, out mediaVoti);
    }

    static void ElaboraStudente(ref int voto1, ref int voto2, ref string nome, out int mediaVoti)
    {
        Console.WriteLine("Elabora studente");
        Console.WriteLine("Inserisci il nome dello studente:");
        nome = Console.ReadLine();
        Console.WriteLine($"Voto 1: {voto1}");
        Console.WriteLine($"Voto 2: {voto2}");

        //la media
        mediaVoti = (voto1 + voto2) / 2;
        Console.WriteLine($"La media dei voti è: {mediaVoti}");
        if (mediaVoti >= 6)
            Console.WriteLine("Sei Promosso");
        else
            Console.WriteLine("Sei Bocciato");
    }
}