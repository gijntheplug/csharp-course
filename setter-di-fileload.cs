public interface IStorageService
{
    void Load();
}

// Implementazione concreta che simula il caricamento su disco
public class Disco : IStorageService
{
    public void Load()
    {
        Console.WriteLine("Sto caricando un file sul disco.");
    }
}

// Implementazione concreta che simula un caricamento fittizio
public class Simula : IStorageService
{
    public void Load()
    {
        Console.WriteLine("Sto simulando il caricamento di un file.");
    }
}

public class FileUploader
{
    // Proprietà per iniettare il servizio di storage desiderato
    public IStorageService storageService { get; set; }

    public void CaricaFile()
    {
        // Controlla se il servizio di storage è stato impostato
        if (storageService is null)
        {
            Console.WriteLine("File non presente.");
            return;
        }
        storageService.Load();
        Console.WriteLine("Caricamento File...");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Scegli il tipo di caricamento:");
        Console.WriteLine("1. Disco");
        Console.WriteLine("2. Simulato");
        string scelta = Console.ReadLine();

        FileUploader uploader = new FileUploader();

        // Seleziona l'implementazione del servizio in base alla scelta dell'utente
        switch (scelta)
        {
            case "1":
                uploader.storageService = new Disco();
                break;
            case "2":
                uploader.storageService = new Simula();
                break;
            default:
                uploader.storageService = null;
                break;
        }

        uploader.CaricaFile();
    }
}