public interface ILogger
{
    void Log(string messaggio);
}
public class Printer : ILogger
{
    public void Log(string messaggio)
    {
        Console.WriteLine("Creo un Log.");
    }
}
public class LogGenerator
{
    public ILogger logger { get; set; }
    public void Print()
    {
        if (logger is null)
        {
            Console.WriteLine("Messaggio di Log non impostato.");
            return;
        }
        logger.Log();//crea un log
        Console.WriteLine("Generazione di Log in corso...");
    }
}
public class Program
{
    static void Main(string[] args)
    {
        LogGenerator logGenerator = new LogGenerator();
        logGenerator.logger = new Printer();
        logGenerator.Print();
    }
}