using System;
using System.Collections.Generic;

//Interfaccia per gli observer che riceveranno notifiche
public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}

//Interfaccia per il subject che gestisce la registrazione, rimozione e notifica degli observer
public interface ISubject
{
    void Registra(IObserver observer);
    void Rimuovi(IObserver observer);
    void Notifica(string nomeUtente);
}

//Classe che rappresenta un utente
public class Utente
{
    public string Nome { get; }

    public Utente(string nome)
    {
        Nome = nome;
    }
}

//Classe statica per la creazione di utenti (Factory Method)
public static class UserFactory
{
    public static Utente CreaUtente(string nome)
    {
        return new Utente(nome);
    }
}

//Classe che gestisce la creazione degli utenti e notifica gli observer registrati
public class GestoreCreazioneUtente : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();

    public void Registra(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void Rimuovi(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notifica(string nomeUtente)
    {
        foreach (IObserver observer in _observers)
        {
            observer.NotificaCreazione(nomeUtente);
        }
    }

    public void CreaUtente(string nome)
    {
        Utente nuovoUtente = UserFactory.CreaUtente(nome);
        Notifica(nuovoUtente.Nome);
    }
}

//Observer che rappresenta il modulo di log
public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"[LOG] Utente creato: {nomeUtente}");
    }
}

//Observer che rappresenta il modulo marketing
public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"[MARKETING] Benvenuto nuovo utente: {nomeUtente}!");
    }
}

//Classe principale che gestisce il menu e l'interazione con l'utente
public class Program
{
    static void Main(string[] args)
    {
        GestoreCreazioneUtente gestore = new GestoreCreazioneUtente();
        ModuloLog moduloLog = new ModuloLog();
        ModuloMarketing moduloMarketing = new ModuloMarketing();

        gestore.Registra(moduloLog);
        gestore.Registra(moduloMarketing);

        List<Utente> utenti = new List<Utente>();

        bool esci = false;
        while (!esci)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Crea nuovo utente");
            Console.WriteLine("2. Mostra lista utenti");
            Console.WriteLine("3. Esci");
            Console.Write("\nScelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("\nInserisci un nome utente: ");
                    string input = Console.ReadLine();
                    gestore.CreaUtente(input);
                    utenti.Add(new Utente(input));
                    Console.WriteLine();
                    break;
                case "2":
                    if (utenti.Count == 0)
                    {
                        Console.WriteLine("\nNessun utente inserito.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nLista utenti:");
                        foreach (var utente in utenti)
                        {
                            Console.WriteLine($"- {utente.Nome}");
                        }
                        Console.WriteLine();
                    }
                    break;
                case "3":
                    esci = true;
                    Console.WriteLine("\nUscita dal programma.\n");
                    break;
                default:
                    Console.WriteLine("\nErrore! Scelta non valida.\n");
                    break;
            }
        }
    }
}