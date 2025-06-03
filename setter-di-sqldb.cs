public interface IDatabaseService
{
    void Connect(); // Metodo per connettersi al database
}

public class SqlDataBaseService : IDatabaseService
{
    public void Connect()
    {
        Console.WriteLine("Connessione al DB SQL."); // Simula la connessione a un database SQL
    }
}

public class ReportGenerator
{
    // Proprietà per iniettare il servizio database (Dependency Injection tramite setter)
    public IDatabaseService DatabaseService { get; set; }

    public void GenerateReport()
    {
        if (DatabaseService is null)
        {
            Console.WriteLine("DB non impostato."); // Controllo se il database è stato impostato
            return;
        }
        DatabaseService.Connect(); // Connessione al database
        Console.WriteLine("Generazione report in corso..."); // Simulazione generazione report
    }
}

public class Program
{
    static void Main(string[] args)
    {
        ReportGenerator generator = new ReportGenerator();
        generator.DatabaseService = new SqlDataBaseService(); // Impostazione del servizio database
        generator.GenerateReport(); // Avvio generazione report
    }
}