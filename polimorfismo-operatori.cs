using System;
using System.Collections.Generic;

//superclasse operatore
public class Operatore
{
    //proprietà private
    private string nome = null!;
    private string turno = null!;

    //richiamo proprietà privata Nome
    public string Nome
    {
        get { return nome; }
        set
        {
            nome = value;
        }
    }

    //richiamo proprietà privata Turno
    public string Turno
    {
        get { return turno; }
        set
        {
            if (value.ToLower() == "giorno" || value.ToLower() == "notte")//controllo su metodo set con if
                turno = value;
            else
                Console.WriteLine("Turno non valido. Inserire 'giorno' o 'notte'.");
        }
    }

    public virtual void EseguiCompito()//metodo sovrascrivibile virtual
    {
        Console.WriteLine($"Operatore {Nome} in turno {Turno}: Compito generico eseguito.");//output console
    }
}

//sottoclasse operatoreEmergenza
public class OperatoreEmergenza : Operatore
{
    //proprietà privata
    private int livelloUrgenza;

    //richiamo proprietà privata livelloUrgenza
    public int LivelloUrgenza
    {
        get { return livelloUrgenza; }
        set
        {
            if (value >= 1 && value <= 5)//controllo lv. tra 1 e 5
                livelloUrgenza = value;
            else
                Console.WriteLine("Livello urgenza non valido. Deve essere tra 1 e 5.");
        }
    }

    public override void EseguiCompito()//metodo sovrascritto
    {
        Console.WriteLine($"{Nome} (Emergenza) - Gestione emergenza di livello {LivelloUrgenza}.");//output
    }
}

//sottoclasse operatoreSicurezza
public class OperatoreSicurezza : Operatore
{
    public string AreaSorvegliata { get; set; } = null!;

    public override void EseguiCompito()//metodo sovrascritto
    {
        Console.WriteLine($"{Nome} (Sicurezza) - Sorveglianza dell'area: {AreaSorvegliata}.");//output
    }
}

//sottoclasse operatoreLogistica
public class OperatoreLogistica : Operatore
{
    //proprietà privata
    private int numeroConsegne;

    //richiamo proprietà privata numeroConsegne
    public int NumeroConsegne
    {
        get { return numeroConsegne; }
        set
        {
            if (value >= 0)//controllo
                numeroConsegne = value;
            else
                Console.WriteLine("Numero consegne non valido.");
        }
    }

    public override void EseguiCompito()//metodo sovrascritto
    {
        Console.WriteLine($"{Nome} (Logistica) - Coordinamento di {NumeroConsegne} consegne.");//output
    }
}

public class Program
{
    public static void Main()
    {
        List<Operatore> centrale = new List<Operatore>();//inizializzo lista tipizzata "Operatore"
        bool ciclo = true;//booleano ciclo (finisce se l'utente sceglie di uscire dal menù)

        while (ciclo)
        {
            //console menu
            Console.WriteLine("\n-- Gestionale Operatori --");
            Console.WriteLine("[1] Aggiungi operatore emergenza");
            Console.WriteLine("[2] Aggiungi operatore sicurezza");
            Console.WriteLine("[3] Aggiungi operatore logistica");
            Console.WriteLine("[4] Visualizza operatori");
            Console.WriteLine("[5] Esegui compiti assegnati");
            Console.WriteLine("[0] Esci");
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
                    Console.WriteLine("\n-- Tutti gli operatori --");
                    foreach (Operatore op in centrale)
                    {
                        Console.WriteLine($"Nome: {op.Nome}, Turno: {op.Turno}, Tipo: {op.GetType().Name}");
                    }
                    break;

                case "5":
                    Console.WriteLine("\n-- Operatori in servizio --");
                    foreach (Operatore op in centrale)//per ogni operatore in centrale esegue metodo "EseguiCompito();"
                    {
                        op.EseguiCompito();
                    }
                    break;

                case "0":
                    ciclo = false;//uscita dal programma
                    break;

                default://errore
                    Console.WriteLine("Errore! Scelta non valida.");
                    break;
            }
        }
    }
}