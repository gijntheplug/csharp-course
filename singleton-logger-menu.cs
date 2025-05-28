using System;
using System.Collections.Generic;

//Implementazione del pattern Singleton per la classe Logger
public sealed class Logger
{
    //Campo statico che contiene l'unica istanza della classe Logger
    private static Logger _instance;

    //Lista per memorizzare i messaggi di log
    private List<string> _message;

    //Costruttore privato VUOTO per impedire l'istanziazione dall'esterno
    private Logger() { }

    //Metodo statico per singletonizzare l'istanza di Logger
    public static Logger GetIstanza()
    {
        if (_instance is null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    //Metodo per aggiungere un messaggio di log alla lista
    public void Log(string message)
    {
        if (_message is null)
        {
            _message = new List<string>();
        }
        _message.Add(message);
    }

    //Metodo per ottenere tutti i messaggi di log
    public List<string> GetMessaggi()
    {
        return _message;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //! Otteniamo l'istanza singletonizzata di Logger
        Logger primo = Logger.GetIstanza();
        Logger secondo = Logger.GetIstanza();

        bool ciclo = true;

        //Menù per input utente
        while (ciclo)
        {
            Console.WriteLine("\n-- Menu messaggi di Log --");
            Console.WriteLine("1. Aggiungi messaggio di log");
            Console.WriteLine("2. Mostra i messaggi");
            Console.WriteLine("3. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("Inserisci il messaggio di log: ");
                    string messaggio = Console.ReadLine();
                    primo.Log(messaggio); //Aggiunge il messaggio alla lista del logger
                    Console.WriteLine("Messaggio aggiunto.");
                    break;
                case "2":
                    Console.WriteLine("\nMessaggi di log inseriti:");
                    //Stampa tutti i messaggi di log presenti nella lista
                    foreach (string msg in primo.GetMessaggi())
                    {
                        Console.WriteLine(msg);
                    }
                    break;
                case "3":
                    ciclo = false; //Esce dal ciclo e termina il programma
                    break;
                default:
                    Console.WriteLine("Errore! Scelta non valida, riprova.\n");
                    break;
            }
        }
    }
}