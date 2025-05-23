using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

public class Soldato // superclasse "soldato"
{
    // campi privati
    private string? nome;
    private string? grado;
    private int anniServizio;

    // proprietà pubbliche
    public string Nome { get; set; }
    public string Grado { get; set; }
    public int AnniServizio
    {
        get { return anniServizio; }
        set
        {
            if (anniServizio >= 0)//TODO chiedere perché ha usato "value"
            {
                Console.WriteLine("Inserisci il numero di anni di servizio del soldato: ");
                anniServizio = int.Parse(Console.ReadLine());
            }
        }
    }

    public virtual string Descrizione()
    {
        return $"Nome: {Nome}, Grado: {Grado}, Anni di servizio: {AnniServizio}";
    }
}

public class Fante : Soldato // sottoclasse "fante"
{
    // campi privati
    private string? arma;

    // proprietà pubblica
    public string Arma { get; set; }
    public override string Descrizione()
    {
        return $"Nome: {Nome}, Grado: {Grado}, Anni di servizio: {AnniServizio}, Arma: {Arma}";
    }
}

public class Artigliere : Soldato // sottoclasse "fante"
{
    // campi privati
    private int calibro;

    // proprietà pubblica
    public int Calibro
    {
        get { return calibro; }
        set
        {
            if (calibro > 0)
            {
                Console.WriteLine("Inserisci il calibro gestito dall'artigliere: ");
                calibro = int.Parse(Console.ReadLine());
            }
        }
    }
    public override string Descrizione()
    {
        return $"Nome: {Nome}, Grado: {Grado}, Anni di servizio: {AnniServizio}, Calibro: {calibro}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Soldato> reparto = new List<Soldato>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n-- Menù di gestione dei soldati --");
            Console.WriteLine("1. Aggiungi un Fante");
            Console.WriteLine("2. Aggiungi un Artigliere");
            Console.WriteLine("3. Visualizza tutti i Soldati");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Fante f = new Fante();
                    Console.Write("Nome: "); f.Nome = Console.ReadLine();
                    Console.Write("Grado: "); f.Grado = Console.ReadLine();
                    Console.Write("Anni di servizio: "); f.AnniServizio = int.Parse(Console.ReadLine());
                    Console.Write("Arma: "); f.Arma = Console.ReadLine();
                    reparto.Add(f);
                    break;

                case "2":
                    Artigliere a = new Artigliere();
                    Console.Write("Nome: "); a.Nome = Console.ReadLine();
                    Console.Write("Grado: "); a.Grado = Console.ReadLine();
                    Console.Write("Anni di servizio: "); a.AnniServizio = int.Parse(Console.ReadLine());
                    Console.Write("Calibro: "); a.Calibro = int.Parse(Console.ReadLine());
                    reparto.Add(a);
                    break;

                case "3":
                    Console.WriteLine("\n-- Lista di Soldati --");
                    foreach (Soldato s in reparto)
                    {
                        s.Descrizione();
                    }
                    break;

                case "0":
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("Programma terminato.");
    }
}