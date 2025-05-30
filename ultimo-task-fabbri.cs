using System;
using System.Collections.Generic;
#region Interface IPizza + Pizze
// Definizione dell'interfaccia IPizza che rappresenta il contratto per tutte le pizze
public interface IPizza
{
    string Descrizione();
}

// Implementazione concreta di una pizza Margherita
public class Margherita : IPizza
{
    public string Descrizione()
    {
        return "Pizza margherita";
    }
}
// Implementazione concreta di una pizza Diavola
public class Diavola : IPizza
{
    public string Descrizione()
    {
        return "Pizza diavola";
    }
}
// Implementazione concreta di una pizza Vegetariana
public class Vegetariana : IPizza
{
    public string Descrizione()
    {
        return "Pizza vegetariana";
    }
}
#endregion

#region Factory Method Pattern
// Classe statica che implementa il Factory Method per creare oggetti IPizza
public static class PizzaFactory
{
    public static IPizza CreaPizza(string tipo)
    {
        // Mostra il menu per la scelta della pizza
        Console.WriteLine("Scegli il tipo di pizza:");
        Console.WriteLine("1. Pizza Margherita");
        Console.WriteLine("2. Pizza Diavola");
        Console.WriteLine("3. Pizza Vegetariana");

        Console.Write("Scelta: ");
        string scelta = Console.ReadLine();

        IPizza pizza = null;

        // Crea l'istanza della pizza in base alla scelta dell'utente
        switch (scelta)
        {
            case "1":
                pizza = new Margherita();
                break;
            case "2":
                pizza = new Diavola();
                break;
            case "3":
                pizza = new Vegetariana();
                break;
            default:
                Console.WriteLine("Errore! Scelta non valida.");
                return;
        }
    }
}
#endregion

#region Decorator Pattern
// Classe astratta per il pattern Decorator, permette di aggiungere ingredienti dinamicamente
public abstract class IngredienteDecorator : IPizza
{
    protected IPizza _pizza;
    protected IngredienteDecorator(IPizza pizza)
    {
        _pizza = pizza;
    }
    public virtual string Descrizione()
    {
        return _pizza.Descrizione();
    }
}

// Decorator concreto che aggiunge olive alla pizza
public class ConOlive : IngredienteDecorator
{
    public ConOlive(IPizza pizza) : base(pizza) { }
    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con olive";
    }
}

// Decorator concreto che aggiunge mozzarella extra alla pizza
public class ConMozzarellaExtra : IngredienteDecorator
{
    public ConMozzarellaExtra(IPizza pizza) : base(pizza) { }
    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con mozzarella extra";
    }
}

// Decorator concreto che aggiunge funghi alla pizza
public class ConFunghi : IngredienteDecorator
{
    public ConFunghi(IPizza pizza) : base(pizza) { }
    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con funghi";
    }
}
#endregion

#region Strategy Pattern
// Interfaccia per il pattern Strategy, rappresenta il metodo di cottura
public interface IMetodoCottura
{
    string Cuoci(string pizza);
}

// Implementazione concreta: cottura in forno elettrico
public class FornoElettrico : IMetodoCottura
{
    public string Cuoci(string pizza)
    {
        return "Cottura: forno elettrico";
    }
}

// Implementazione concreta: cottura in forno a legna
public class FornoLegna : IMetodoCottura
{
    public string Cuoci(string pizza)
    {
        return "Cottura: forno a legna";
    }
}

// Implementazione concreta: cottura in forno ventilato
public class FornoVentilato : IMetodoCottura
{
    public string Cuoci(string pizza)
    {
        return "Cottura: forno ventilato";
    }
}
#endregion

#region Singleton Pattern
// Implementazione del pattern Singleton per gestire gli ordini
public sealed class GestoreOrdine
{
    private static GestoreOrdine _instance;
    private static readonly object _lock = new object();
    private List<IPizza> pizze = new List<IPizza>();
    private GestoreOrdine() { }
    public static GestoreOrdine Instance
    {
        get
        {
            // Doppio controllo per garantire thread safety
            if (_instance is null)
            {
                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new GestoreOrdine();
                    }
                }
            }
            return _instance;
        }
    }
    // Salva una pizza nell'elenco degli ordini
    public void SalvaOrdine(IPizza pizza)
    {
        pizze.Add(pizza);
    }
}
#endregion

