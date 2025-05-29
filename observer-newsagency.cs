using System;
using System.Collections.Generic;

//Interfaccia per gli osservatori che riceveranno aggiornamenti
public interface IObserver
{
    void Aggiorna(string messaggio);
}

//Interfaccia per il soggetto osservato
public interface ISubject
{
    void Registra(IObserver osservatore);
    void Rimuovi(IObserver osservatore);
    void Notifica();
}

//Singleton che rappresenta l'agenzia di notizie e implementa il pattern Observer
public sealed class NewsAgencySingleton : ISubject
{
    private static readonly NewsAgencySingleton _instance = new NewsAgencySingleton(); //Istanza singleton
    private readonly List<IObserver> _osservatori = new List<IObserver>(); //Lista degli osservatori registrati
    private string _news; //Ultima notizia

    private NewsAgencySingleton() { } //Costruttore privato per il singleton

    public static NewsAgencySingleton Instance => _instance; //Proprietà per accedere all'istanza singleton

    public string News
    {
        get => _news;
        set
        {
            _news = value;
            Notifica(); //Notifica tutti gli osservatori quando viene impostata una nuova notizia
        }
    }

    public void Registra(IObserver observer)
    {
        _osservatori.Add(observer); //Registra un nuovo osservatore
    }

    public void Rimuovi(IObserver observer)
    {
        _osservatori.Remove(observer); //Rimuove un osservatore
    }

    public void Notifica()
    {
        foreach (IObserver observer in _osservatori)
        {
            observer.Aggiorna(_news); //Notifica ogni osservatore con la nuova notizia
        }
    }
}

//Osservatore che simula una notifica su mobile
public class MobileApp : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"Notification on mobile: {messaggio}");
    }
}

//Osservatore che simula l'invio di una email
public class EmailClient : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"Email sent: {messaggio}");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        MobileApp mobileApp = new MobileApp(); //Istanza dell'app mobile
        EmailClient emailClient = new EmailClient(); //Istanza del client email

        NewsAgencySingleton.Instance.Registra(mobileApp); //Registrazione degli osservatori
        NewsAgencySingleton.Instance.Registra(emailClient);

        Console.WriteLine("\n -- Benvenuto nel gestionale del Notiziario --");
        Console.WriteLine("Scrivi una notizia e premi Invio (o scrivi 'X' per terminare):");

        List<string> tutteLeNotizie = new List<string>(); //Lista per memorizzare tutte le notizie
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("[1] Scrivi una notizia");
            Console.WriteLine("[2] Mostra tutte le notizie");
            Console.WriteLine("[3] Esci dall'app");
            Console.Write("Scegli un'opzione: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Nuova notizia: ");
                    string notizia = Console.ReadLine();
                    if (notizia is null)
                    {
                        NewsAgencySingleton.Instance.News = notizia; //Imposta la nuova notizia (singletonizzata) e notifica gli osservatori
                        tutteLeNotizie.Add(notizia); //Aggiunge la notizia alla lista
                    }
                    break;
                case "2":
                    Console.WriteLine("\n-- Lista di tutte le notizie --");
                    if (tutteLeNotizie is null)
                    {
                        Console.WriteLine("Nessuna notizia disponibile.");
                    }
                    else
                    {
                        foreach (var n in tutteLeNotizie)
                        {
                            Console.WriteLine("- " + n); //Stampa tutte le notizie
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Programma terminato.");
                    return;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }
    }
}
