//interfaccia (contratto) IPagamento
public interface IPagamento
{
    void EseguiPagamento(decimal importo);
    void MostraMetodo();
}

//classe PagamentoCarta con interfaccia IPagamento implementata
public class PagamentoCarta : IPagamento
{
    //attributo pubblico
    public string Circuito { get; set; }
    public decimal Importo { get; set; }

    //costruttore PagamentoCarta
    public PagamentoCarta(decimal importo, string circuito)
    {
        Importo = importo;
        Circuito = circuito;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo}€ con carta {Circuito}.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Carta di credito.");
    }
}

public class PagamentoContanti : IPagamento
{
    public decimal Importo { get; set; }

    public PagamentoContanti(decimal importo)
    {
        Importo = importo;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo}€ in contanti.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Contanti.");
    }
}

//classe PagamentoPaypal con interfaccia IPagamento implementata
public class PagamentoPaypal : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo}€ tramite PayPal.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: PayPal.");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        List<IPagamento> pagamenti = new List<IPagamento>();
        bool esci = false;

        while (!esci)
        {
            Console.WriteLine("\n-- Benvenuto nel gestionale dei pagamenti --");
            Console.WriteLine("[1] Esegui Pagamento");
            Console.WriteLine("[2] Visualizza Pagamenti");
            Console.WriteLine("[3] Mostra Metodi di Pagamento");
            Console.WriteLine("[4] Cancella Tutti i Pagamenti");
            Console.WriteLine("[5] Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("Scegli il metodo di pagamento:");
                    Console.WriteLine("[1] Carta");
                    Console.WriteLine("[2] PayPal");
                    Console.Write("Metodo: ");
                    string metodo = Console.ReadLine();

                    Console.Write("Inserisci l'importo: ");
                    decimal importo = decimal.Parse(Console.ReadLine());

                    switch (metodo)
                    {
                        case "1":
                            Console.Write("Inserisci il circuito della carta: ");
                            string circuito = Console.ReadLine();
                            PagamentoCarta pagamentoCarta = new PagamentoCarta(importo);
                            pagamentoCarta.circuito = circuito;
                            pagamenti.Add(pagamentoCarta);
                            pagamentoCarta.EseguiPagamento(importo);
                            Console.WriteLine($"Pagamento di {importo}€ con carta {circuito} eseguito.");
                            break;
                        case "2":
                            PagamentoPaypal pagamentoPaypal = new PagamentoPaypal();
                            pagamenti.Add(pagamentoPaypal);
                            pagamentoPaypal.EseguiPagamento(importo);
                            Console.WriteLine($"Pagamento di {importo}€ tramite PayPal eseguito.");
                            break;
                        default:
                            Console.WriteLine("Metodo non valido.");
                            break;
                    }
                    break;

                case "2":
                    if (pagamenti.Count == 0)
                    {
                        Console.WriteLine("Nessun pagamento registrato.");
                    }
                    else
                    {
                        foreach (var pagamento in pagamenti)
                        {
                            Console.Write($"{i}. ");
                            pagamento.MostraMetodo();
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("Metodi di pagamento disponibili:");
                    Console.WriteLine("- Carta");
                    Console.WriteLine("- PayPal");
                    break;

                case "4":
                    pagamenti.Clear();
                    Console.WriteLine("Tutti i pagamenti sono stati cancellati.");
                    break;

                case "5":
                    esci = true;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}