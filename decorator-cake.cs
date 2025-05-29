public interface ITorta
{
    public string Descrizione(); // Metodo per ottenere la descrizione della torta
}
public class TortaCioccolato : ITorta
{
    public string Descrizione()
    {
        return "Torta al cioccolato";
    }
}
public class TortaVaniglia : ITorta
{
    public string Descrizione()
    {
        return "Torta alla vaniglia";
    }
}
public class TortaFrutta : ITorta
{
    public string Descrizione()
    {
        return "Torta alla frutta";
    }
}
// Classe astratta per i decoratori di torta
public abstract class DecoratoreTorta : ITorta
{
    protected ITorta _torta; // Riferimento alla torta da decorare
    protected DecoratoreTorta(ITorta torta)
    {
        _torta = torta;
    }
    public virtual string Descrizione()
    {
        return _torta.Descrizione();
    }
}
// Decoratore concreto: aggiunge panna
public class ConPanna : DecoratoreTorta
{
    public ConPanna(ITorta torta) : base(torta) { }
    public override string Descrizione()
    {
        return _torta.Descrizione() + " con panna";
    }
}
// Decoratore concreto: aggiunge fragole
public class ConFragole : DecoratoreTorta
{
    public ConFragole(ITorta torta) : base(torta) { }
    public override string Descrizione()
    {
        return _torta.Descrizione() + " con fragole";
    }
}
// Decoratore concreto: aggiunge glassa
public class ConGlassa : DecoratoreTorta
{
    public ConGlassa(ITorta torta) : base(torta) { }
    public override string Descrizione()
    {
        return _torta.Descrizione() + " con glassa";
    }
}
// Factory per creare la torta base in base al tipo
public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "cioccolato":
                return new TortaCioccolato();
            case "vaniglia":
                return new TortaVaniglia();
            case "frutta":
                return new TortaFrutta();
            default:
                throw new ArgumentException("Tipo di torta non riconosciuto");
        }
    }
}
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Scegli la torta base (cioccolato, vaniglia, frutta):");
        string tipoBase = Console.ReadLine();
        ITorta torta = TortaFactory.CreaTortaBase(tipoBase); // Creazione della torta base tramite factory

        bool aggiungi = true;
        while (aggiungi)
        {
            Console.WriteLine("Aggiungi un ingrediente extra? (Disponibili: panna, fragole, glassa) inserisci 'x' per uscire dal ciclo:");
            string extra = Console.ReadLine().ToLower();
            switch (extra)
            {
                case "panna":
                    torta = new ConPanna(torta); // Aggiunge decoratore panna
                    break;
                case "fragole":
                    torta = new ConFragole(torta); // Aggiunge decoratore fragole
                    break;
                case "glassa":
                    torta = new ConGlassa(torta); // Aggiunge decoratore glassa
                    break;
                case "x":
                    aggiungi = false; // Esce dal ciclo se l'utente inserisce "x"
                    break;
                default:
                    Console.WriteLine("Ingrediente non riconosciuto.");
                    aggiungi = false; // Esce dal ciclo se l'ingrediente non è valido
                    break;
            }
        }

        Console.WriteLine("Descrizione finale: " + torta.Descrizione()); // Stampa la descrizione finale della torta
    }
}