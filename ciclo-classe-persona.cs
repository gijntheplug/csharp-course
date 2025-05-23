using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Persona
{
    public string? Nome;
    public string? Cognome;
    public int AnnoNascita;
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Quante persone vuoi inserire?");
        int numeroPersone = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numeroPersone; i++)//inizio ciclo
        {
            Persona p = new Persona();//crea oggetto Persona
            Console.WriteLine($"Inserisci il nome della persona numero {i}:");
            p.Nome = Console.ReadLine();
            Console.WriteLine($"Inserisci il cognome della persona numero {i}:");
            p.Cognome = Console.ReadLine();
            Console.WriteLine($"Inserisci l'anno di nascita della persona numero {i}:");
            p.AnnoNascita = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine($"{p.Nome} {p.Cognome} è nato nel {p.AnnoNascita}");      //output dati
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
