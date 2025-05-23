public class Veicolo
{
    public string Targa { get; set; }
    public virtual string Ripara()
    {
        return $"Il veicolo con targa '{Targa}' viene controllato.";
    }

    public Veicolo(string targa)
    {
        Targa = targa;
    }
}
public class Auto : Veicolo
{
    public Auto(string targa) : base(targa) { }
    public override string Ripara()
    {
        return $"Controllo olio, freni e motore dell'auto con targa '{Targa}'.";
    }
}
public class Moto : Veicolo
{
    public Moto(string targa) : base(targa) { }
    public override string Ripara()
    {
        return $"Controllo catena, freni e gomme della moto con targa '{Targa}'.";
    }
}
public class Camion : Veicolo
{
    public Camion(string targa) : base(targa) { }
    public override string Ripara()
    {
        return $"Controllo sospensioni, freni rinforzati e carico del camion con targa '{Targa}'.";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>();
        bool ciclo = true;

        while (ciclo)
        {
            Console.WriteLine("\n-- Gestionale Officina --");
            Console.WriteLine("1. Inserisci Auto");
            Console.WriteLine("2. Inserisci Moto");
            Console.WriteLine("3. Inserisci Camion");
            Console.WriteLine("4. Esegui riparazioni");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci targa auto: ");
                    string targaAuto = Console.ReadLine();
                    veicoli.Add(new Auto(targaAuto)); //aggiungo targa all'oggetto Auto
                    break;

                case "2":
                    Console.Write("Inserisci targa moto: ");
                    string targaMoto = Console.ReadLine();
                    veicoli.Add(new Moto(targaMoto)); //aggiungo targa all'oggetto Moto
                    break;

                case "3":
                    Console.Write("Inserisci targa camion: ");
                    string targaCamion = Console.ReadLine();
                    veicoli.Add(new Camion(targaCamion)); //aggiungo targa all'oggetto Camion
                    break;

                case "4":
                    Console.WriteLine("\n-- Tutti i veicoli in riparazione --");
                    foreach (Veicolo v in veicoli)
                    {
                        Console.WriteLine(v.Ripara());
                    }
                    break;

                case "0":
                    ciclo = false;
                    break;

                default: //default
                    Console.WriteLine("Errore! Scelta non valida.");
                    break;
            }
        }
    }
}