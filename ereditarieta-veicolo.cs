using System;
using System.Security.Cryptography.X509Certificates;

public class Veicolo
{
    public string Marca;
    public string Modello;

    public Veicolo(string marca, string modello)
    {
        Marca = marca;
        Modello = modello;
    }

    public override string ToString()
    {
        return $"Veicolo: {Marca} {Modello}";
    }
}
public class Auto : Veicolo
{
    public int NumeroPorte;

    public Auto(string marca, string modello, int numeroPorte) : base(marca, modello)//costruttore auto
    {
        NumeroPorte = numeroPorte;
    }

    public override string ToString()
    {
        return $"Auto: {Marca} {Modello}, Porte: {NumeroPorte}";
    }
}
public class Moto : Veicolo
{
    public string TipoManubrio;

    public Moto(string marca, string modello, string tipoManubrio) : base(marca, modello)//costruttore moto
    {
        TipoManubrio = tipoManubrio;
    }

    public override string ToString()
    {
        return $"Moto: {Marca} {Modello}, Manubrio: {TipoManubrio}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Veicolo> officina = new List<Veicolo>();
        bool continua = true;

        while (continua == true)
        {
            Console.WriteLine("\n~~ Benvenuto nel gestionale dell'Officina dei Campioni ~~");
            Console.WriteLine("Seleziona [1] per inserire un'AUTO nel gestionale.");
            Console.WriteLine("Seleziona [2] per inserire una MOTO nel gestionale.");
            Console.WriteLine("Seleziona [3] per mostrare tutti i veicoli nel gestionale.");
            Console.WriteLine("Seleziona [X] per uscire dal gestionale.");

            //! inizio interazione con utente
            Console.Write("Seleziona un'opzione fra quelle proposte:");
            string pulsante = Console.ReadLine();

            switch (pulsante)
            {
                case "1":
                    Console.Write("Marca: ");
                    string? marcaAuto = Console.ReadLine();
                    Console.Write("Modello: ");
                    string? modelloAuto = Console.ReadLine();
                    Console.Write("Numero porte: ");
                    int numeroPorte = int.Parse(Console.ReadLine());
                    officina.Add(new Auto(marcaAuto, modelloAuto, numeroPorte));
                    break;

                case "2":
                    Console.Write("Marca: ");
                    string? marcaMoto = Console.ReadLine();
                    Console.Write("Modello: ");
                    string? modelloMoto = Console.ReadLine();
                    Console.Write("Tipo manubrio: ");
                    string tipoManubrio = Console.ReadLine();
                    officina.Add(new Moto(marcaMoto, modelloMoto, tipoManubrio));
                    break;

                case "3":
                    Console.WriteLine("\n~~ Veicoli nell'Officina ~~");
                    foreach (Veicolo v in officina)
                    {
                        Console.WriteLine(v.ToString());
                    }
                    break;

                case "X":
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
            Console.WriteLine("Arrivederci.");
        }
    }
}
