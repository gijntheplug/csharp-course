public class Operatore
{
    //proprietà private
    private string nome;
    private string turno;

    //proprietà pubbliche
    public string Nome { get; set; }
    public string Turno
    {
        get;
        set
        {
            if (Turno == "giorno")//se il turno corrisponde a "giorno"
            {
                Console.WriteLine("Turno diurno.");
            }
            else//se il turno corrisponde a "notte"
            {
                Console.WriteLine("Turno notturno.");
            }
        }
    }
    public virtual string EseguiCompito()
    {
        return $"Operatore generico in servizio.";
    }

    public Operatore(string nome, string turno)//costruttore superclasse
    {
        Nome = nome;
        Turno = turno;
    }
}
public class OperatoreEmergenza : Operatore
{
    public int LivelloUrgenza
    {
        get;
        set
        {
            if (value > 0 && value < 6)
            {
                return;
            }
        }
    }

    public OperatoreEmergenza(string nome, string turno, int livelloUrgenza) : base(nome, turno)//costruttore sottoclasse
    {
        LivelloUrgenza = livelloUrgenza;
    }
    public override string EseguiCompito()
    {
        return $"Gestione emergenza di livello {LivelloUrgenza}.";
    }
}
public class OperatoreSicurezza : Operatore
{
    public string AreaSorvegliata;
    public OperatoreSicurezza(string nome, string turno, string areaSorvegliata) : base(nome, turno)//costruttore sottoclasse
    {
        AreaSorvegliata = areaSorvegliata;
    }
    public override string EseguiCompito()
    {
        return $"Sorveglianza dell'area {AreaSorvegliata}.";
    }
}
public class OperatoreLogistica : Operatore
{
    public int NumeroConsegne
    {
        get;
        set
        {
            if (value >= 0)
            {
                return;
            }
        }
    }
    public OperatoreLogistica(string nome, string turno, int numeroConsegne) : base(nome, turno)//costruttore sottoclasse
    {
        NumeroConsegne = numeroConsegne;
    }
    public override string EseguiCompito()
    {
        return $"Coordinamento di {NumeroConsegne} consegne.";
    }
}

public class Program
{
    public static void Main()
    {
        List<Operatore> centrale = new List<Operatore>();
        bool ciclo = true;

        while (ciclo)
        {
            Console.WriteLine("\n-- Gestionale Operatori --");
            Console.WriteLine("1. Aggiungi Operatore Emergenza");
            Console.WriteLine("2. Aggiungi Operatore Sicurezza");
            Console.WriteLine("3. Aggiungi Operatore Logistica");
            Console.WriteLine("4. Visualizza Operatori");
            Console.WriteLine("5. Esegui Compiti");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    OperatoreEmergenza oe = new OperatoreEmergenza();
                    Console.Write("Nome: "); oe.Nome = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): "); oe.Turno = Console.ReadLine();
                    Console.Write("Livello urgenza (1-5): "); oe.LivelloUrgenza = int.Parse(Console.ReadLine());
                    centrale.Add(oe);
                    break;

                case "2":
                    OperatoreSicurezza os = new OperatoreSicurezza();
                    Console.Write("Nome: "); os.Nome = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): "); os.Turno = Console.ReadLine();
                    Console.Write("Area sorvegliata: "); os.AreaSorvegliata = Console.ReadLine();
                    centrale.Add(os);
                    break;

                case "3":
                    OperatoreLogistica ol = new OperatoreLogistica();
                    Console.Write("Nome: "); ol.Nome = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): "); ol.Turno = Console.ReadLine();
                    Console.Write("Numero consegne: "); ol.NumeroConsegne = int.Parse(Console.ReadLine());
                    centrale.Add(ol);
                    break;

                case "4":
                    Console.WriteLine("\n-- Lista operatori --");
                    foreach (Operatore op in centrale)
                    {
                        Console.WriteLine($"Nome: {op.Nome}, Turno: {op.Turno}, Tipo: {op.GetType().Name}");
                    }
                    break;

                case "5":
                    Console.WriteLine("\n-- Lista operatori attivi --");
                    foreach (Operatore op in centrale)
                    {
                        op.EseguiCompito();
                    }
                    break;

                case "0":
                    ciclo = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("Chiusura programma.");
    }
}