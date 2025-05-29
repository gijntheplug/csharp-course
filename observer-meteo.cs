using System;
using System.Collections.Generic;

//Interfaccia Observer: chi implementa questa interfaccia può ricevere aggiornamenti dal Subject
public interface IObserver
{
    void Aggiorna(string messaggio);
}

//Interfaccia Subject: chi implementa questa interfaccia può registrare, rimuovere e notificare Observer
public interface ISubject
{
    void Registra(IObserver osservatore);
    void Rimuovi(IObserver osservatore);
    void Notifica(string messaggio);
}

//Implementazione concreta del Subject
public class CentroMeteo : ISubject
{
    //Lista degli observer registrati
    private readonly List<IObserver> _osservatori = new List<IObserver>();

    //Registra un nuovo observer se non già presente
    public void Registra(IObserver osservatore)
    {
        if (!_osservatori.Contains(osservatore))
        {
            _osservatori.Add(osservatore);
        }
    }

    //Rimuove un observer dalla lista
    public void Rimuovi(IObserver osservatore)
    {
        _osservatori.Remove(osservatore);
    }

    //Notifica tutti gli observer chiamando il loro metodo Notifica
    public void Notifica(string messaggio)
    {
        foreach (IObserver observer in _osservatori)
        {
            observer.Aggiorna(messaggio);
        }
    }

    //Metodo specifico per aggiornare i dati meteo e notificare tutti gli observer
    public void AggiornaMeteo(string dati)
    {
        foreach (IObserver observer in _osservatori)
        {
            Console.WriteLine("Sto aggiornando il meteo...");
            observer.Aggiorna(dati);
        }
    }
}

//Implementazione concreta di un Observer che visualizza i dati su console
public class DisplayConsole : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"| DisplayConsole | Dati meteo ricevuti: {messaggio}");
    }
}

//Implementazione concreta di un Observer che simula un display mobile
public class DisplayMobile : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"| DisplayMobile | Dati meteo ricevuti: {messaggio}");
    }
}

//Classe principale che gestisce l'esecuzione del programma
public class Program
{
    static void Main(string[] args)
    {
        // Creazione del subject e degli observer
        CentroMeteo centroMeteo = new CentroMeteo();
        DisplayConsole displayConsole = new DisplayConsole();
        DisplayMobile displayMobile = new DisplayMobile();

        // Registrazione degli observer al subject
        centroMeteo.Registra(displayConsole);
        centroMeteo.Registra(displayMobile);

        Console.WriteLine("-- Sistema di notifica Meteo --");
        Console.WriteLine("\nInserisci i dati meteo da notificare agli observer.");
        Console.WriteLine("Digita 'X' per terminare il programma.");

        // Ciclo principale: permette all'utente di inserire dati meteo da notificare agli observer
        while (true)
        {
            Console.Write("\nInserisci nuovi dati meteo (o 'X' per terminare): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "x")
                break;

            Console.WriteLine("\n--- Notifica agli observer ---");
            centroMeteo.AggiornaMeteo(input);
            Console.WriteLine("--- Fine notifica ---");
        }
    }
}
