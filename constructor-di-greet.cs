public interface IGreeter
{
    void Greet(string messaggio);
}
public class ConsoleLogger : IGreeter
{
    public void Greet(string messaggio)
    {
        Console.WriteLine($"Saluto: {messaggio}");
    }
}
public class GreetService
{
    private readonly IGreeter _greeter;
    public GreetService(IGreeter greeter)
    {
        _greeter = greeter;
    }
    public void Saluta(string nome)
    {
        _greeter.Greet($"Ciao {nome}! benvenuto ;) .");
    }
}
public class Program
{
    static void Main(string[] args)
    {
        IGreeter greeter = new ConsoleLogger();
        GreetService greetService = new GreetService(greeter);
        greetService.Saluta("Andrea");
    }
}