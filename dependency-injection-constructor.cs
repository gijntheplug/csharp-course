public interface ILogger
{
    void Log(string messaggio);
}
public class ConsoleLogger : ILogger
{
    public void Log(string messaggio)
    {
        Console.WriteLine($"LOG: {messaggio}");
    }
}
public class UserService
{
    private readonly ILogger _logger;
    public UserService(ILogger logger)
    {
        _logger = logger;//costruttore
    }
    public void CreaUser(string nome)
    {
        _logger.Log($"User '{nome}' è stato creato.");
    }
}
public class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        UserService userService = new UserService(logger);
        userService.CreaUser("Andrea");
    }
}