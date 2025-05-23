using System;

//Creazione classe base con assegnazioni delle variabili, lista e corrispettivo costruttore
public class Corso
{
    public string NomeCorso;
    public int DurataOre;
    public string Docente;

//Creazione lista
    public List<string> Studenti;

//Costruttore
    public Corso(string nomeCorso, int durataOre, string docente, List<string> studenti)
    {
        NomeCorso = nomeCorso;
        DurataOre = durataOre;
        Docente = docente;
        Studenti = studenti;
    }

//Creazione metodo che aggiunge uno studente al corso
    public void AggiungiStudente(string nomeStudente) //FATTO
    {
        Studenti.Add(nomeStudente);
    }

//Creazione del metodo base che stampa le varie informazioni
    public virtual string toString()
    {
        return $"Nome corso: {NomeCorso} | Durata ore: {DurataOre} | Docente: {Docente} | Studenti {Studenti}";
    }

//Creazione del metodo speciale che permetterà una volta ereditato di stampare la frase in base al corso che lo sovrascriverà
    public virtual void MetodoSpeciale()
    {
        Console.WriteLine("Ciao campione");
    }
}

public class CorsoMusica : Corso //! Carlo Condello
{
    //Creazione variabile non ereditata con corrispettivo costruttore
    public string Strumento;

    public CorsoMusica(string nomeCorso, int durataOre, string docente, List<string> studenti, string strumento) : base(nomeCorso, durataOre, docente, studenti)
    {
        Strumento = strumento;
    }

    //Override del metodo della classe base che stampa le varie informazioni
    public override string toString()
    {
        return $"Nome corso: {NomeCorso} | Durata ore: {DurataOre} | Docente: {Docente} | Studenti {Studenti} | Strumento utilizzato: {Strumento}";
    }

    //Override del metodo della classe base che stampa la frase preimpostata per ogni tipo di corso

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si tiene una prova pratica dello strumento: {Strumento}");
    }
}

public class CorsoPittura : Corso//! Andrea Fabbri @gijntheplug on github
{
    //Creazione variabile non ereditata con corrispettivo costruttore
    public string Tecnica;
    public CorsoPittura(string nomeCorso, int durataOre, string docente, List<string> studenti, string tecnica) : base(nomeCorso, durataOre, docente, studenti)
    {
        Tecnica = Tecnica;
    }

//Override del metodo della classe base che stampa le varie informazioni
    public override string ToString()
    {
        return $"Nome corso: {NomeCorso} | Durata ore: {DurataOre} | Docente: {Docente} | Studenti: {Studenti} | Tecnica utilizzata: {Tecnica}";
    }

    //Override del metodo della classe base che stampa la frase preimpostata per ogni tipo di corso
    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si usa la tecnica: {Tecnica}");
    }
}

public class CorsoDanza : Corso //! Simone Addesso
{
    //Creazione variabile non ereditata con corrispettivo costruttore
    public string Stile;
    public CorsoDanza(string nomeCorso, string docente, int durataOre, List<string> studenti, string stile) : base(nomeCorso, durataOre, docente, studenti)
    {
        Stile = stile;
    }

//Override del metodo della classe base che stampa le varie informazioni
    public override string ToString()
    {
        return $"Nome corso: {NomeCorso} | Durata ore: {DurataOre} | Docente: {Docente} | Studenti: {Studenti} | Stile: {Stile}";
    }

    //Override del metodo della classe base che stampa la frase preimpostata per ogni tipo di corso
    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Esecuzione coreografia nello stile: {Stile}");
    }
}

//Creazione della classe main
public class Program
{
    public static void Main(string[] args)
    {
        //Creazione della lista corsi
        List<Corso> corsi = new List<Corso>();
        int scelta;
        //Inizializzazione della condizione per permettere al ciclo di funzionare
        bool esci = false;

        //Creazione del ciclo che visualizzerà il menù
        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Aggiungi un corso di Musica\n[2] Aggiungi un corso di Pittura\n[3] Aggiungi un corso di Danza\n[4] Aggiungi studente a un corso");
            Console.WriteLine("[5] Visualizza tutti i corsi\n[6] Cerca corsi per nome docente\n[7] Esegui metodo speciale di un corso\n[0] Esci");
            scelta = int.Parse(Console.ReadLine());

        //Inizio menù a scelta
            switch (scelta)
            {
                case 1: // Inserimento corso di Musica
                    AggiungiMusica(corsi);
                    break;
                case 2: // Inserimento corso di Pittura
                    AggiungiPittura(corsi);
                    break;
                case 3: // Inserimento corso di Danza
                    AggiungiDanza(corsi);
                    break;
                case 4: // Inserisce studente ad un corso a scelta dell'utente
                    AggiungiStudente(corsi);
                    break;
                case 5: // Stampa tutti i corsi
                    StampaCorsi(corsi);
                    break;
                case 6: // Stampa solo corsi con il docente inseriti in input dall'utente
                    CercaDocente(corsi);
                    break;
                case 7:
                    EseguiMetodoSpeciale(corsi);
                    break;
                case 0:
                    Console.WriteLine("Arrivederci campione!");
                    esci = true; // Cambia esci in true per finire il ciclo una volta finito
                    break;
                default:
                    Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                    break;
            }
        } while (!esci);
    }

