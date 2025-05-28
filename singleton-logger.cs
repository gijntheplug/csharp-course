using System;
using System.Collections.Generic;

// Singleton: Logger di sistema
public sealed class Logger
{
    // Campo privato statico che contiene l'unica istanza della classe Logger
    private static Logger _instance;

    //! Costruttore privato per impedire l'istanziazione dall'esterno
    private Logger() { }

    // Metodo pubblico statico per ottenere l'istanza del Logger (Singleton)
    public static Logger GetIstanza()
    {
        // Se l'istanza non esiste, viene creata
        if (_instance == null)
        {
            _instance = new Logger();
        }
        // Restituisce l'unica istanza
        return _instance;
    }

    // Metodo per scrivere un messaggio sulla console con timestamp
    public void ScriviMessaggio(string messaggio)
    {
        Console.WriteLine($"[{DateTime.Now}] {messaggio}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Ottiene la prima istanza del Logger
        Logger primo = Logger.GetIstanza();
        // Ottiene la seconda istanza del Logger (sarà la stessa della prima)
        Logger secondo = Logger.GetIstanza();

        // Scrive un messaggio tramite la prima istanza
        primo.ScriviMessaggio("Sistema avviato.");
        // Scrive un altro messaggio tramite la seconda istanza
        secondo.ScriviMessaggio("Connessione al database riuscita.");

        // Verifica se le due variabili fanno riferimento alla stessa istanza
        Console.WriteLine("Le due istanze sono uguali? " + (primo == secondo));
        Console.WriteLine("Programma terminato.");
    }
}