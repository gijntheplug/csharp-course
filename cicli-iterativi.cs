using System;
class Program
{
    static void Main(string[] args)
    {
        // While Loop - Somma numeri positivi
        int somma = 0;
        int numero = 0;
        bool continua = true;
        while (continua)
        {
            Console.Write("Inserisci un numero positivo (o un numero negativo per terminare il ciclo): ");
            numero = int.Parse(Console.ReadLine());
            if (numero < 0)
            {
                break;
            }
            somma += numero;
        }
        Console.WriteLine("La somma totale dei numeri positivi inseriti è: " + somma);

        // Do-While Loop - Password con tentativi
        string password;
        int counter = 0;
        do
        {
            Console.Write("Inserisci una password sicura: ");
            password = Console.ReadLine();
            if (password == "1234")
            {
                Console.WriteLine("Accesso consentito");
                counter += 1;
            }
            else if (counter < 3)
            {
                Console.WriteLine($"Accesso negato, hai provato ad effettuare l'accesso {counter + 1}/3 volte.");
                counter += 1;
            }
        }
        while (counter < 3 && password != "1234");
    }
}