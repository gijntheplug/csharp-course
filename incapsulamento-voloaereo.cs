namespace Task02_Incapsulamento_2205
{
    public class VoloAereo
    {
        private int _postiOccupati;
        private string _codiceVolo;
        public const int MaxPosti = 150;

        public int PostiOccupati
        {
            get { return _postiOccupati; }
            private set { _postiOccupati = value; }
        }
        public int PostiLiberi
        {
            get
            {
                return MaxPosti - PostiOccupati;
            }
        }
        public string CodiceVolo
        {
            get
            {
                return _codiceVolo;
            }
            set
            {
                _codiceVolo = value;
            }
        }

        public void EffettuaPrenotazione(int numeroPosti)
        {
            if (numeroPosti > PostiLiberi || numeroPosti <= 0)
            {
                Console.WriteLine("Numero posti non valido, o più alto dei posti disponibili");
            }
            else
            {
                PostiOccupati += numeroPosti;
            }
        }

        public void AnnullaPrenotazione(int numeroPosti)
        {
            if (numeroPosti > PostiOccupati || numeroPosti <= 0)
            {
                Console.WriteLine("Non posso annullare così tante prenotazioni o numero negativo, riprovare");
                return;
            }
            PostiOccupati -= numeroPosti;
        }

        public override string ToString()
        {
            return $"Volo: {CodiceVolo} Posti Occupati:{PostiOccupati} Posti Liberi: {PostiLiberi}";
        }

        public VoloAereo(string codice)
        {
            _codiceVolo = codice;
            _postiOccupati = 0;
        }
    }

    public class Program
    {
        public static void Main()
        {
            //creazione lista per contenere gli aerei
            List<VoloAereo> voliPresenti = new List<VoloAereo>();
            bool controllo = true; // true finché l'utente non sceglie di uscire dal menù

            Console.WriteLine("-- Benvenuto nella lista voli --");

            do
            {
                //output del Menu
                Console.WriteLine("1.Aggiungi un Volo\n2.Effettua una prenotazione\n3.annulla una prenotazione\n4.Visualizza tutti i voli\n0.Esci");
                string sceltaInput = Console.ReadLine();
                if (!int.TryParse(sceltaInput, out int scelta))
                {
                    Console.WriteLine("Input non valido.");
                    continue;
                }
                //switch in base alla scelta definita esegue le funzioni scelte
                switch (scelta)
                {
                    case 1:
                        Console.Write("Inserisci il codice di volo con la destinazione: ");
                        string codice = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(codice))
                        {
                            Console.WriteLine("Codice volo non valido.");
                            break;
                        }
                        voliPresenti.Add(new VoloAereo(codice));
                        break;
                    case 2:
                        SelezionaVolo(voliPresenti, 1);
                        break;
                    case 3:
                        SelezionaVolo(voliPresenti, 2);
                        break;
                    case 4:
                        StampaVoli(voliPresenti);
                        break;
                    case 0:
                        controllo = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");//Messaggio di errore per una scelta non valida
                        break;
                }
            }
            while (controllo);
        }


        public static void SelezionaVolo(List<VoloAereo> voliPresenti, int daje)
        {
            StampaVoli(voliPresenti);
            Console.Write("Scegli il volo: ");
            string sceltaInput = Console.ReadLine();
            if (!int.TryParse(sceltaInput, out int scelta) || scelta < 0 || scelta >= voliPresenti.Count)
            {
                Console.WriteLine("Scelta non valida non esiste questo volo");
                return;
            }
            if (daje == 1)
            {
                Console.Write("Inserisci il numeri di posti da prenotare: ");
                string postiInput = Console.ReadLine();
                if (!int.TryParse(postiInput, out int posti))
                {
                    Console.WriteLine("Numero non valido.");
                    return;
                }
                voliPresenti[scelta].EffettuaPrenotazione(posti);

            }
            else if (daje == 2)
            {
                Console.Write("Inserisci il numeri di prenotazioni da annullare: ");
                string postiInput = Console.ReadLine();
                if (!int.TryParse(postiInput, out int posti))
                {
                    Console.WriteLine("Numero non valido.");
                    return;
                }
                voliPresenti[scelta].AnnullaPrenotazione(posti);
            }
        }


        public static void StampaVoli(List<VoloAereo> voliPresenti)
        {
            int count = 0;
            foreach (VoloAereo v in voliPresenti)
            {
                Console.WriteLine($"[{count}] {v}");
                count++;
            }
        }
    }
}