//Creazione della funzione che aggiunge il corso musica
    private static void AggiungiMusica(List<Corso> corsi)
    {
        List<string> studenti = new List<string>();
        Console.WriteLine("Inserisci nome del corso:");
        string nomeCorso = Console.ReadLine();
        Console.WriteLine("Inserisci la durata del corso in ore:");
        int durata = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il nome del docente:");
        string nomeDocente = Console.ReadLine();
        Console.WriteLine("Inserisci lo strumento insegnato nel corso:");
        string strumento = Console.ReadLine();

//Creazione dell'oggetto corsoMusica di tipo CorsoMusica
        CorsoMusica corsoMusica = new CorsoMusica(nomeCorso, durata, nomeDocente, studenti, strumento);
        corsi.Add(corsoMusica);
        Console.WriteLine("Corso inserito!");
    }

//Creazione della funzione che aggiunge il corso pittura
    private static void AggiungiPittura(List<Corso> corsi)
    {
        List<string> studenti = new List<string>();
        Console.WriteLine("Inserisci nome del corso:");
        string nomeCorso = Console.ReadLine();
        Console.WriteLine("Inserisci la durata del corso in ore:");
        int durata = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il nome del docente:");
        string nomeDocente = Console.ReadLine();
        Console.WriteLine("Inserisci la tecnica insegnata nel corso:");
        string tecnica = Console.ReadLine();

//Creazione dell'oggetto corsoPittura di tipo CorsoPittura e aggiunta alla lista
        CorsoPittura corsoPittura = new CorsoPittura(nomeCorso, durata, nomeDocente, studenti, tecnica);
        corsi.Add(corsoPittura);
        Console.WriteLine("Corso inserito!");
    }

//Creazione della funzione che aggiunge il corso danza
    private static void AggiungiDanza(List<Corso> corsi)
    {
        List<string> studenti = new List<string>();
        Console.WriteLine("Inserisci nome del corso:");
        string nomeCorso = Console.ReadLine();
        Console.WriteLine("Inserisci la durata del corso in ore:");
        int durata = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il nome del docente:");
        string nomeDocente = Console.ReadLine();
        Console.WriteLine("Inserisci lo stile insegnato nel corso:");
        string stile = Console.ReadLine();

//Creazione dell'oggetto corsoDanza di tipo CorsoDanza e aggiunta alla lista
        CorsoDanza corsoDanza = new CorsoDanza(nomeCorso, nomeDocente, durata, studenti, stile);
        corsi.Add(corsoDanza);
        Console.WriteLine("Corso inserito!");
    }

//Creazione della funzione che aggiunge uno studente al corso
    private static void AggiungiStudente(List<Corso> corsi)
    {
        for (int i = 0; i < corsi.Count; i++)
        {
            Console.WriteLine($"CORSO {i + 1} | {corsi[i].ToString()}");
        }

        Console.WriteLine("A quale corso vuoi inserire uno studente? (Inserisci numero del corso)");
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il nome dello studente:");
        string studente = Console.ReadLine();

        //Aggiunge uno studente al corso scelto, essendo una lista inserisci -1 per iniziare dall'indice corretto
        corsi[c - 1].AggiungiStudente(studente);

        Console.WriteLine("Studente aggiunto!");
    }

//Creazione della funzione che stampa tutti i corsi e le varie informazioni
    private static void StampaCorsi(List<Corso> corsi)
    {
        foreach (Corso corso in corsi)
        {
            Console.WriteLine(corso.ToString());
        }
    }

//Creazione della funzione che cerca e stampa i corsi del docente selezionato in input
    private static void CercaDocente(List<Corso> corsi)
    {
        Console.WriteLine("Inserisci il nome di un professore per trovare i suoi corsi:");
        string prof = Console.ReadLine();
        foreach (Corso corso in corsi)
        {
            if (corso.Docente.ToLower() == prof.ToLower())
            {
                Console.WriteLine(corso.ToString());
            }
        }
    }

//Creazione della funzione che esegue il metodo speciale del corso selezionato in input
    private static void EseguiMetodoSpeciale(List<Corso> corsi)
    {
        for (int i = 0; i < corsi.Count; i++)
        {
            Console.WriteLine($"CORSO {i + 1} | {corsi[i].ToString()}");
        }

        Console.WriteLine("Di quale corso vuoi eseguire il metodo speciale? (Inserisci numero del corso)");
        int c = int.Parse(Console.ReadLine());
        corsi[c - 1].MetodoSpeciale();
    }
}
    



