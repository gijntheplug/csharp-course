using System.Security.Cryptography.X509Certificates;

public class Cane //*definizione della classe "Cane"
{
    //*proprietà (campi)
    public string? nome;
    public int eta;

    //*metodi
    public void Abbaia()
    {
        Console.WriteLine($"{nome} dice: Bau!");
    }
}

public class Program
{
    static void Main(string[] args)
    {

        //*creazione di un oggetto (istanza della classe "Cane")
        Cane mioCane = new Cane();

        //*assegnazione dei valori alle proprietà
        mioCane.nome = "Fido";
        mioCane.eta = 3;

        //*chiamata di un metodo sull'oggetto
        mioCane.Abbaia();//output: Fido dice: Bau!

    }
}
