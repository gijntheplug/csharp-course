public class Forma
{
    public virtual double CalcolaArea()
    {
        return 0;
    }
}

public class Rettangolo : Forma
{
    public double Base { get; set; }
    public double Altezza { get; set; }
    public override double CalcolaArea()
    {
        return Base * Altezza;
    }
}

public class Cerchio : Forma
{
    public double Raggio { get; set; }
    public override double CalcolaArea()
    {
        return Math.PI * Raggio * Raggio;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Forma> forme = new List<Forma>
        {
            new Rettangolo{Base=4,Altezza=5},
            new Cerchio {Raggio=3}
        };

        foreach (Forma f in forme)
        {
            Console.WriteLine("Area: " + f.CalcolaArea());
        }
    }
}