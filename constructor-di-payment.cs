// Definizione dell'interfaccia per il gateway di pagamento
public interface IPaymentGateway
{
    // Metodo per effettuare un pagamento
    void Payment(string pagamento);
}

// Implementazione del gateway PayPal
public class PaypalGateway : IPaymentGateway
{
    public void Payment(string pagamento)
    {
        // Messaggio di conferma pagamento tramite PayPal
        Console.WriteLine($"Hai effettuato un pagamento tramite PayPal.");
    }
}

// Implementazione del gateway Stripe
public class StripeGateway : IPaymentGateway
{
    public void Payment(string pagamento)
    {
        // Messaggio di conferma pagamento tramite Stripe
        Console.WriteLine($"Hai effettuato un pagamento tramite Stripe.");
    }
}

// Classe che gestisce il processo di pagamento
public class PaymentProcessor
{
    // Campo privato per il gateway di pagamento
    private readonly IPaymentGateway _paymentGateway;

    // Costruttore che riceve un gateway di pagamento
    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    // Metodo per eseguire il pagamento
    public void DoPayment(string tipo)
    {
        _paymentGateway.Payment($"Hai pagato con {tipo}.");
    }
}

// Classe principale del programma
public class Program
{
    // Metodo Main, punto di ingresso dell'applicazione
    static void Main(string[] args)
    {
        // Richiesta all'utente di scegliere il metodo di pagamento
        Console.WriteLine("Scegli il metodo di pagamento:");
        Console.WriteLine("1. PayPal");
        Console.WriteLine("2. Stripe");
        Console.Write("Inserisci la tua scelta (1 o 2): ");
        string scelta = Console.ReadLine();

        IPaymentGateway gateway;

        // Selezione del gateway in base alla scelta dell'utente
        switch (scelta)
        {
            case "1":
                gateway = new PaypalGateway();
                break;
            case "2":
                gateway = new StripeGateway();
                break;
            default:
                // Gestione di scelta non valida
                Console.WriteLine("Scelta non valida. Uscita dal programma.");
                return;
        }

        // Creazione del processore di pagamento con il gateway selezionato
        PaymentProcessor processor = new PaymentProcessor(gateway);

        // Determinazione del tipo di pagamento per il messaggio
        string tipoPagamento;
        if (scelta == "1")
            tipoPagamento = "PayPal";
        else
            tipoPagamento = "Stripe";

        // Esecuzione del pagamento
        processor.DoPayment(tipoPagamento);
    }
}