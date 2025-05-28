//classe astratta
public abstract class DispositivoElettronico
{
    public string Modello;

    //costruttore della classe astratta
    public DispositivoElettronico(string modello)
    {
        Modello = modello;
    }

    //metodo astratto per accendere il dispositivo
    public abstract void Accendi();
    //metodo astratto per spegnere il dispositivo
    public abstract void Spegni();
    //metodo virtuale per mostrare le informazioni del dispositivo
    public virtual void MostraInfo()
    {
        Console.WriteLine($"Mostra info. Modello: {Modello}");
    }
}

//sottoclasse "concreta" computer
public class Computer : DispositivoElettronico
{
    //costruttore della sottoclasse
    public Computer(string modello) : base(modello)
    {
    }

    //implementazione del metodo per accendere il computer
    public override void Accendi()
    {
        Console.WriteLine("Il computer si avvia...");
    }
    //implementazione del metodo per spegnere il computer
    public override void Spegni()
    {
        Console.WriteLine("Il computer si spegne.");
    }

    //override del metodo per mostrare le informazioni specifiche del computer
    public override void MostraInfo()
    {
        Console.WriteLine($"Computer - Modello: {Modello}");
    }
}

//sottoclasse "concreta" stampante
public class Stampante : DispositivoElettronico
{
    //costruttore della sottoclasse
    public Stampante(string modello) : base(modello)
    {
    }

    //implementazione del metodo per accendere la stampante
    public override void Accendi()
    {
        Console.WriteLine("La stampante si accende.");
    }
    //implementazione del metodo per spegnere la stampante
    public override void Spegni()
    {
        Console.WriteLine("La stampante va in standby.");
    }
}

//program
public class Program
{
    public static void Main(string[] args)
    {
        //lista per memorizzare i dispositivi elettronici
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>();
        bool esci = false;

        //ciclo principale del menù
        while (!esci)
        {
            Console.WriteLine("\n-- Menù dispositivi --");
            Console.WriteLine("1. Aggiungi Computer");
            Console.WriteLine("2. Aggiungi Stampante");
            Console.WriteLine("3. Mostra dispositivi");
            Console.WriteLine("4. Accendi dispositivo");
            Console.WriteLine("5. Spegni dispositivo");
            Console.WriteLine("6. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            if (scelta == "1")
            {
                //aggiunta di un nuovo computer
                Console.Write("Modello computer: ");
                string modello = Console.ReadLine();
                dispositivi.Add(new Computer(modello));
                Console.WriteLine("Computer aggiunto.");
            }
            else if (scelta == "2")
            {
                //aggiunta di una nuova stampante
                Console.Write("Modello stampante: ");
                string modello = Console.ReadLine();
                dispositivi.Add(new Stampante(modello));
                Console.WriteLine("Stampante aggiunta.");
            }
            else if (scelta == "3")
            {
                //visualizzazione dei dispositivi presenti
                if (dispositivi.Count == 0)
                    Console.WriteLine("Nessun dispositivo.");
                else
                    for (int i = 0; i < dispositivi.Count; i++)
                    {
                        Console.Write($"{i + 1}. ");
                        dispositivi[i].MostraInfo();
                    }
            }
            else if (scelta == "4")
            {
                //accensione di un dispositivo selezionato
                if (dispositivi.Count == 0)
                    Console.WriteLine("Nessun dispositivo.");
                else
                {
                    Console.Write("Numero dispositivo da accendere: ");
                    string input = Console.ReadLine();
                    int idx;
                    if (int.TryParse(input, out idx) && idx > 0 && idx <= dispositivi.Count)
                        dispositivi[idx - 1].Accendi();
                    else
                        Console.WriteLine("Scelta non valida.");
                }
            }
            else if (scelta == "5")
            {
                //spegnimento di un dispositivo selezionato
                if (dispositivi.Count == 0)
                    Console.WriteLine("Nessun dispositivo.");
                else
                {
                    Console.Write("Numero dispositivo da spegnere: ");
                    string input = Console.ReadLine();
                    int idx;
                    if (int.TryParse(input, out idx) && idx > 0 && idx <= dispositivi.Count)
                        dispositivi[idx - 1].Spegni();
                    else
                        Console.WriteLine("Scelta non valida.");
                }
            }
            else if (scelta == "6")
            {
                //uscita dal programma
                esci = true;
            }
            else
            {
                Console.WriteLine("Opzione non valida.");
            }
        }
    }
}