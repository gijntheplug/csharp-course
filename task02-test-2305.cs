public class ContoCorrente
{
    //proprietà private
    private decimal saldo;
    private int numeroOperazioni;

    //proprietà pubbliche
    public decimal Saldo
    {
        get
        {
            return saldo;
        }
    }
    public int NumeroOperazioni
    {
        get
        {
            return numeroOperazioni;
        }
    }

    public void Versa(decimal versamento)//metodo VERSA
    {
        if (versamento <= 0)
        {
            Console.WriteLine("Errore! L'importo deve essere positivo.");
        }
        else
        {
            saldo = saldo + versamento;//aggiunge i soldi del versamento al saldo totale nel conto
            numeroOperazioni++;//incrementa il numero di operazioni eseguite
        }
    }

    public void Preleva(decimal prelievo)
    {
        if (prelievo <= 0)
        {
            Console.WriteLine("Errore! Il prelievo deve essere positivo.");
        }
        else if (prelievo > saldo)
        {
            Console.WriteLine("Errore! Non puoi prelevare più soldi di quanti tu ne abbia già sul conto.");
        }
        else
        {
            saldo = saldo - prelievo;//scala i soldi del prelievo dal conto
            numeroOperazioni++;//incremento numero operazioni
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        ContoCorrente conto = new ContoCorrente();//inizializza l'oggetto conto dalla classe "ContoCorrente"

        while (true)
        {
            Console.WriteLine("\nBenvenuto nell'ATM:");
            Console.WriteLine("[1] Versa");
            Console.WriteLine("[2] Preleva");
            Console.WriteLine("[3] Visualizza saldo e numero operazioni");
            Console.WriteLine("[4] Esci");

            Console.Write("Scegli un'opzione: ");
            string scelta = Console.ReadLine();
            bool ciclo = true;
            while (ciclo)
            {
                switch (scelta)
                {
                    case "1":
                        Console.Write("Inserisci l'importo da versare: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal versamento))
                        {
                            conto.Versa(versamento);
                        }
                        else
                        {
                            Console.WriteLine("Importo non valido.");
                        }
                        break;
                    case "2":
                        Console.Write("Inserisci l'importo da prelevare: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal prelievo))
                        {
                            conto.Preleva(prelievo);
                        }
                        else
                        {
                            Console.WriteLine("Importo non valido.");
                        }
                        break;
                    case "3":
                        Console.WriteLine($"Saldo attuale: {conto.Saldo}");
                        Console.WriteLine($"Numero operazioni: {conto.NumeroOperazioni}");
                        break;
                    case "4":
                        ciclo = false;
                        Console.WriteLine("Arrivederci!");
                        return;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }
    }
}