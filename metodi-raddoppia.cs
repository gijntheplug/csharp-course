using System;

class Program
{
    static void Main(string[] args)
    {
        int numero;
        Console.WriteLine("Inserisci un numero:");
        numero = int.Parse(Console.ReadLine());
        Raddoppia(ref numero);
        Console.WriteLine(numero);
    }

    static void Raddoppia(ref int valore)
    {
        valore *= 2;
    }
}