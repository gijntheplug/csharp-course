public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}

//Implementazione dell'interfaccia IVeicolo per il tipo Auto
public class Auto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio dell'auto");
    }
    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Auto");
    }
}

//Implementazione dell'interfaccia IVeicolo per il tipo Moto
public class Moto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio della moto");
    }
    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Moto");
    }
}

//Implementazione dell'interfaccia IVeicolo per il tipo Camion
public class Camion : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio del camion");
    }
    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Camion");
    }
}

//Factory Method per la creazione di oggetti IVeicolo in base al tipo richiesto
public static class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "auto":
                return new Auto();
            case "moto":
                return new Moto();
            case "camion":
                return new Camion();
            default:
                Console.WriteLine("Errore! Tipo di veicolo non riconosciuto");
                return null;
        }
    }
}

//Singleton che mantiene il registro dei veicoli creati
public sealed class RegistroVeicoli
{
    private static RegistroVeicoli _instance;
    private static readonly object _lock = new object();

    //Lista dei veicoli creati e registrati
    private List<IVeicolo> veicoliCreati = new List<IVeicolo>();

    //Costruttore privato per impedire l'istanziazione esterna
    private RegistroVeicoli() { }

    //Proprietà per ottenere l'istanza singleton
    public static RegistroVeicoli Instance
    {
        get
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new RegistroVeicoli();
                    }
                }
            }
            return _instance;
        }
    }

    //Metodo per registrare un veicolo
    public void Registra(IVeicolo veicolo)
    {
        veicoliCreati.Add(veicolo);
    }

    //Metodo per stampare tutti i veicoli registrati
    public void StampaTutti()
    {
        foreach (IVeicolo veicolo in veicoliCreati)
        {
            veicolo.MostraTipo();
            veicolo.Avvia();
        }
    }
}

//Classe principale del programma
public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n-- Menu gestionale dei Veicoli --:");
            Console.WriteLine("[1] Crea un veicolo");
            Console.WriteLine("[2] Mostra tutti veicoli registrati");
            Console.WriteLine("[3] Esci");
            
            Console.Write("Scegli un'opzione: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci il tipo di veicolo (auto/moto/camion): ");
                    string tipo = Console.ReadLine();
                    IVeicolo veicolo = VeicoloFactory.CreaVeicolo(tipo);
                    if (veicolo != null)
                    {
                        RegistroVeicoli.Instance.Registra(veicolo);
                        Console.WriteLine("Veicolo creato e registrato.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Veicoli registrati:");
                    RegistroVeicoli.Instance.StampaTutti();
                    break;
                case "3":
                    Console.WriteLine("Uscita dal programma.");
                    return;
                default:
                    Console.WriteLine("Errore! Opzione non valida.");
                    break;
            }
        }
    }
}