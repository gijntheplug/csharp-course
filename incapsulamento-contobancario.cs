public class ContoBancario
{
    //! campo privato (non accessibile direttamente dall'esterno)
    private double saldo; //TODO VARIABILE


    //* proprietà per accedere al saldo in modo controllato
    public double Saldo //TODO PROPRIETA'
    {
        get { return saldo; }//! permette la lettura del saldo (tramite metodo GET)
        set
        {
            if (value >= 0)
            {
                saldo = value;
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ContoBancario conto = new ContoBancario();

        conto.Saldo = 1000.50;//* set
        Console.WriteLine(conto.Saldo);//* get

        conto.Saldo = -500;//! saldo negativo (non subisce modifiche)
        Console.WriteLine(conto.Saldo);
    }
}