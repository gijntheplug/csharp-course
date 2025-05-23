using System;

public class PrenotazioneViaggio
{
    // campi privati
    private int postiPrenotati = 0;
    private const int maxPosti = 20;

    // destinazione pubblica
    public string Destinazione { get; set; }

    // posti prenotati (lettura)
    public int PostiPrenotati
    {
        get { return postiPrenotati; }
    }

    // calcolo posti disponibili
    public int PostiDisponibili
    {
        get { return maxPosti - postiPrenotati; }
    }

    // metodo per effettuare prenotazione
    public void PrenotaPosti(int numero)
    {
        if (numero <= 0)//non puoi prenotare un posto "negativo" o "nullo"
        {
            Console.WriteLine("Numero non valido.");//output errore
        }
        else if (numero <= PostiDisponibili)
        {
            postiPrenotati += numero;
            Console.WriteLine($"{numero} posti prenotati con successo.");
        }
        else
        {
            Console.WriteLine("Posti insufficienti disponibili.");
        }
    }

    // metodo per annullare prenotazione
    public void AnnullaPrenotazione(int numero)
    {
        if (numero <= 0)
        {
            Console.WriteLine("Numero non valido.");
        }
        else if (numero <= postiPrenotati)
        {
            postiPrenotati -= numero;
            Console.WriteLine($"{numero} posti annullati con successo.");
        }
        else
        {
            Console.WriteLine("Non puoi annullare più posti di quelli prenotati.");
        }
    }

    // output info
    public void StampaDettagli()
    {
        Console.WriteLine($"\nDestinazione: {Destinazione}");
        Console.WriteLine($"Posti prenotati: {PostiPrenotati}");
        Console.WriteLine($"Posti disponibili: {PostiDisponibili}\n");
    }
}

public class Program
{
    public static void Main()
    {
        PrenotazioneViaggio prenotazione = new PrenotazioneViaggio();//crea nuovo oggetto viaggio (prenotazione)

        Console.Write("Inserisci la destinazione del viaggio: ");
        prenotazione.Destinazione = Console.ReadLine();

        prenotazione.StampaDettagli();

        // Esempio di prenotazione
        prenotazione.PrenotaPosti(5);
        prenotazione.StampaDettagli();

        prenotazione.PrenotaPosti(10);
        prenotazione.StampaDettagli();

        prenotazione.AnnullaPrenotazione(3);
        prenotazione.StampaDettagli();

        prenotazione.PrenotaPosti(100); // Esempio negativo
        prenotazione.AnnullaPrenotazione(50); // Altro esempio negativo
    }
}

//! Fatto da Alessandro Lopardo 