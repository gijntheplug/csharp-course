using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Studente
{
    public string? Nome;
    public int Matricola;
    public double MediaVoti;
    public Studente(string nome, int matricola, double media)
    {
        Nome = nome;
        Matricola = matricola;
        MediaVoti = media;
    }

    public void Stampa()
    {
        Console.WriteLine($"\nNome: {Nome}");
        Console.WriteLine($"\nMatricola: {Matricola}");
        Console.WriteLine($"\nMedia Voti: {MediaVoti}");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci il nome dello studente numero 1:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci la matricola dello studente:");
        int matricola = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci la media voti dello studente:");
        double media = double.Parse(Console.ReadLine());

        Studente s1 = new Studente(nome, matricola, media);
        s1.Stampa();

        Console.WriteLine("Inserisci il nome dello studente numero 2:");
        string nome2 = Console.ReadLine();
        Console.WriteLine("Inserisci la matricola dello studente numero 2:");
        int matricola2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci la media voti dello studente numero 2:");
        double media2 = double.Parse(Console.ReadLine());

        Studente s2 = new Studente(nome2, matricola2, media2);
        s2.Stampa();
    }
}
