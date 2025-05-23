class Program
{
    static void Main(string[] args)
    {
        //dichiarazione variabili
        int numeroUno;
        int numeroDue;

        //output e input iniziale
        Console.WriteLine("Inserisci il primo numero: ");
        numeroUno = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il secondo numero: ");
        numeroDue = int.Parse(Console.ReadLine());

        //somma + metodo stampa
        int risultatoSomma = Somma(numeroUno, numeroDue);
        StampaRisultato("somma", risultatoSomma);

        //moltiplicazione + metodo stampa
        int risultatoMoltiplicazione = Moltiplica(numeroUno, numeroDue);
        StampaRisultato("moltiplicazione", risultatoMoltiplicazione);

        //divisione + metodo stampa
        int risultatoDivisione = Dividi(numeroUno, numeroDue);
        StampaRisultato("divisione", risultatoDivisione);

    }

    static int Somma(int a, int b)
    {
        return a + b;
    }

    static int Moltiplica(int a, int b)
    {
        return a * b;
    }

    static int Dividi(int a, int b)
    {
        //* gestione eccezioni (extra)
        try
        {
            if (b == 0)//controllo divisione per zero
            {
                Console.WriteLine("Errore: Divisione per zero non consentita.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return a / b;
    }

    static void StampaRisultato(string operazione, int risultato)
    {
        Console.WriteLine($"\nIl risultato dell'operazione {operazione} è: {risultato}");
    }

}
