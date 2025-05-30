#region Interface
public interface IPiatto
{
    string Descrizione();
    string Prepara();
}
#endregion
#region Piatti
//Classe concreta che rappresenta una Pizza
public class Pizza : IPiatto
{
    public string Descrizione()
    {
        return "Pizza";
    }
    public string Prepara()
    {
        return "Preparazione della pizza";
    }
}

//Classe concreta che rappresenta un Hamburger
public class Hamburger : IPiatto
{
    public string Descrizione()
    {
        return "Hamburger";
    }
    public string Prepara()
    {
        return "Preparazione dell'hamburger";
    }
}

//Classe concreta che rappresenta un'Insalata
public class Insalata : IPiatto
{
    public string Descrizione()
    {
        return "Insalata";
    }
    public string Prepara()
    {
        return "Preparazione dell'insalata";
    }
}
#endregion
#region Decorator
//Classe astratta per decorare un piatto con ingredienti extra
public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto _piatto;
    protected IngredienteExtra(IPiatto piatto)
    {
        _piatto = piatto;
    }

    public virtual string Descrizione()
    {
        return _piatto.Descrizione();
    }

    public virtual string Prepara()
    {
        return _piatto.Prepara();
    }

}

//Decoratore concreto per aggiungere formaggio
public class ConFormaggio : IngredienteExtra
{
    public ConFormaggio(IPiatto piatto) : base(piatto) { }
    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con formaggio";
    }
    public override string Prepara()
    {
        return _piatto.Prepara();
    }
}

//Decoratore concreto per aggiungere bacon
public class ConBacon : IngredienteExtra
{
    public ConBacon(IPiatto piatto) : base(piatto) { }
    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con bacon";
    }
    public override string Prepara()
    {
        return _piatto.Prepara();
    }
}

//Decoratore concreto per aggiungere salsa
public class ConSalsa : IngredienteExtra
{
    public ConSalsa(IPiatto piatto) : base(piatto) { }
    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con salsa";
    }
    public override string Prepara()
    {
        return _piatto.Prepara();
    }
}
#endregion
#region Factory Method
//Factory per la creazione dei piatti e aggiunta ingredienti extra
public class PiattoFactory
{
    public static void CreaPiatto()
    {
        Console.WriteLine("Scegli il tipo di piatto:");
        Console.WriteLine("1. Pizza");
        Console.WriteLine("2. Hamburger");
        Console.WriteLine("3. Insalata");
        Console.Write("Scelta: ");
        string scelta = Console.ReadLine();

        IPiatto piatto = null;

        switch (scelta)
        {
            case "1":
                piatto = new Pizza();
                break;
            case "2":
                piatto = new Hamburger();
                break;
            case "3":
                piatto = new Insalata();
                break;
            default:
                Console.WriteLine("Errore! Scelta non valida.");
                return;
        }

        Console.WriteLine("Vuoi aggiungere ingredienti extra?");
        Console.WriteLine("a. Formaggio");
        Console.WriteLine("b. Bacon");
        Console.WriteLine("c. Salsa");
        Console.WriteLine("d. Nessuno");
        Console.Write("Scelta: ");
        string extra = Console.ReadLine();

        switch (extra)
        {
            case "a":
                piatto = new ConFormaggio(piatto);
                break;
            case "b":
                piatto = new ConBacon(piatto);
                break;
            case "c":
                piatto = new ConSalsa(piatto);
                break;
            case "d":
                break;
            default:
                Console.WriteLine("Errore! Scelta extra non valida.");
                break;
        }

        Console.WriteLine("Hai scelto: " + piatto.Descrizione());
    }
}
#endregion
#region Strategy
//Interfaccia per la strategia di preparazione
public interface IPreparazioneStrategy
{
    string Prepara(string descrizione);
}

//Strategia di preparazione fritta
public class PreparazioneFritto : IPreparazioneStrategy
{
    public string Prepara(string descrizione)
    {
        return "Preparazione: fritto/a";
    }
}

//Strategia di preparazione al forno
public class PreparazioneAlForno : IPreparazioneStrategy
{
    public string Prepara(string descrizione)
    {
        return "Preparazione: al forno";
    }
}

//Strategia di preparazione alla griglia
public class PreparazioneAllaGriglia : IPreparazioneStrategy
{
    public string Prepara(string descrizione)
    {
        return "Preparazione: alla griglia";
    }
}

//Context che utilizza la strategia di preparazione selezionata
public class ChefContext
{
    private IPreparazioneStrategy _strategia;
    public void SelezionaStrategia(IPreparazioneStrategy strategia)
    {
        _strategia = strategia;
    }
    public void PreparaPiatto(IPiatto piatto)
    {
        if (_strategia is null)
        {
            Console.WriteLine("Nessuna strategia di preparazione selezionata.");
            return;
        }
        string descrizione = piatto.Descrizione();
        string risultato = _strategia.Prepara(descrizione);
        Console.WriteLine(risultato);
    }
}
#endregion
#region Main
//Classe principale del programma
public class Program
{
    static void Main(string[] args)
    {
        IPiatto piatto = null;

        //Selezione tipo di piatto da parte dell'utente
        Console.WriteLine("Scegli il tipo di piatto:");
        Console.WriteLine("1. Pizza");
        Console.WriteLine("2. Hamburger");
        Console.WriteLine("3. Insalata");
        Console.Write("Scelta: ");
        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                piatto = new Pizza();
                break;
            case "2":
                piatto = new Hamburger();
                break;
            case "3":
                piatto = new Insalata();
                break;
            default:
                Console.WriteLine("Scelta non valida.");
                return;
        }

        //Ciclo per aggiungere più ingredienti extra
        bool aggiungiAltro = true;
        while (aggiungiAltro)
        {
            Console.WriteLine("Vuoi aggiungere ingredienti extra?");
            Console.WriteLine("a. Formaggio");
            Console.WriteLine("b. Bacon");
            Console.WriteLine("c. Salsa");
            Console.WriteLine("d. Nessuno (continua)");
            Console.Write("Scelta: ");
            string extra = Console.ReadLine();

            switch (extra)
            {
                case "a":
                    piatto = new ConFormaggio(piatto);
                    break;
                case "b":
                    piatto = new ConBacon(piatto);
                    break;
                case "c":
                    piatto = new ConSalsa(piatto);
                    break;
                case "d":
                    aggiungiAltro = false;
                    break;
                default:
                    Console.WriteLine("Scelta extra non valida.");
                    break;
            }
            if (extra is "d") break;
        }

        //Selezione della strategia di preparazione
        Console.WriteLine("Scegli la modalità di preparazione:");
        Console.WriteLine("1. Fritto");
        Console.WriteLine("2. Al forno");
        Console.WriteLine("3. Alla griglia");
        Console.Write("Scelta: ");
        string cottura = Console.ReadLine();

        IPreparazioneStrategy strategy = null;
        switch (cottura)
        {
            case "1":
                strategy = new PreparazioneFritto();
                break;
            case "2":
                strategy = new PreparazioneAlForno();
                break;
            case "3":
                strategy = new PreparazioneAllaGriglia();
                break;
            default:
                Console.WriteLine("Scelta di cottura non valida.");
                return;
        }

        //Output finale con descrizione e preparazione
        Console.WriteLine("Hai scelto: " + piatto.Descrizione());

        ChefContext chef = new ChefContext();
        chef.SelezionaStrategia(strategy);
        chef.PreparaPiatto(piatto);
    }
}
#endregion
