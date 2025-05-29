public interface IBevanda
{
    //Metodo per ottenere la descrizione della bevanda
    public string Descrizione();
    //Metodo per ottenere il costo della bevanda
    public double Costo();
}

public class Coffee : IBevanda
{
    public string Descrizione()
    {
        return "Caffè";
    }

    public double Costo()
    {
        return 1.50;
    }
}

public class Tea : IBevanda
{
    public string Descrizione()
    {
        return "Tè";
    }

    public double Costo()
    {
        return 2;
    }
}

//Classe astratta per i decoratori di bevanda
public abstract class DecoratoreBevanda : IBevanda
{
    //Riferimento alla bevanda da decorare
    protected IBevanda _bevanda;

    //Costruttore che accetta una bevanda da decorare
    protected DecoratoreBevanda(IBevanda bevanda)
    {
        _bevanda = bevanda;
    }

    //Implementazione base che delega alla bevanda decorata
    public virtual string Descrizione()
    {
        return _bevanda.Descrizione();
    }

    //Implementazione base che delega alla bevanda decorata
    public virtual double Costo()
    {
        return _bevanda.Costo();
    }
}

//Decoratore concreto che aggiunge il latte
public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        //Aggiunge "con latte" alla descrizione della bevanda
        return _bevanda.Descrizione() + " con latte";
    }

    public override double Costo()
    {
        //Aggiunge il costo del latte alla bevanda
        return _bevanda.Costo() + 0.30;
    }
}

//Decoratore concreto che aggiunge il cioccolato
public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        //Aggiunge "con cioccolato" alla descrizione della bevanda
        return _bevanda.Descrizione() + " con cioccolato";
    }

    public override double Costo()
    {
        //Aggiunge il costo del cioccolato alla bevanda
        return _bevanda.Costo() + 0.50;
    }
}

//Decoratore concreto che aggiunge la panna
public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        //Aggiunge "con panna" alla descrizione della bevanda
        return _bevanda.Descrizione() + " con panna";
    }

    public override double Costo()
    {
        //Aggiunge il costo della panna alla bevanda
        return _bevanda.Costo() + 0.40;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        //Crea una bevanda base (Caffè)
        IBevanda bevanda = new Coffee();
        //Aggiunge il latte tramite decoratore
        bevanda = new ConLatte(bevanda);
        //Aggiunge la panna tramite decoratore
        bevanda = new ConPanna(bevanda);

        //Ottiene la descrizione e il costo totale della bevanda decorata
        string descrizione = bevanda.Descrizione();
        double costo = bevanda.Costo();

        //Stampa la descrizione e il costo totale
        Console.WriteLine($"Descrizione: {descrizione}");
        Console.WriteLine($"Costo totale: {costo} €");
    }
}