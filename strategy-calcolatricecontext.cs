public interface IStrategiaOperazione
{
    //Interfaccia che definisce il metodo per eseguire un'operazione tra due numeri
    double Calcola(double a, double b);
}

public class SommaStrategia : IStrategiaOperazione
{
    //Implementazione della strategia per la somma
    public double Calcola(double a, double b)
    {
        return a + b;
    }
}

public class SottrazioneStrategia : IStrategiaOperazione
{
    //Implementazione della strategia per la sottrazione
    public double Calcola(double a, double b)
    {
        return a - b;
    }
}

public class MoltiplicazioneStrategia : IStrategiaOperazione
{
    //Implementazione della strategia per la moltiplicazione
    public double Calcola(double a, double b)
    {
        return a * b;
    }
}

public class DivisioneStrategia : IStrategiaOperazione
{
    //Implementazione della strategia per la divisione
    public double Calcola(double a, double b)
    {
        if (b == 0)
        {
            //Gestione dell'errore di divisione per zero
            throw new DivideByZeroException("Errore! Impossibile dividere per zero.");
        }
        return a / b;
    }
}

public class CalcolatriceContext
{
    //Contesto che mantiene la strategia corrente
    private IStrategiaOperazione _strategia;

    //Metodo per selezionare la strategia desiderata
    public void SelezionaStrategia(IStrategiaOperazione strategia)
    {
        _strategia = strategia;
    }

    //Metodo per eseguire l'operazione utilizzando la strategia selezionata
    public void EseguiOperazione(double a, double b)
    {
        if (_strategia is null)
        {
            Console.WriteLine("Nessuna strategia impostata.");
            return;
        }
        double risultato = _strategia.Calcola(a, b);
        Console.WriteLine($"Risultato dell'operazione: {risultato}");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        //Creazione del contesto della calcolatrice
        CalcolatriceContext calcolatrice = new CalcolatriceContext();

        //Lettura del primo numero dall'utente
        Console.Write("Inserisci il primo numero: ");
        double a = double.Parse(Console.ReadLine());

        //Lettura del secondo numero dall'utente
        Console.Write("Inserisci il secondo numero: ");
        double b = double.Parse(Console.ReadLine());

        //Scelta dell'operazione da eseguire
        Console.WriteLine("Scegli l'operazione:");
        Console.WriteLine("1. Somma");
        Console.WriteLine("2. Sottrazione");
        Console.WriteLine("3. Moltiplicazione");
        Console.WriteLine("4. Divisione");
        Console.Write("Scelta: ");
        string scelta = Console.ReadLine();

        //Selezione della strategia in base alla scelta dell'utente
        switch (scelta)
        {
            case "1":
                calcolatrice.SelezionaStrategia(new SommaStrategia());
                break;
            case "2":
                calcolatrice.SelezionaStrategia(new SottrazioneStrategia());
                break;
            case "3":
                calcolatrice.SelezionaStrategia(new MoltiplicazioneStrategia());
                break;
            case "4":
                calcolatrice.SelezionaStrategia(new DivisioneStrategia());
                break;
            default:
                Console.WriteLine("Scelta non valida.");
                return;
        }

        try
        {
            //Esecuzione dell'operazione e gestione delle eventuali eccezioni
            calcolatrice.EseguiOperazione(a, b);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }
    }
}