#region Observer Pattern
// Interfaccia per il pattern Observer
public interface IObserver
{
    void Notifica(string messaggio);
}

// Observer concreto che simula un sistema di log
public class SistemaLog : IObserver
{
    public void Notifica(string messaggio)
    {
        Console.WriteLine($"MESSAGGIO DI LOG | Nuovo ordine: {messaggio}");
    }
}

// Observer concreto che simula un sistema di marketing
public class SistemaMarketing : IObserver
{
    public void Notifica(string messaggio)
    {
        Console.WriteLine($"MARKETING | Promo inviata per: {messaggio}");
    }
}

// Classe che gestisce la lista degli osservatori e le notifiche
public class ObserverOrdine
{
    private readonly List<IObserver> osservatori = new List<IObserver>();
    public void AddObserver(IObserver observer)
    {
        observer.Add(observer); // ERRORE: dovrebbe essere 'osservatori.Add(observer);'
    }
    public void NotificaTutti(string messaggio)
    {
        foreach (IObserver obs in osservatori)
        {
            obs.Notifica(messaggio);
        }
    }
}
#endregion

#region Main
public class Program
{
    static void Main(string[] args)
    {
        // Inizializza il sistema di osservatori
        ObserverOrdine observerOrdine = new ObserverOrdine();
        observerOrdine.AddObserver(new SistemaLog());
        observerOrdine.AddObserver(new SistemaMarketing());

        while (true)
        {
            // Menu principale per l'utente
            Console.WriteLine("\n--- MENU ORDINAZIONI PIZZA ---");
            Console.WriteLine("1. Crea nuova ordinazione");
            Console.WriteLine("2. Esci");
            Console.Write("Scelta: ");
            string sceltaMenu = Console.ReadLine();

            switch (sceltaMenu)
            {
                case "1":
                    // Scegli pizza base tramite Factory
                    IPizza pizza = PizzaFactory.CreaPizza("");
                    if (pizza == null)
                        break;

                    // Ciclo per aggiungere ingredienti tramite Decorator
                    bool aggiungi = true;
                    while (aggiungi)
                    {
                        Console.WriteLine("\nAggiungi ingredienti:");
                        Console.WriteLine("1. Olive");
                        Console.WriteLine("2. Mozzarella extra");
                        Console.WriteLine("3. Funghi");
                        Console.WriteLine("4. Nessun altro ingrediente");
                        Console.Write("Scelta: ");
                        string sceltaIng = Console.ReadLine();
                        switch (sceltaIng)
                        {
                            case "1":
                                pizza = new ConOlive(pizza);
                                break;
                            case "2":
                                pizza = new ConMozzarellaExtra(pizza);
                                break;
                            case "3":
                                pizza = new ConFunghi(pizza);
                                break;
                            case "4":
                                aggiungi = false;
                                break;
                            default:
                                Console.WriteLine("Scelta non valida.");
                                break;
                        }
                    }

                    // Scegli il metodo di cottura tramite Strategy
                    Console.WriteLine("\nScegli metodo di cottura:");
                    Console.WriteLine("1. Forno elettrico");
                    Console.WriteLine("2. Forno a legna");
                    Console.WriteLine("3. Forno ventilato");
                    Console.Write("Scelta: ");
                    string sceltaCottura = Console.ReadLine();
                    IMetodoCottura metodoCottura = sceltaCottura switch
                    {
                        "1" => new FornoElettrico(),
                        "2" => new FornoLegna(),
                        "3" => new FornoVentilato(),
                        _ => new FornoElettrico()
                    };

                    // Salva l'ordine tramite Singleton
                    GestoreOrdine.Instance.SalvaOrdine(pizza);

                    // Notifica tutti gli osservatori dell'ordine effettuato
                    string descrizione = pizza.Descrizione() + " | " + metodoCottura.Cuoci("");
                    observerOrdine.NotificaTutti(descrizione);

                    Console.WriteLine($"\nOrdinazione completata: {descrizione}");
                    break;

                case "2":
                    Console.WriteLine("Arrivederci!");
                    return;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}
#endregion
