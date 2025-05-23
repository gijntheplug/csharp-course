using System;
using System.Security.Cryptography.X509Certificates;

public class Veicolo
{
    public string Marca;
    public string Modello;
    public int AnnoImmatricolazione;

        public Veicolo(string marca, string modello, int annoImmatricolazione)//costruttore veicolo
        {
            Marca = marca;
            Modello = modello;
        }

    public virtual StampaInfo()
    {
        return $"Auto: {Marca} {Modello}\nAnno immatricolazione: {AnnoImmatricolazione}";
    }
}
public class AutoAziendale : Veicolo
{
    public int Targa;
    public bool UsoPrivato;

    public AutoAziendale(string marca, string modello, int annoImmatricolazione, int targa, bool usoPrivato) : base(marca, modello, annoImmatricolazione)//costruttore autoAziendale
    {
        Targa = targa;
        UsoPrivato = usoPrivato;
    }

    public override string StampaInfo()
    {
        return $"Auto Aziendale: {Marca} {Modello}\nTarga: {Targa}\nUso: {UsoPrivato}\nAnno immatricolazione: {AnnoImmatricolazione}";
    }


}
public class FurgoneAziendale : Veicolo
{
    public int Carico;

    public Moto(string marca, string modello, int annoImmatricolazione, int carico) : base(marca, modello, annoImmatricolazione)//costruttore furgoneAziendale
    {
        Carico = carico;
    }

    public override string StampaInfo()
    {
        return $"Furgone Aziendale: {Marca} {Modello}\nAnno immatricolazione: {AnnoImmatricolazione}\nCarico: {Carico}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Veicolo> veicoli = new List<Veicolo>
        {
            new Veicolo("Fiat", "Panda", 2015),                     //!
            new AutoAziendale("Audi", "A4", 2020, 12345, true),     //! RIEMPIMENTI GENERATI DA COPILOT
            new FurgoneAziendale("Iveco", "Daily", 2018, 3500)      //!
        };

        foreach (Veicolo veicolo in veicoli)
        {
            Console.WriteLine(veicolo.StampaInfo());
            Console.WriteLine();
        }
    }
}