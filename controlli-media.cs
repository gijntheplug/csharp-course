using System;

class Program
{
    static void Main(string[] args)
    {
        int numUno;
        int numDue;
        int numTre;

        Console.WriteLine("Inserisci il primo numero:");
        numUno = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il secondo numero:");
        numDue = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il terzo numero:");
        numTre = int.Parse(Console.ReadLine());
        if((numUno + numDue + numTre / 3) >= 60){
            Console.WriteLine("Hai superato la prova!");
        }
        else{
            Console.WriteLine("Prova fallita.");
        }

        Console.WriteLine($"La media dei tre numeri è: {(numUno + numDue + numTre) / 3}");
    }
}