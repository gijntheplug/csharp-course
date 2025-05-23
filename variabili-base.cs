using System;

class Program
{
    static void Main(string[] args)
    {
        //! Dichiarazione di variabili
        int numero = 10;            //Intero
        float decimale = 3.14f;     //Decimale
        char lettera = 'A';         //Carattere
        bool condizione = true;     //Booleano
        string saluto = "Ciao!";    //Stringa

        Console.WriteLine("Numero: " + numero);
        Console.WriteLine("Decimale: " + decimale);
        Console.WriteLine("Lettera: " + lettera);
        Console.WriteLine("Condizione: " + condizione);
        Console.WriteLine("Saluto: " + saluto);

        //! Conversione di tipi
        int intero = 45;
        float numeroLungo = intero;
        Console.WriteLine($"numero convertito: {numeroLungo}");//casting da int a float

        float pi = 3.14f;
        int circaPi = (int)pi;
        Console.WriteLine($"Pi convertito: {circaPi}");//casting da float a int
    }
}