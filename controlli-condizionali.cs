using System;
class Program
{
    static void Main(string[] args)
    {
        // Esercizio 1 - Pari/Dispari
        int numero;
        Console.Write("Inserisci un numero intero: ");
        numero = int.Parse(Console.ReadLine());
        if (numero % 2 == 0)
        {
            Console.WriteLine("Il numero è PARI");
        }
        else
        {
            Console.WriteLine("Il numero è DISPARI");
        }

        // Esercizio 2 - Password
        string password;
        Console.Write("Inserisci una password sicura: ");
        password = Console.ReadLine();
        if (password == "1234")
        {
            Console.WriteLine("Accesso consentito");
        }
        else
        {
            Console.WriteLine("Accesso negato");
        }

        // Esercizio 3 - Calcolatrice Base
        double numUno;
        double numDue;
        string operazione;

        Console.Write("Inserisci il primo numero: ");
        numUno = double.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero: ");
        numDue = double.Parse(Console.ReadLine());

        Console.Write("Inserisci l'operazione (+, -): ");
        operazione = Console.ReadLine();
        if (operazione == "+" || operazione == "-")
        {
            if (operazione == "+")
            {
                Console.WriteLine("Il risultato è: " + (numUno + numDue));
            }
            else
            {
                Console.WriteLine("Il risultato è: " + (numUno - numDue));
            }
        }
        else
        {
            Console.WriteLine("Operatore non valido");
        }
    }
}